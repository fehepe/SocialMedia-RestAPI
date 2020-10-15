using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Data;
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
        public async Task<IActionResult> GetPostByPostId(int id)
        {
            var post = await _repository.GetPostByPostId(id);
            return Ok(post);
        }

        //api/Post
        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            await _repository.InsertPost(post);
            await _repository.SaveChanges();

            return Ok(post);
        }
    }
}
