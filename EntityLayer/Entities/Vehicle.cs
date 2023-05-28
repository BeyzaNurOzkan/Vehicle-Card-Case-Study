using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public partial class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Plate { get; set; }
        public int? TypeId { get; set; }
        public int? ModelYear { get; set; }
        public string Color { get; set; }
    }
}
