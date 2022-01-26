using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaEmpleadoAPI.Domain.Entities
{
    public class Result<T>
    {
        public T result { get; set; }
        public string message { get; set; }
    }
}
