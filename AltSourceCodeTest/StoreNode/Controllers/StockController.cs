using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using UseCase;

namespace StoreNode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // Manually creating object rather than using object dependency injection
        // to reduce complex of code base
        // and increase code readability and maintenance
        StoreLogic _storeLogic = StoreLogic.GetSingletonStore();

        [HttpPost]
        [ActionName("Clothing")]
        public void Clothing([FromBody] Clothing item)
        {
            _storeLogic.Register(item);
        }

        [HttpPost]
        [ActionName("In")]
        public void In([FromBody] StockInRecord record)
        {
            _storeLogic.RecordClothingFromSupplier(record);
        }

        [HttpPost]
        [ActionName("Out")]
        public void Out([FromBody] StockOutRecord record)
        {
            _storeLogic.RecordSellingClothingToSupplier(record);
        }

        [HttpGet]
        [ActionName("Current")]
        [Route("{id}")]
        public ActionResult<int> Current(int id)
        {
            return _storeLogic.GetCurrentStock(id);
        }
    }
}
