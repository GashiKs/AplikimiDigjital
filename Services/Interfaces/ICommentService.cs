    using AplikimiDigjital.Models;

namespace AplikimiDigjital.Services.Interfaces
{
    public interface ICommentService
    {
        public Comment CreateComment(Comment comment);
        public void UpdateComment(Comment comment);
        public void DeleteComment(int id);
        public Comment GetCommentById(int id);
        public List<Comment> GetAllComment();
    }
}
