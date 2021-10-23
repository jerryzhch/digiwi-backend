using BackendApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi
{
    public static class MockData
    {
        public static List<Solution> GetSuppliers()
        {
            List<Solution> suppliers = new List<Solution>();
            suppliers.Add(new Solution
            {
                Name = "TEst",
                Address = "Holtzweg 69",
                Rating = 5,
                Keywords = new string[] { "communication" },
                ImageUrl = "www.thisisjustastest.gg"

            });
            return suppliers;
        }
    }
}
