﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Implementation
{
    public class ServiceResult<T>
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
