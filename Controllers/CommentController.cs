using AplikimiDigjital.Models;
using AplikimiDigjital.Services.Interfaces;
using AplikimiDigjital.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AplikimiDigjital.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("GetAllComment")]
        public List<Comment> GetAllComment()
        {
            var result = _commentService.GetAllComment();
            return result;
        }

        [HttpGet("GetCommentById/{id}")]
        public Comment GetCommentById(int id)
        {
            var comment = _commentService.GetCommentById(id);
            return comment;
        }

        [HttpPost("CreateComment")]
        public IActionResult CreateComment(Comment comment)
        {
            var validator = new CommentValidator();
            var validationResult = validator.Validate(comment);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdComment = _commentService.CreateComment(comment);
            return Ok(createdComment);
        }

        [HttpPut("UpdateComment/{id}")]
        public IActionResult UpdateComment(int id, Comment comment)
        {
            var validator = new CommentValidator();
            var validationResult = validator.Validate(comment);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            try
            {
                var oldComment = _commentService.GetCommentById(id);
                if (oldComment == null)
                {
                    return NotFound();
                }
                _commentService.UpdateComment(comment);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            try
            {
                var deletedComment = _commentService.GetCommentById(id);
                if (deletedComment == null)
                {
                    return NotFound();
                }
                _commentService.DeleteComment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
