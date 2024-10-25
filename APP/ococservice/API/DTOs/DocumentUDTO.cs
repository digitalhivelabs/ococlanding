using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class DocumentUDTO
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string DocType { get; set; }
        public string Description { get; set; }
        public string Abstrac { get; set; }
        public string Author { get; set; }        
        public DateTime PublicationDate { get; set; }
        public bool IsPublisher { get; set; }        
              
    }
}