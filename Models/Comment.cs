namespace Blink.Models
{
    public class Comment:BaseEntity
    {
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string CommentText { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost Post { get; set; }
    }
}
