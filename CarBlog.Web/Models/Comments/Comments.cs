using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBlog.Web.Models.Comments
{
    public class Comments
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
