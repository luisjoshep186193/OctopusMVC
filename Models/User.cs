using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class User: IdentityUser
    {
        public string Nombre { get; set; }
        [DisplayName("Creado Por")]
        public string CreatedBy { get; set; }
        public string UserDesc
        {
            get
            {
                return string.Format("{0} - {1}", Nombre, PhoneNumber);
            }
        }
       public int? CarteraId { get; set; }
        [Required]
        [Display(Name = "Comisión")]

        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Asigna una Comisión entre 1 y 7")]
        public double ComisionTAE { get; set; }
        public string Rol { get; set; }
        public string PasswordToken { get; set; }
        public Cartera Cartera { get; set; }
    }
}
