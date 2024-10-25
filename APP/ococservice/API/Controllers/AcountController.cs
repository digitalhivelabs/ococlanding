using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[AllowAnonymous]
public class AcountController: BaseApiController
{
    private readonly IUserRepositoy _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly ILogApi _logApi;
    //private readonly SendersEmailSettings _sendersEmailSettings;

    public AcountController(IUserRepositoy userRepository, ITokenService tokenService, 
        IMapper mapper, IMailService _MailService, ILogApi logApi)
    {   
         // IOptions<SendersEmailSettings> sendersEmailSettings,              
        _userRepository = userRepository;
        _tokenService = tokenService;
        _mapper = mapper;
        _mailService = _MailService;
        _logApi = logApi;
       // _sendersEmailSettings = sendersEmailSettings;
    }

    

    [HttpPost("login")]
    public async Task<ActionResult<LoginReponseDTO>> Login(LoginDTO loginDto)
    {
        try {
            loginDto.Username = loginDto.Username.ToLower();

            var user =  await _userRepository.GetUserByUsernameAsync(loginDto.Username);

            if (user == null) return Unauthorized( new MessageResponse("403","Invalid user or password"));
            if (user.Status == "Pending") return Unauthorized(new MessageResponse("403", "Your Request is Pending") );
            if (!user.IsActive) return Unauthorized(new MessageResponse("403","Your are Inactive"));

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < ComputeHash.Length; i++)
            {

                if (ComputeHash[i] != user.PasswordHash[i]) return Unauthorized(new MessageResponse("403", "Invalid user or password"));
            }

            return new LoginReponseDTO 
            {
                Id = user.Id,
                Username = user.UserName,
                Role = user.Role,
                Token = _tokenService.CreateToken(user)
            };
        } catch(Exception e) {
            _logApi.Record(e.Message, e.StackTrace, "Login", JsonSerializer.Serialize( loginDto));
            return StatusCode(500, new MessageResponse());            
        }

    }

    [HttpPost("register")] // Post: api/acount/register
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto) 
    {
        try 
        {
            registerDto.Username = registerDto.Username.ToLower();

            if (await UserExist(registerDto.Username)) return BadRequest(new MessageResponse("403", "Username is taken"));

            using var hmac = new HMACSHA512();

            var user = new User 
            {
                UserName = registerDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                Email = registerDto.Email,
                Country = registerDto.Country,
                Gender = registerDto.Gender,
                StartDate = registerDto.StartDate,
                Job = registerDto.Job,
                Role = "User",
                Status = "Pending",
                IsActive = false,
                RegistrationDate = DateTime.Now            
            };

            _userRepository.Add(user);

            await _userRepository.SaveAllAsync();

            var fRequestAccessToAdmin = "<p>The user {0} ({1}) is requesting access to the administration application.</p></hr><p>El usuario {0} ({1}) esta solicitando acceso la aplicacion de administracion.</p>";
            var fRequestAccessToUser = "<p>Your access request is pending approval, you will receive a notification when your access is approved.</p><hr><p>Su solicitud de acceso esta pendiente de aprobación, recibira una notificacion cuando su acceso este aprovado.</p>";

            // Send Email to Admin
            var mailData = new MailData();
            mailData.EmailTo = "erick.velazquez@binationalwaters.org"; // _sendersEmailSettings.UserAdminApprover; 
            mailData.EmailSubject = String.Format("Request access / Solicitud de Acceso ({0})", user.UserName);
            mailData.EmailBody = string.Format(fRequestAccessToAdmin, user.UserName, user.Job);
            

            _mailService.SendMail(mailData);

            // Send Email to User
            mailData = new MailData();
            mailData.EmailTo = user.Email; 
            mailData.EmailSubject = "Request access / Solicitud de Acceso";
            mailData.EmailBody = fRequestAccessToUser;

            _mailService.SendMail(mailData);


            return _mapper.Map<UserDTO>(user);
            /*new UserDTO 
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Country = user.Country,
                Gender = user.Gender,
                Role = user.Role,
                Job = user.Job,
                Status = user.Status,
                IsActive = user.IsActive,
                StartDate = user.StartDate,
                RegistrationDate = user.RegistrationDate
                //Token = _tokenService.CreateToken(user)
            }; 
            */
        } catch(Exception e) {
            _logApi.Record(e.Message, e.StackTrace, "Register", JsonSerializer.Serialize(registerDto));
            return StatusCode(500, new MessageResponse());
        }
    }

    [HttpPost("resetPwdRequest/{userName}")] // Post: api/acount/resetPwdRequest
    public async Task<ActionResult<string>> resetPwdRequest(string userName) 
    {
        try
        {
            userName = userName.ToLower();

            var user =  await _userRepository.GetUserByUsernameAsync(userName);

            if (user == null) return Unauthorized(new MessageResponse("403", "Invalid user"));
            
            // Get Codigo de confirmacion.
            string confirmacion = "";

            Random rnd = new Random();
            confirmacion += rnd.Next(0,9).ToString() + rnd.Next(0,9).ToString() 
                        + rnd.Next(0,9).ToString() + rnd.Next(0,9).ToString();
            
            var ebody = "<p>Validation code for the user: {0}</p></hr><p>Codigo de validacion para el usuario: {0}</p>";
            // Send Email to User
            var mailData = new MailData();
            mailData.EmailTo = user.Email; 
            mailData.EmailSubject = "Validation code / Codigo de validacion";
            mailData.EmailBody = string.Format(ebody, confirmacion);

            _mailService.SendMail(mailData);
            
            return confirmacion;
        } catch(Exception e) {
            _logApi.Record(e.Message, e.StackTrace, "resetPwdRequest", "UserName: " + userName);//JsonSerializer.Serialize(registerDto));
            return StatusCode(500,new MessageResponse());            
        }

    }

    [HttpPost("resetPwd")] // Post: api/acount/resetPwd
    public async Task<ActionResult<bool>> resetPwd(LoginDTO loginDto) 
    {
        try
        {
            
            loginDto.Username = loginDto.Username.ToLower();

            var user =  await _userRepository.GetUserByUsernameAsync(loginDto.Username);
            

            if (user == null) return Unauthorized(new MessageResponse("403", "Invalid user"));

            using var hmac = new HMACSHA512();

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            user.PasswordSalt = hmac.Key;
            
            _userRepository.Update(user);

            await _userRepository.SaveAllAsync();

            return true;
        } catch(Exception e) {
            _logApi.Record(e.Message, e.StackTrace, "resetPwd", JsonSerializer.Serialize(loginDto));
            return StatusCode(500, new MessageResponse());
        }
    }
    
    private async Task<bool> UserExist(string username)
    {
        return await _userRepository.GetUserByUsernameAsync(username) != null;
    }

}
