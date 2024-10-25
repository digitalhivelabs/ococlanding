using Microsoft.AspNetCore.Mvc;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using API.Data;
using System.Text.Json;
using API.Entities;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepositoy _userRepository;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;
    private readonly ILogApi _logApi;

    // public UsersController(IUserRepositoy userRepository, IMapper mapper, IMailService _MailService)
    public UsersController(IUserRepositoy userRepository, IMailService _MailService, IMapper mapper, ILogApi logApi)
    {
        _userRepository = userRepository;
        _mailService = _MailService;
        _mapper = mapper;
        _logApi = logApi;
    }

    
    [HttpGet("{isActive}")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers(bool isActive = true) 
    {
        try
        {

            var users = await _userRepository.GetUserActiveAsync(isActive);
            //var usersToReturn = _mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(users);
        
        } catch(Exception e) {
            _logApi.Record(e.Message, e.StackTrace, "User.GetUsers", "isActive: " + (isActive ? "true":"false")); //JsonSerializer.Serialize(survey));
            return StatusCode(500, new MessageResponse());  
        } 
    }

    
    [HttpGet("ById/{id}")] // /api/users/2
    public async Task<ActionResult<UserDTO>> GetUser(int id)
    {
        try
        {
            var user = await _userRepository.GetUserDTOByIdAsync(id);
            //var userR = _mapper.Map<UserDTO>(user);

            return Ok(user);

        } catch(Exception e) {
            _logApi.Record(e.Message, e.StackTrace, "User.GetUser", "ID: " + id.ToString()); //JsonSerializer.Serialize(survey));
            return StatusCode(500,new MessageResponse()); 
        }     
    }

    [HttpPut("approver")]
    public async Task<ActionResult<bool>> Approver(UserApproverDTO user)
    {
        try
        {
            var userF = await _userRepository.GetUserByIdAsync(user.UserId);

            if (userF == null) return BadRequest(new MessageResponse("405","User not found"));

            userF.Role = user.Role;
            
            if (user.IsApproved) {
                userF.Status = "Approved";
                userF.IsActive = true;
                userF.StartDate = DateTime.Now;
            } else {
                userF.Status = "Reject";
                userF.IsActive = false;
            }
                
            _userRepository.Update(userF);

            await _userRepository.SaveAllAsync();

            var ebody = "<p>Your access request has been processed, status: {0}</p></hr><p>Su solicitud de acceso hacido procesada, estatus: {0}</p>";
            // Send Email to User
            var mailData = new MailData();
            mailData.EmailTo = userF.Email; 
            mailData.EmailSubject = "Validation code / Codigo de validacion";
            mailData.EmailBody = string.Format(ebody, userF.Status);

            _mailService.SendMail(mailData);


            return Ok();

        } catch(Exception e) {
            _logApi.Record(e.Message, e.StackTrace, "User.Approver", JsonSerializer.Serialize(user));
            return StatusCode(500,new MessageResponse());
        }            
    }

    [HttpPut()]
    public async Task<ActionResult<bool>> Update(UserDTO user)
    {
        try
        {
            var userU = await _userRepository.GetUserByIdAsync(user.Id);

            if (userU == null) return BadRequest(new MessageResponse("405","User not found"));
            
            _mapper.Map(user,userU) ;
                
            _userRepository.Update(userU);

            await _userRepository.SaveAllAsync();        

            return Ok(new MessageResponse("200","User Updated"));

        } catch(Exception e) {
            _logApi.Record(e.Message, e.StackTrace, "User.Update", JsonSerializer.Serialize(user));
            return StatusCode(500,new MessageResponse());
        }             
    }
/*
    [AllowAnonymous]
    [HttpPost("register")] // Post: api/users/register
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto) 
    {
        registerDto.Username = registerDto.Username.ToLower();

        if (await UserExist(registerDto.Username)) return BadRequest("Username is taken");

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
            RegistrationDate = DateTime.Now            
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return new UserDTO 
        {
            Id = user.Id,
            Username = user.UserName,
            Email = user.Email,
            Country = user.Country,
            Gender = user.Gender,
            Role = user.Role,
            Token = _tokenService.CreateToken(user)

        };

    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<LoginReponseDTO>> Login(LoginDTO loginDto)
    {
        loginDto.Username = loginDto.Username.ToLower();

        var user =  await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

        if (user == null) return Unauthorized("Invalid user or password User");

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < ComputeHash.Length; i++)
        {
            if (ComputeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid user or password");
        }

        return new LoginReponseDTO 
        {
            Id = user.Id,
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };

    }


    private async Task<bool> UserExist(string username)
    {
        return await _context.Users.AnyAsync(x => x.UserName == username);
    }
*/

}
