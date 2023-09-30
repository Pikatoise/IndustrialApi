using Loading.DAL.Interfaces;
using Loading.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loading.Api.Controllers
{
    [ApiController]
    [Tags("Должности (Posts)")]
    [Route("api/posts/")]
    public class PostController: ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public PostController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpGet("")]
        public IActionResult GetAllPosts()
        {
            return Ok(_repository.Posts.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            Post? result = _repository.Posts.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("add/{name}")]
        public IActionResult CreatePost(string name)
        {
            Post? postWithSameName = _repository.Posts.GetByCondition(p => p.Name.Equals(name)).FirstOrDefault();

            if (postWithSameName != null)
                return BadRequest("Post with same name already exist");

            Post newPost = _repository.Posts.Create(new Post() { Name =  name });

            _repository.Save();

            return Ok(newPost.Id);
        }

        [HttpDelete("remove/{id}")]
        public IActionResult DeletePost(int id)
        {
            Post? postToDelete = _repository.Posts.GetById(id);

            if (postToDelete == null)
                return NotFound("Post with this id was not found");

            _repository.Posts.Delete(postToDelete);

            _repository.Save();

            return Ok();
        }
    }
}
