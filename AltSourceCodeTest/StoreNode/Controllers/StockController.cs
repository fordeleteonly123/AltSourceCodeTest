using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using UseCase;

namespace StoreNode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // Manually creating object rather than using object dependency injection
        // to reduce complex of code base
        // and increase code readability and maintenance
        StoreLogic _storeLogic = StoreLogic.GetSingletonStore();

        [HttpPost]
        public void Clothing([FromBody] Clothing item)
        {
            _storeLogic.Register(item);
        }

        [HttpPost]
        public void StockIn([FromBody] StockInRecord record)
        {
            _storeLogic.RecordClothingFromSupplier(record);
        }

        [HttpPost]
        public void StockOut([FromBody] StockOutRecord record)
        {
            _storeLogic.RecordSellingClothingToSupplier(record);
        }

        [HttpGet]
        public ActionResult<int> CurrentStock(int id)
        {
            return _storeLogic.GetCurrentStock(id);
        }
    }
}
