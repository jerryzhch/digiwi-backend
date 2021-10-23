using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Models
{
    public class Solution
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public int Rating { get; set; }
        public string[] Keywords { get; set; }
        public string ImageUrl { get; set; }
        public bool IsTool { get; set; }
    }
}
