using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using API.Entities;
using System.Text;
using AutoMapper;
using System.Text.Json;

namespace API.Controllers
{
    //[Authorize]
    public class SpesimensController: BaseApiController
    {
        private readonly ISpesimenRepository _spesimenRepository;
        private readonly IUserRepositoy _userRepositoy;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        private readonly ILogApi _logApi;

        

        public SpesimensController(ISpesimenRepository spesimenRepository, IUserRepositoy userRepositoy
            , IItemRepository itemRepository, IUnitRepository unitRepository, IMapper mapper, ILogApi logApi )
        {
            _spesimenRepository = spesimenRepository;
            _spesimenRepository = spesimenRepository;
            _userRepositoy = userRepositoy;
            _itemRepository = itemRepository;
            _unitRepository = unitRepository;
            _mapper = mapper;
            _logApi = logApi;
        }
    
        [Authorize]
        [HttpPost("upload")] // Post: api/survey/upload
        public async Task<ActionResult<Spesimen>> Upload([FromForm] SpesimenIDTO spesimen) 
        {
            /*
            var x = 1;

            // var PathToServiceAccountKeyile = @"C:\Repos\ococ\ococservice\API\client_secret_Drive.json";
            string root_path =  Path.Combine(Environment.CurrentDirectory, @"JsonFiles\"); //.ProcessPath; // .GetEnvironmentVariable("JsonFiles"); // HttpRuntime.AppDomainAppPath;            
            var PathToServiceAccountKeyile = root_path + "client_secret_Drive.json";
            var ServiceAccountEmail = "notificacionesococ@gmail.com";
            var UploadFileName = "Test_1.txt";
            var DirectoryId = "1PFZffjp9ENh0frXPtfLIDqtD89YWgvQ1";

            // Load the Service account credentials and define the scope of its access.
            var credential = GoogleCredential.FromFile(PathToServiceAccountKeyile)
                .CreateScoped(DriveService.ScopeConstants.Drive);

            // Create the Drive service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer  = credential
            });

            // Upload file Metadata
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "Test_1.txt",
                Parents = new List<string>() {"1PFZffjp9ENh0frXPtfLIDqtD89YWgvQ1"}
            };

            var uploadedFileId = "";
            // Create a new file on Google Drive
            await using (var fsSource = new FileStream(UploadFileName, FileMode.Open, FileAccess.Read))
            {
                // Create a new file, with metadata and stream.
                var request =  service.Files.Create(fileMetadata, fsSource, "text/plain");
                request.Fields = "*";
                var results = await request.UploadAsync(CancellationToken.None);

                if (results.Status == UploadStatus.Failed)
                {
                    return BadRequest("Upload Failed");
                }

                uploadedFileId = request.ResponseBody?.Id;
            };
            */

            /*

            var uploadedFile = await service.Files.Get(uploadedFileId).ExecuteAsync();

            // Lets change the files name.
            // Note: not all fields are writeable watch out, you cant just send uploadedFile back.
            var updateFileBody = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "Update_Title.txt"
            };

            // Lets add some text to our file.
            await File.WriteAllTextAsync(UploadFileName, "Contenido del archivo cambiado.");

            // Then upload the file again with a new name and new data.
            await using (var uploadStream = new FileStream(UploadFileName, FileMode.Open, FileAccess.Read))
            {
                // Update the file id, with new metadata and stream.
                var updateRequest = service.Files.Update(updateFileBody, uploadedFile.Id, uploadStream, "text/plain");
                var result = await updateRequest.UploadAsync(CancellationToken.None);

                if (result.Status == UploadStatus.Failed)
                {
                    return BadRequest("Upload Failed 2");
                }
            }
            */

            try{
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user =  await _userRepositoy.GetUserByIdAsync(int.Parse(userId));

                // TODO:             
                //   Subir el archivo a GoogleDrive y optener un Uri
                //   Validar que los Item correspondan a la categoria.

                string root_path =  Path.Combine(Environment.CurrentDirectory, @"JsonFiles\");
                string strNow = DateTime.Now.ToString("yyyyMMdd"); // yyyyMMddHHmmss
                var jsonFilePath = string.Format("{0}{1}_{2}.csv",root_path,user.UserName, strNow);

                if (spesimen.file != null)
                {
                    using (var stream = System.IO.File.Create(jsonFilePath)){
                        // await file.CopyToAsync(stream);
                        spesimen.file.CopyTo(stream);
                    }
                }

                bool isFirstLine = true;
                var siList = new List<SpesimenItem>();
                var message = string.Empty;
                var messageItem = string.Empty;
                
                using (StreamReader rd = new StreamReader(jsonFilePath, Encoding.UTF8))                
                {
                    // new FileStream(jsonFilePath, FileMode.Open), Encoding.UTF8))
                    while (!rd.EndOfStream)
                    {
                        if (isFirstLine){
                            // Validaciones con los headers.
                            isFirstLine = false;
                            rd.ReadLine();
                            continue;
                        }
                        messageItem = string.Empty;

                        var si = new SpesimenItem();
                        var arrlst = rd.ReadLine().Split(';');
                        if (arrlst.Length == 1)
                        {
                            arrlst= arrlst[0].Split(',');
                        }
                        // Validar que el item este dado de alta. (En futuro validar "Area de Interes (InterestArea)")
                        if (string.IsNullOrEmpty(arrlst[0]))
                            break;
                        si.Item = _itemRepository.GetByName(arrlst[0]); // new Item() { Name = arrlst[0]};
                        if (si.Item == null) messageItem = string.Format("Item not found: {0}; ", arrlst[0]);                    
                        // Validar que la unidad este dada de alta. y que conicida con una relacionada con el Item.
                        si.Unit = _unitRepository.GetByName(arrlst[1]); // new Unit() { Name = arrlst[1]};
                        if (si.Unit == null) messageItem += string.Format("Unit not found: {0}", arrlst[1]);
                        if(string.IsNullOrEmpty(arrlst[2])) {
                            messageItem += string.Format("Value of Item: {0}", arrlst[0]);
                        } else {
                            si.Value = float.Parse(arrlst[2]);
                        }
                        
                        si.Method = arrlst[3];
                        si.LabName = arrlst[4];
                        si.Responsible = arrlst[5];
                        si.Preferent = arrlst[6] == "1" ? true : false ;
                        si.Notes = arrlst[7];

                        // Todo: Falta Validar que la unidad este acorde con el Item y poner la unidad Base con su valor
                        si.UnitBase = si.Unit;
                        si.ValueBase = si.Value;

                        if(!string.IsNullOrEmpty(messageItem)) {
                            message += messageItem;
                        } else {
                            
                            siList.Add(si);
                        }                    
                    }
                }
                
                if(!string.IsNullOrEmpty(message)) {
                    return  UnprocessableEntity(new MessageResponse("422",message));  //PreconditionFailed(message);
                }
                
                // Todo: Encontrar el punto antes de agregar la muestra.
                var sur = new Spesimen 
                {
                    PointId = spesimen.PointId,
                    SpesimenDate = spesimen.SpesimenDate,
                    // LocationLatLon = survey.LocationLatLon,
                    // LocationName = survey.LocationName, 
                    SpesimenItems = siList,
                    CDate = DateTime.Now,
                    CreatedById = user.Id,
                    Notes = spesimen.Notes                    
                };
                _spesimenRepository.Add(sur);

                _spesimenRepository.AddItemsRange(sur.SpesimenItems); //.Add(sur);

                await _spesimenRepository.SaveAllAsync();
  
                return Ok(new MessageResponse("200","File Uploaded"));//sur;
                
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Spesimen.Upload", JsonSerializer.Serialize(spesimen));
                return StatusCode(500,new MessageResponse());            
            }

        }

        [Authorize]
        [HttpPost()] // Post: api/survey
        public async Task<ActionResult<Spesimen>> Create(SpesimenI2DTO spesimen) 
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
                var user =  await _userRepositoy.GetUserByIdAsync(int.Parse(userId));

                var sur = new Spesimen();
                var sitem = new SpesimenItem();

                _mapper.Map(spesimen, sur);
                sur.SpesimenItems = new List<SpesimenItem>();

                var message = string.Empty;
                var messageItem = string.Empty;

                foreach (var item in spesimen.Items) {
                    messageItem = string.Empty;
                    sitem = new SpesimenItem();
                    _mapper.Map(item, sitem);
                    
                    // Todo: Falta Validar que la unidad este acorde con el Item y poner la unidad Base con su valor
                    sitem.UnitBaseId = sitem.UnitId;
                    sitem.ValueBase = sitem.Value;

                    if(!string.IsNullOrEmpty(messageItem)) {
                        message += messageItem;
                    } else {
                        
                        sur.SpesimenItems.Add(sitem);
                    }
                }

                sur.CDate = DateTime.Now;
                sur.CreatedById = user.Id;
                
                _spesimenRepository.Add(sur);

                _spesimenRepository.AddItemsRange(sur.SpesimenItems); //.Add(sur);

                await _spesimenRepository.SaveAllAsync();

                return Ok(new MessageResponse("200","Registed"));//sur;

            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Spesimen.Create", JsonSerializer.Serialize(spesimen));
                return StatusCode(500,new MessageResponse());            
            }                

        }

