using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityFramework.Models.Requests
{
    public class ReceiptRequest:BaseRequest
    {
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public int Quanity {  get; set; }
    }
}
