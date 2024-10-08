namespace Proje.EntityFramework.Models
{
    public class Product : Base
    {
        public int? SubGroupId { get; set; }
        public string? Brand { get; set; }
        public int? Stock { get; set; }
    }

}
