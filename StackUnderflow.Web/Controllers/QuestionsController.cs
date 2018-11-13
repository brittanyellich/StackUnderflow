using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.Business;
using StackUnderflow.Data;
using StackUnderflow.Entities;

namespace StackUnderflow.Web.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionService _svc;

        public QuestionsController(QuestionService svc)
        {
            _svc = svc;
        }

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<Question> GetQuestions()
        {

            Console.WriteLine("Got into the controller!");
            return _svc.GetAllQuestions();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion([FromRoute] int id)
        {
            return Ok(_svc.FindQuestionById(id));
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion([FromRoute] string id, [FromBody] Question question)
        {
            _svc.EditQuestion(question, id);
            return NoContent();
        }
        // PUT: api/Questions/5
        [HttpPut("{id}/up")]
        public async Task<IActionResult> UpvoteQuestion([FromRoute] string id, [FromBody] Question question)
        {
            _svc.UpvoteQuestion(question, id);
            return NoContent();
        }
        [HttpPut("{id}/up")]
        public async Task<IActionResult> DownvoteQuestion([FromRoute] string id, [FromBody] Question question)
        {
            _svc.DownvoteQuestion(question, id);
            return NoContent();
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] Question question)
        {
            _svc.AddQuestion(question.Text, question.Topic, question.AskedBy);
            return NoContent();
        }
        

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {
            var question = _svc.FindQuestionById(id);
            _svc.DeleteQuestion(question);
            return Ok(question);
        }
    }
}