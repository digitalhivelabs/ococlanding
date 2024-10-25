using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.StoreProcedureReturn
{
    [Keyless]
    public class GetSubCategoriesAndPointsSPR
    {
        public int id { get; set; }
        public string name { get; set; }
        public int PlaceId { get; set; }
        public string DisplayName { get; set; }
        public string URLImage { get; set; }
        public string Distance { get; set; }
        public int NumPoints { get; set; }
    }
}