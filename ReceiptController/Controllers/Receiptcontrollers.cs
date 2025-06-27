using Microsoft.AspNetCore.Mvc;
using ReceiptCommon;
using ReceiptLogic;
using System.Collections.Generic;

namespace ReceiptTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly ReceiptService _service = new ReceiptService();

        [HttpGet]
        public ActionResult<IEnumerable<DBinfos>> GetAll()
        {
            var list = _service.GetAll();
            return Ok(list);
        }

        [HttpPost]
        public ActionResult Add([FromBody] DBinfos receipt)
        {
            if (_service.Add(receipt))
                return Ok("New receipt saved.");
            return BadRequest("Could not save receipt.");
        }

        [HttpPatch("{invoice}")]
        public ActionResult Update(int invoice, [FromBody] DBinfos receipt)
        {
            if (_service.Update(invoice, receipt))
                return Ok("Receipt updated successfully.");
            return NotFound("Receipt not found.");
        }

        [HttpDelete("{invoice}")]
        public ActionResult Delete(int invoice)
        {
            if (_service.Remove(invoice))
                return Ok("Receipt removed.");
            return NotFound("Invoice does not exist.");
        }
    }
}
