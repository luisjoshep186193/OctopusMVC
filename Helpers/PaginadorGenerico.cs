using System;
using System.Collections.Generic;

namespace Octopus.Helpers
{
    public class PaginadorGenerico<T> where T : class
    {
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public List<T> Resultado { get; set; }
    }
}
