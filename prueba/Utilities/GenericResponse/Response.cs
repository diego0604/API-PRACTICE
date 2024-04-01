using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.GenericResponse
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public int Code { get; set; }
        public int Count { get; set; }
        public Exception Error { get; set; } = null!;

        public object? Object { get; set; }
    }
}
