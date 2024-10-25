using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Point // Location
    {  // Points
        [Key]
        public int PointId { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// Nota: La info se debe entregar como: Lon Lat (osea un espacio en blanco entre los dos)
        ///    Google Maps entrega las coordenadas como: Lag, Lon 
        ///    Hay que tener cuidado al alimentar los datos.
        /// </summary>
        // public string LatLon { get; set; }
        // De Norte-Sur (Gajos) (verticales)
        public float Lat { get; set; }
        // De Este-Oeste (Rodajas) (horizontales)
        public float Lon { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public string URLImage { get; set; }
        [MaxLength(350)]
        public string Description { get; set; }
        [MaxLength(350)]
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        // public InterestArea InterestArea { get; set; }
        // public SubCategory SubCategory { get; set; }
        /// <summary>
        /// Agrupador por Ciudad o algo similar
        /// </summary>
        public Place Place { get; set; }

        // Relationship
        public int PlaceId { get; set; }
        public List<Spesimen> Spesimens { get; set; }

    }
}