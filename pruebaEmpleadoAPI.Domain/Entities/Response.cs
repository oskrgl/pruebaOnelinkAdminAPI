﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaEmpleadoAPI.Domain.Entities
{
    public class Response<T>
    {
        public bool status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
