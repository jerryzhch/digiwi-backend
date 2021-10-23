using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Models
{
    public class KeywordMatch
    {
        public string Keyword { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
    }
}
