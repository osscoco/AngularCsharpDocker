﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePassProtectIIA.Models
{
    public class ResponseApi
    {
        public bool? Success { get; set; }
        public object? Data { get; set; }
        public string? Message { get; set; }
        public ResponseApi() { }
    }
}
