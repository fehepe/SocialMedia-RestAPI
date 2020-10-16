using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Data;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //api/Post
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var post = await _repository.GetPosts();

            var postsDto = _mapper.Map<IEnumerable<PostDto>>(post);

            return Ok(postsDto);
        }
         
        //api/Post/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByPostId(int id)
        {
            var post = await _repository.GetPostByPostId(id);

            var postDto = _mapper.Map<PostDto>(post);

            return Ok(postDto);
        }

        //api/Post
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {           
            var post = _mapper.Map<Post>(postDto);

            await _repository.InsertPost(post);
            await _repository.SaveChanges();

            return Ok(post);
        }
    }
}
