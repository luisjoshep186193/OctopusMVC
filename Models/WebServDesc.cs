using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class WebServDesc
    {
        public int Id { get; set; }
        [DisplayName("WebServer")]
        public string WebServiceName { get; set; }
        public string URL { get; set; }
  
    }
}
