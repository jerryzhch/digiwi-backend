using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierSearchController : ControllerBase
    {
        Supplier[] supplier = MockData.GetSuppliers();
        List<Solution> supplier = MockData.GetSuppliers();

        [HttpGet("byKeyWord")]
        public List<Solution> GetByKeyWord([FromBody] string[] keyWords)
        {
            return supplier;
        }

        [HttpGet("byFreeText")]
        public List<Solution> GetByFreeText([FromBody] string freeText)
        {
            return supplier;
        }


    }
}
