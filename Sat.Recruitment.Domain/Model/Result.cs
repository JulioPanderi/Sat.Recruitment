using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Api.Domain.Model
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}
