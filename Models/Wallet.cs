using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        [DisplayName("Saldo TAE")]
        public double SaldoTAE { get; set; }
        [DisplayName("Saldo Global")]
        public double SaldoNormal { get; set; }
        [DisplayName("Usuario")]
        public string UserId { get; set; }
        public double CuotaServicios { get; set; }
        [DisplayName("Comisión TAE")]
        public double? ComisionTAE { get; set; }
        public User User { get; set; }

    }
}
