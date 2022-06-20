using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace CarBlog.Web.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);
        Task<String> SaveImage(IFormFile Image);
    }
}
