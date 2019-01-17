using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TVX.Test.PostsService.Controllers
{
    using Business.Interfaces;
    using Repository.Interfaces;
    using Models;

    [Route("api/[controller]")]
    [Consumes("application/json")]
    public class PostsController : Controller
    {
        private readonly IPostsService _service;
        private readonly IPostsRepository _repository;

        public PostsController(IPostsService service, IPostsRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        // GET api/posts
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _repository.All();
        }

        // POST api/posts
        [HttpPost] // Create action
        public string Post([FromBody] Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Insert(post);
                    _repository.Save();
                    return "Created";
                }
            }
            catch (Exception /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. ");
            }
            return "Error";
        }

        // GET api/posts/5
        [HttpGet("{id}")] // Read action
        public Post Get(int id)
        {
            return _repository.Get(id);
        }

        // PUT api/posts/5
        [HttpPut("{id}")] // Update action
        public string Put(int id, [FromBody] Post post)
        {
            var target = _repository.Get(id);
            target.Text = post.Text;

            _repository.Update(target);
            return "Updated";
        }

        // DELETE api/posts/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _repository.Delete(id);
            return "Deleted";
        }
    }
}
