using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Responses
{
    public class OutputResponseForValidationFilter
    {
        [NotNull]
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public object Message { get; set; }
        public object Model { get; set; }
        public List<ErrorModel> Errors { get; set; } = new();
    }

    public class ErrorModel
    {
        public string Property { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
    }
}
