using AplikimiDigjital.Entities;
using AplikimiDigjital.Models;
using AplikimiDigjital.Repositories.Interfaces;
using AplikimiDigjital.Services.Interfaces;
using AutoMapper;

namespace AplikimiDigjital.Services
{
    public class CommentService : ICommentService{

        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;


        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public Comment CreateComment(Comment comment)
        {
            var commentEntity = _mapper.Map<CommentEntity>(comment);
            var result = _commentRepository.CreateComment(commentEntity);
            var commentCreated = _mapper.Map<Comment>(comment);
            return commentCreated;
        }

        public void DeleteComment(int id)
        {
            _commentRepository.DeleteComment(id);
        }

        public List<Comment> GetAllComment()
        {
            var commentEntity = _commentRepository.GetAllComments();
            var comment = _mapper.Map<List<Comment>>(commentEntity);
            return comment;
        }

        public Comment GetCommentById(int id)
        {
            var commmentEntiry = _commentRepository.GetCommentById(id);
            var comment = _mapper.Map<Comment>(commmentEntiry);
            return comment;
        }

        public void UpdateComment(Comment comment)
        {
            try
            {
                var commentEntity = _mapper.Map<CommentEntity>(comment);
                _commentRepository.UpdateComment(commentEntity);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
