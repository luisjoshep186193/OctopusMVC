using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class UsuarioRegion
    {
        public int Id { get; set; }
        [DisplayName("Region")]
        public int RegionId { get; set; }
        [DisplayName("Usuario")]
        public string UserId { get; set; }
        [DisplayName("Comisión TAE")]
        [Required]
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Asigna una Comisión entre 1 y 7")]
        public double Comision { get; set; }
        [DisplayName("Activo")]
        public bool Status { get; set; }
        public User User { get; set; }
        public Region Region { get; set; }
    }
}
