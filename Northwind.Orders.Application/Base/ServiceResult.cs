﻿
namespace Northwind.Orders.Application.Base
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Success = true;
        }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public dynamic? Result { get; set; }
    }
}
