using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Documento
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string DocType { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [MaxLength(350)]
        public string Abstrac { get; set; }
        [MaxLength(150)]
        public string Author { get; set; }
        public string Url { get; set; }
        public DateTime? PublicationDate { get; set; }
        public bool IsPublisher { get; set; }
        public User UserUploader { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? MDate { get; set; }

        // public User UserMDate { get; set; }


        // RelationShip
        public int UserUploaderId { get; set; }
        // public int UserMDateId { get; set; }

    }
}