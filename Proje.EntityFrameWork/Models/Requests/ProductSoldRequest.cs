using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityFramework.Models.Requests
{
    public class ProductSoldRequest
    {
        public int SoldProductId { get; set; }
        public int Quanity {  get; set; }
    }
}
