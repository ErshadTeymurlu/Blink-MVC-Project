namespace Blink.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public List<BlogPost> Posts { get; set; }
    }
}
