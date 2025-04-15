using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;
        public CommentsController(CommentContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CommentList()
        { 
            var values =_context.UserComments.ToList();
            return Ok(values);
        }
    }
}
