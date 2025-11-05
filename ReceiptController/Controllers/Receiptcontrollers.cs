using Microsoft.AspNetCore.Mvc;
using ReceiptCommon;
using ReceiptLogic;
using recieptlogicemail;
using System.Collections.Generic;

namespace ReceiptTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly ReceiptService _service; // for database
        private readonly ReceiptEmailService _emailService; // for mailtrap

        public ReceiptController(ReceiptService service, ReceiptEmailService emailService)
        {
            _service = service;
            _emailService = emailService;
        }

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
            {
                // send notifs in the mailtrap
                _emailService.SendEmail(new ReceiptEmail
                {
                    ToEmail = "Vincesmoke666@gmail.com",
                    Subject = "New Receipt Added",
                    Body = $"A new receipt has been added:\nInvoice: {receipt.invoice}\nBrand: {receipt.brand}\nAddress: {receipt.address}\nAmount: {receipt.amount}nTin: {receipt.tin}"
                });

                return Ok("New receipt saved and email notification sent.");
            }

            return BadRequest("Could not save receipt.");
        }

        [HttpPatch("{invoice}")]
        public ActionResult Update(int invoice, [FromBody] DBinfos receipt)
        {
            if (_service.Update(invoice, receipt))
            {
                _emailService.SendEmail(new ReceiptEmail
                {
                    ToEmail = "Vincesmoke666@gmail.com",
                    Subject = "Receipt Updated",
                    Body = $"Receipt #{invoice} has been successfully updated."
                });

                return Ok("Receipt updated successfully and notification sent.");
            }

            return NotFound("Receipt not found.");
        }

        [HttpDelete("{invoice}")]
        public ActionResult Delete(int invoice)
        {
            if (_service.Remove(invoice))
            {
                _emailService.SendEmail(new ReceiptEmail
                {
                    ToEmail = "Vincesmoke666@gmail.com",
                    Subject = "Receipt Removed",
                    Body = $"Receipt #{invoice} has been deleted from the system."
                });

                return Ok("Receipt removed and email notification sent.");
            }

            return NotFound("Invoice does not exist.");
        }
    }
}
