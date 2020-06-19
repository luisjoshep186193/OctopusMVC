using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Octopus.Models
{
    public class Image
    {
        public int Id { get; set; }
        [DisplayName("Nombre de la Imagen")]
        public string ImageName { get; set; }
        public string URL { get; set; }
        public int PTypeId {get; set; }
        public string AssetId { get; set; }
        public PType PType { get; set; }
        
        public IFormFile File { get; set; }
    }
}
