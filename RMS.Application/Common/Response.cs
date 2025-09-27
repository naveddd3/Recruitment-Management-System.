using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Application.Common
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = "";
        public T? Data { get; set; }

        public static Response<T> Success(T data, string message = "Success")
        {
            return new Response<T> { IsSuccess = true, Message = message, Data = data };
        }

        public static Response<T> Fail(string message)
        {
            return new Response<T> { IsSuccess = false, Message = message, Data = default };
        }
    }
}
