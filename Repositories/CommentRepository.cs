using AplikimiDigjital.Context;
using AplikimiDigjital.Entities;
using AplikimiDigjital.Repositories.Interfaces;

namespace AplikimiDigjital.Repositories
{
    public class CommentRepository: ICommentRepository
    {
        private readonly AppDbContext _dbContext;
        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CommentEntity CreateComment(CommentEntity comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
            return comment;
        }
        public CommentEntity GetCommentById(int id)
        {
            return _dbContext.Comments.Find(id);
        }
        public List<CommentEntity> GetAllComments()
        {
            return _dbContext.Comments.ToList();
        }
        public void UpdateComment(CommentEntity comment)
        {
            var oldComment = _dbContext.Comments.Find(comment.ID);
            _dbContext.Entry(oldComment).CurrentValues.SetValues(comment);
            _dbContext.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            var comment = _dbContext.Comments.Find(id);
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }  
    }
}
