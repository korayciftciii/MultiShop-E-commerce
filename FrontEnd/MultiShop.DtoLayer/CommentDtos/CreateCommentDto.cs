using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CommentDtos
{
  public  class CreateCommentDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }
        public bool CommentStatus { get; set; }
        public string ProductId { get; set; }
    }
}
