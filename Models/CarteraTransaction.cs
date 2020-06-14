using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Octopus.Models
{
    public class CarteraTransaction
    {

        public int Id { get; set; }
        [DisplayName("Operación"), Required]
        public string OperacionDesc { get; set; }
        public string CarrierResponse { get; set; }
        [Required]
        public double Monto { get; set; }
        public DateTime FechaOperation { get; set; }
        public int CarteraId { get; set; }
        public Cartera Cartera { get; set; }

    }
}
