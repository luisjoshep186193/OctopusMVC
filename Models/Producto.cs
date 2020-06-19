using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Octopus.Models
{
    public class Producto
    {
      
        public int Id { get; set; }
        [DisplayName("Nombre del Elemento")]
        public string ProductName { get; set; }
        public double Stock { get; set; }
        public double Ventas { get; set; }
        public string Description { get; set; }
        public string Codigo { get; set; }
        public string Hastags { get; set; }
        public DateTime DateCreated { get; set; }
        public string Thumbnail { get; set; }
        [DisplayName("Tipo de Elemento")]
        public int PTypeId { get; set; }
        public PType PType { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        [DisplayName("Ubicación en carpeta")]
        public int CarpetaId { get; set; }
        
        public IFormFile File { get; set; }
    }
}
