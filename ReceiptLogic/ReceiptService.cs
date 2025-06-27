using System.Collections.Generic;
using ReceiptCommon;
using ReceiptDataLayer;

namespace ReceiptLogic
{
    public class ReceiptService
    {
        private readonly DBReceiptinfo data = new DBReceiptinfo();

        public List<DBinfos> GetAll() => data.GetAllRecieptInfos();

        public bool Add(DBinfos receipt) => data.AddReceipt(receipt);

        public bool Update(int invoice, DBinfos updated)
        {
            var existing = data.GetInvoice(invoice);
            if (existing == null) return false;

            updated.invoice = invoice; 
            return data.UpdateReceipt(updated); //call yung updatereceipt if tru
        }

        public bool Remove(int invoice) => data.DeleteReceipt(invoice);
    }
}
