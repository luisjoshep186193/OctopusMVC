using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Monto
    { 

        public int Id { get; set; }
        [DisplayName("Monto")]
        public int MontoCant { get; set; }
        [DisplayName("Compañía")]
        public int CarrierId { get; set; }

        public Carrier Carrier { get; set; }
        public string MontoDesc
        {
            get
            {
                return string.Format("${0}.00 - {1}", MontoCant, Carrier.CarrierName);
            }
        }
    }
}
