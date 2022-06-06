namespace Blink.Models
{
    public class BlogPost : BaseEntity
    {
        public string ImgPath { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string hint { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
