using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Octopus.Models
{
    public class Folder
    {
        public int Id { get; set; }
        [DisplayName("Nombre del Folder"), Required]
        public string FolderName { get; set; }
        public int ParentId { get; set; }
        public string UserOwner { get; set; }
        [Required]
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}
