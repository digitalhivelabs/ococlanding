using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Interfaces;
using System.Security.Claims;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using AutoMapper;
using System.Text.Json;



namespace API.Controllers
{
    [Authorize]
    public class DocumentController : BaseApiController
    {
        
        private readonly IDocRepository _docRepository;
        private readonly IMapper _mapper;
        private readonly ILogApi _logApi;

        public DocumentController(IDocRepository docRepository, IMapper mapper, ILogApi logApi)
        {
            _docRepository = docRepository;
            _mapper = mapper;
            _logApi = logApi;
        }

        [HttpPost("upload")] // Post: api/document/upload
        public async Task<ActionResult<Documento>> Upload([FromForm] DocumentIDTO document) 
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


            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // TODO:             
                //   Subir el archivo a GoogleDrive y optener un Uri
                string root_path =  Path.Combine(Environment.CurrentDirectory, @"Archivos\");
                string strNow = DateTime.Now.ToString("yyyyMMdd"); // yyyyMMddHHmmss
                var jsonFilePath = "";

                if (document.File != null)
                {
                    // var jsonFilePath = string.Format("{0}{1}_{2}.csv",root_path, document.file.FileName, strNow);
                    jsonFilePath = string.Format("{0}{1}", root_path, document.File.FileName);
                    using (var stream = System.IO.File.Create(jsonFilePath)) {
                        // await file.CopyToAsync(stream);
                        document.File.CopyTo(stream);
                    }
                }

                var doc = new Documento 
                {
                    Title = document.Title, 
                    Author = document.Author,
                    Abstrac = document.Abstrac,
                    Description = document.Description,
                    DocType = document.DocType,
                    IsPublisher = document.IsPublisher, 
                    PublicationDate = document.PublicationDate,
                    UploadDate = DateTime.Now,
                    Url = jsonFilePath,
                    UserUploaderId = int.Parse(userId)
                };

                _docRepository.Add(doc);

                await _docRepository.SaveAllAsync();

                return doc;
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Document.Upload", JsonSerializer.Serialize(document));
                return StatusCode(500,new MessageResponse());            
            }

        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Documento>>> GetDocuments() 
        {
            try
            {

                var docs = await _docRepository.GetDocumentsAsync();
                //var usersToReturn = _mapper.Map<IEnumerable<UserDTO>>(users);

                return Ok(docs);
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Document.GetDocuments", "");
                return StatusCode(500,new MessageResponse());            
            }
        }      

        [HttpPut()]
        public async Task<ActionResult<Documento>> UpdateDocuments(DocumentUDTO document) 
        {
            try
            {
                var doc = await _docRepository.GetIdAsync(document.Id);//document.Id);
                if (doc == null) {
                    return BadRequest(new MessageResponse("405","Document not found"));
                }

                _mapper.Map(document, doc);
                doc.MDate = DateTime.Now;
                _docRepository.Update(doc);
                await _docRepository.SaveAllAsync();
                //var usersToReturn = _mapper.Map<IEnumerable<UserDTO>>(users);

                return Ok(doc);
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Document.UpdateDocuments", JsonSerializer.Serialize(document));
                return StatusCode(500,new MessageResponse());            
            }                
        }    
       
    }
}