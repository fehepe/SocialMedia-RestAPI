using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
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

            if (post == null)
            {
                return NotFound();
            }
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(post);

            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);
            return Ok(response);
            
        }

        //api/Post/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByPostId(int id)
        {
            var post = await _repository.GetPostByPostId(id);

            if (post == null)
            {
                return NotFound();
            }
            var postDto = _mapper.Map<PostDto>(post);

            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        //api/Post
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
           
            await _repository.InsertPost(post);
            await _repository.SaveChanges();

            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);

            return Ok(response);
        }

        //api/Post/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.PostId = id;

            var result = await _repository.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        //api/Post/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {         

            //await _repository.InsertPost(post);
            var result = await _repository.DeletePost(id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
