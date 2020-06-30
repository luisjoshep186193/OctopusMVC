using System;
using System.ComponentModel;

namespace Octopus.Models
{
    public class Cartera
    {
        
        public int Id { get; set; }
        [DisplayName("Saldo TAE")]
        public double SaldoTAE { get; set; }
        [DisplayName("Saldo Global")]
        public double SaldoNormal { get; set; }
        [DisplayName("Comisión TAE")]
        public double? ComisionTAE { get; set; }
        [DisplayName("Asignado")]
        public double? Asignado { get; set; }
        [DisplayName("Inicial")]
        public double? Inicial { get; set; }
        [DisplayName("Venta")]
        public double? Venta { get; set; }
        [DisplayName("Enviado")]
        public double? Enviado { get; set; }
        public double CuotaServicios { get; set; }
        public int UserLevel { get; set; }
        public DateTime DateReset { get; set; }
        

        public string OwnerId { get; set; }
        public string FatherId { get; set; }
    }
}
