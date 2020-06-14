

namespace SocialMedia.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Interfaces;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository postRepository;

        public PostController(IPostRepository postRepository )
        {
            this.postRepository = postRepository;
        }
        public async Task<IActionResult> GetPosts ()
        {
            var posts = await postRepository.GetPosts();
            return Ok(posts);
        }
    }
}