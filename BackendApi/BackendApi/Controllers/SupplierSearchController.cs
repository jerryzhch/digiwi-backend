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

        [HttpGet("byTag")]
        public Supplier[] GetByTag([FromBody] string[] tags)
        {
            return supplier;
        }

        [HttpGet("byFreeText")]
        public Supplier[] GetByFreeText([FromBody] string freeText)
        {
            return supplier;
        }
    }
}
