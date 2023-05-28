using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public partial class VehiclesType
    {
        [Key]
        public int TypeId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal? CapacityKg { get; set; }
        public decimal? CapacityM3 { get; set; }
    }
}
