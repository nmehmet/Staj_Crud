using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityFramework.Models.Responses
{
    public class ReceiptBuyResponse
    {
        public int Quanity {  get; set; }
        public int BuyerId { get; set; }
        public string Name { get; set; }
    }
}
