

namespace SocialMedia.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Repositories;

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public IActionResult GetPosts ()
        {
            var posts = new PostRepository().GetPosts();
            return Ok(posts);
        }
    }
}