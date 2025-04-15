namespace MultiShop.Comment.Entities
{
    public class UserComment
    {
        public int UserCommentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating{ get; set; }
        public bool CommentStatus { get; set; }
        public string ProductId { get; set; }
    }
}
