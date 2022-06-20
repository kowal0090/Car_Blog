using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBlog.Web.Models.Comments
{
    public class SubComment : Comments
    {
        public int MainCommentId { get; set; }
    }
}
