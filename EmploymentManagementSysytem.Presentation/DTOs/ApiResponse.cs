using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmploymentManagementSysytem.Presentation.DTOs
{
    public class ApiResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public object Data { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);

        public ApiResponse(string message = null)
        {
            Succeeded = true;
            Message = message;
        }

        public static ApiResponse Success(object data)
        {
            return new ApiResponse { Succeeded = true, Message = "Success", Data = data };
        }

        public static ApiResponse Failure(string message = "Failure", List<string> errors = null)
        {
            return new ApiResponse { Message = message, Errors = errors };
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
        public ApiResponse() { }
        public static ApiResponse<T> Success(T data, string message)
        {
            return new ApiResponse<T> { Succeeded = true, Message = message };
        }

        public static ApiResponse<T> Failure(T data, string message = null, List<string> errors = null)
        {
            return new ApiResponse<T> { Data = data, Message = message, Errors = errors };
        }

        public ApiResponse(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
    }
}
