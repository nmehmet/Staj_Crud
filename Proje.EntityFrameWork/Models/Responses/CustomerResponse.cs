using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityFramework.Models.Responses
{
    public class CustomerResponse : BaseResponse
    {
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Birthdate { get; set; }
    }
}
