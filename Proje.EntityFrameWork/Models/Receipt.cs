using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityFramework.Models
{
    public class Receipt : Base
    {
        public int? BuyerId { get; set; }
        public int? Quanity {  get; set; }
    }
}
