using System.Net;

namespace Compugraf.Api.Models
{
    public class ResponseModel<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public ResponseModel(HttpStatusCode statusCode, T data, string message)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }
    }
}
