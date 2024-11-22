using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Responses
{
    public class OutputResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public object Message { get; set; }
        public T Model { get; set; }
        public List<ErrorModel> Errors { get; set; } = new();
    }
}
