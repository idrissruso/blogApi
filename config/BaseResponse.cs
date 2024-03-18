using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Config
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }

        public Response(T data, string message, bool success, int statusCode)
        {
            Data = data;
            Message = message;
            Success = success;
            StatusCode = statusCode;
        }

        public Response(T data, string message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        public Response(T data, bool success)
        {
            Data = data;
            Success = success;
        }

        public Response(T data, int statusCode)
        {
            Data = data;
            Message = "OK";
            StatusCode = statusCode;
            Success = statusCode is >= 200 and < 300;
        }

        public Response(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
            Success = statusCode is >= 200 and < 300;
        }

        public Response()
        {
        }
    }



}