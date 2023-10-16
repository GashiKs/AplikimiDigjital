using AplikimiDigjital.Entities;

namespace AplikimiDigjital.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        public CommentEntity CreateComment(CommentEntity comment);
        public void UpdateComment(CommentEntity comment);
        public void DeleteComment(int id);
        public CommentEntity GetCommentById(int id);
        public List<CommentEntity> GetAllComments();
        
    }
}
