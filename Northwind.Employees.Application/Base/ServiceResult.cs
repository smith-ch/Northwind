﻿namespace Northwind.Employees.Application.Base
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Success = true;
        }
        
        public string? Message { get; set; }
        public bool Success { get; set; }
        public dynamic? Result { get; set; }
    }
       
}
