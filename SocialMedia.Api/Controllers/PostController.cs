using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        //api/Post
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var post = await _repository.GetPosts();
            return Ok(post);
        }

        //api/Post/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByUserId(int id)
        {
            var post = await _repository.GetPostByUserId(id);
            return Ok(post);
        }
    }
}