        [HttpGet()]        
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SpesimenDTO>>> GetSpesimens() 
        {
            try
            {

                var surs = await _spesimenRepository.GetAsync();
            
                return Ok(surs);

            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Spesimen.GetSpesimens", "");
                return StatusCode(500,new MessageResponse());  
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SpesimenDTO>>> GetSpesimen(int id) 
        {
            try
            {
                var surs = await _spesimenRepository.GetSpesimenDTOByIdAsync(id);
                
                return Ok(surs);

            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Spesimen.GetSpesimen", "ID: " + id.ToString());
                return StatusCode(500,new MessageResponse());
            }
        }

        [HttpGet("dashboard")]        
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SpesimenDashboardDTO>>> GetSpesimensDashboard() 
        {
            try
            {

                var surs = await _spesimenRepository.GetSpesimenDashboard();
            
                return Ok(surs);

            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Spesimen.GetSpesimensDashboard", "");
                return StatusCode(500,new MessageResponse());  
            }
        }

        /// <summary>
        /// Returns the last Spesimens by element ordered by laboratory of the point according to parameters and indicates the value according to the indicated quality control
        /// </summary>
        /// <param name="pointId">Point Id</param>
        /// <param name="dateC">Last date of spesimens</param>
        /// <param name="categoryId">Category Id</param>
        /// <param name="qsId">Quality Standar Id</param>
        /// <returns></returns>
        [HttpGet("lastInPoint/{pointId}/{dateC}/{categoryId}/{qsId}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SpesimensInPointDTO>>> SpesimensInPoint(int pointId, DateTime dateC, int categoryId, int qsId)
        {
            try
            {
                var sp = await _spesimenRepository.SpesimensInPoint(pointId, dateC, categoryId, qsId);
                
                return Ok(sp);

            } catch(Exception e) {
                var prm = string.Format("pointId: {0}; dateC: {1}; categoryId: {2}, qsId: {3}", pointId, dateC, categoryId, qsId);
                _logApi.Record(e.Message, e.StackTrace, "Spesimen.GetSpesimen", prm);
                return StatusCode(500,new MessageResponse());
            }
        }        
        
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(SpesimenIDTO spesimen, int id)
        {
            try
            {
                var speU = await _spesimenRepository.GetIdAsync(id);

                if (speU == null) return BadRequest(new MessageResponse("405","Spesimen not found"));
                
                _mapper.Map(spesimen,speU);
                    
                _spesimenRepository.Update(speU);

                await _spesimenRepository.SaveAllAsync();        

                return Ok(new MessageResponse("200","Spesimen Updated"));

            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Spesimen.Update",  " Id: " + id.ToString() + "; " + JsonSerializer.Serialize(spesimen) );
                return StatusCode(500,new MessageResponse());
            }             
        }
    }
}