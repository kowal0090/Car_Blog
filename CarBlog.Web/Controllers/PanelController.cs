using CarBlog.Web.Data.Repository;
using CarBlog.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBlog.Web.ViewModels;
using CarBlog.Web.Data.FileManager;

namespace CarBlog.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public PanelController(
            IRepository repo,
            IFileManager fileManager
            )
        {
            _repo = repo;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new PostViewModel());
            }
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel 
                { 
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body,
                    CurrentImage = post.Image,
                    Category = post.Category,
                    Tags = post.Tags,
                    Description = post.Description
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {

            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body,
                Category = vm.Category,
                Tags = vm.Tags,
                Description = vm.Description,
            };

            if (vm.Image == null)
                post.Image = vm.CurrentImage;
            else
                post.Image = await _fileManager.SaveImage(vm.Image);

            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
