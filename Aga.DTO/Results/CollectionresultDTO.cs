using System;
using System.Collections.Generic;
using System.Text;

namespace Aga.DTO.Results
{
    public class CollectionresultDTO
    {
        public class CollectionResultDto<T> : ResultDTO
        {
            public ICollection<T> Data { get; set; }
        }
    }
}
