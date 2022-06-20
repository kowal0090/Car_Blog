using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBlog.Web.Models.Comments
{
    public class MainComment : Comments
    {
        public List<SubComment> SubComments { get; set; }
    }
}
