using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityFramework.Models.Responses
{
    public class ReceiptResponse : BaseResponse
    {
        public int BuyerId { get; set; }
        public int Quanity {  get; set; }
    }
}
