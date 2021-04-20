using System;
using System.Collections.Generic;
using System.Text;

namespace Aga.DTO
{
    public class ResultErrorDTO : ResultDTO
    {
        public List<string> Errors { get; set; }
    }
}