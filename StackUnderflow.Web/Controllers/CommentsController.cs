using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Business;
using StackUnderflow.Entities;

namespace StackUnderflow.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _cs;

        public CommentsController(CommentService cs)
        {
            _cs = cs;
        }

        // GET: api/Comments
        [HttpGet]
        public IEnumerable<Comment> GetComments()
        {
            return _cs.GetAllComments();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            return Ok(_cs.FindCommentById(id));
        }

        // GET: api/Comments/5
        [HttpGet("{responseId}")]
        public async Task<IActionResult> GetCommentByResponseId([FromRoute] int responseId)
        {
            return Ok(_cs.GetCommentsByResponse(responseId));
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment([FromRoute] int id, [FromBody] Comment comment)
        {
            _cs.EditComment(comment);
            return NoContent();
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody] Comment comment)
        {
            Comment commentToAdd = _cs.AddComment(comment.ResponseId, comment.Text, comment.CommentedBy);
            return NoContent();
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            _cs.DeleteComment(_cs.FindCommentById(id));
            return Ok();
        }
    }
}