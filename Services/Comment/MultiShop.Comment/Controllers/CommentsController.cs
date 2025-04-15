﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

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
            var values = _context.UserComments.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment userComment) {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Comment Created Successfully");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Comment Updated Successfully");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int Id) {
            var value = _context.UserComments.Find(Id);
            if (value == null)
            {
                return NotFound();
            }
            _context.UserComments.Remove(value);
            _context.SaveChanges();
            return Ok("Comment Deleted Successfully");
        }
        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var value = _context.UserComments.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
    }
}
