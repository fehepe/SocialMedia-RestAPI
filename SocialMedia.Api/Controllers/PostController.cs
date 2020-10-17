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
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        //api/Post
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var post = await _postService.GetPosts();

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
            var post = await _postService.GetPostByPostId(id);

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
           
            await _postService.InsertPost(post);
            

            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);

            return Ok(response);
        }

        //api/Post/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;

            var result = await _postService.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        //api/Post/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {         

            //await _postService.InsertPost(post);
            var result = await _postService.DeletePost(id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
