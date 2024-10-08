using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityFramework.Models.Requests
{
    public class CustomerRequest : BaseRequest
    {
        public string? Email {  get; set; }
        public string? Telephone { get; set; }
        public string? Birthdate { get; set; }
    }
}
