

namespace SocialMedia.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Interfaces;
    using System.Threading.Tasks;
    using Core.Entities;
    using System.Linq;
    using Core.DTOs;

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository postRepository;

        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await postRepository.GetPosts();
            // transform entity in dto
            var postsDto = posts.Select(x => new PostDto 
            {
                PostId = x.PostId,
                Date = x.Date,
                Description = x.Description,
                Image = x.Image,
                UserId = x.UserId
            });
            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await postRepository.GetPost(id);
            var postsDto = new PostDto
            {
                PostId = post.PostId,
                Date = post.Date,
                Description = post.Description,
                Image = post.Image,
                UserId = post.UserId
            };
            return Ok(postsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            // trasnform dto in entity 
            var post = new Post
            {
                Date = postDto.Date,
                Description = postDto.Description,
                Image = postDto.Image,
                UserId = postDto.UserId
            };
            await postRepository.InsertPost(post);
            return Ok(post);
        }
    }
}