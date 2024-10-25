using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class DocumentDTO
    {
        public string Title { get; set; }
        public string DocType { get; set; }
        public string Description { get; set; }
        public string Abstrac { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsPublisher { get; set; }
        
        // public Stream FileSt { get; set; }
    }
}