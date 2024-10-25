using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    // Agrupador por Ciudad o algo similar.
    public class Place
    {
        [Key]
        public int PlaceID { get; set; }
        [MaxLength(250)]
        public string Name { get; set;}
        [MaxLength(350)]
        public string Description { get; set; }
        public string URLImage { get; set; }
        // <summary>
        // Nota: La info se debe entregar como: Lat Long (osea un espacio en blanco entre los dos)
        //    Google Maps entrega las coordenadas como: Log,Lat 
        //    Hay que tener cuidado al alimentar los datos.
        // </summary>
        // public string LatLon { get; set; }   
        
        // De Norte-Sur (Gajos)
        public float Lat { get; set; }
        // De Este-Oeste (Rodajas)
        public float Lon { get; set; }
        public SubCategory SubCategory { get; set; }
        public State State { get; set; }

        // RelationShip
        public int SubCategoryId { get; set; }
        public int StateId { get; set; }
        public List<Point> Points { get; set; }
    }
}