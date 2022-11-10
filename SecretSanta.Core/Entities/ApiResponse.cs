using System;
namespace SecretSanta.Core.Entities
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        
    }
}

