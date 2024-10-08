using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityFramework.Models
{
    public  class ReceiptView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public int Quanity { get; set; }
    }
}
