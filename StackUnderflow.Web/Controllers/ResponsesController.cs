using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.Business;
using StackUnderflow.Data;
using StackUnderflow.Entities;

namespace StackUnderflow.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsesController : ControllerBase
    {
        private readonly ResponseService _responseService;

        public ResponsesController(ResponseService responseService)
        {
            _responseService = _responseService;
        }

        // GET: api/Responses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResponse([FromRoute] int id)
        {
            return Ok(_responseService.GetResponsesByQuestionId(id));
        }

        // POST: api/Responses
        [HttpPost]
        public async Task<IActionResult> PostResponse([FromBody] string text, string userId, int questionId)
        {
            return Ok(_responseService.AddResponse(text, userId, questionId));
        }
        
        // Mark as inappropriate
        [HttpPost]
        public async Task<IActionResult> Inappropriate([FromBody] int id)
        {
            return Ok(_responseService.MarkResponseAsInappropriate(id));
        }
        
        // Mark as solution
        [HttpPost]
        public async Task<IActionResult> Solution([FromBody] int id)
        {
            return Ok(_responseService.MarkResponseAsSolution(id));
        }

        // DELETE: api/Responses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse([FromRoute] int id)
        {
            return Ok(_responseService.DeleteResponse(id));
        }
    }
}