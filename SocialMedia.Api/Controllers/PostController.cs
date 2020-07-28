

namespace SocialMedia.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Interfaces;
    using System.Threading.Tasks;
    using Core.Entities;
    using System.Linq;
    using Core.DTOs;
    using AutoMapper;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //injected dependecy of mapper 
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await postRepository.GetPosts();
            // implement automapper 
            var postsDto = mapper.Map<IEnumerable<PostDto>>(posts);

            /* transform entity in dto manually
            var postsDto = posts.Select(x => new PostDto 
            {
                PostId = x.PostId,
                Date = x.Date,
                Description = x.Description,
                Image = x.Image,
                UserId = x.UserId
            });*/
            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await postRepository.GetPost(id);
            //create post dto with automapper
            var postsDto = mapper.Map<PostDto>(post);


            // create new dto
            /*var postsDto = new PostDto
            {
                PostId = post.PostId,
                Date = post.Date,
                Description = post.Description,
                Image = post.Image,
                UserId = post.UserId
            };*/
            return Ok(postsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {

            var post = mapper.Map<Post>(postDto);

            // trasnform dto in entity 
            /* var post = new Post
             {
                 Date = postDto.Date,
                 Description = postDto.Description,
                 Image = postDto.Image,
                 UserId = postDto.UserId
             };*/
            await postRepository.InsertPost(post);
            return Ok(post);
        }
    }
}