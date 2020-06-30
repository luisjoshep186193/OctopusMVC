using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Helpers
{
    public class PaginadorGenerico<T> where T : class
    {
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public List<T> Resultado { get; set; }

        public PaginadorGenerico(List<T> query, int pageNumber, int pageSize, int count)
        {
            TotalRegistros = count;
            RegistrosPorPagina = pageSize;
            PaginaActual = pageNumber;
            TotalPaginas = (int)Math.Ceiling(TotalRegistros / (double)RegistrosPorPagina);
            Resultado = new List<T>();
            Resultado.AddRange(query.ToList());
        }

        public static object Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 20 : pageSize;
            var count = pageSize != 3 && pageSize != 10 ? source.Count(): 1;
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginadorGenerico<T>(items, pageNumber, pageSize, count);

        }
    }
}
