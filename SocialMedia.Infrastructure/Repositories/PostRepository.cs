


namespace SocialMedia.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Entities;
    using Core.Interfaces;
    using Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class PostRepository: IPostRepository
    {
        private readonly SocialMediaContext socialMediaContext;

        public PostRepository(SocialMediaContext socialMediaContext)
        {
            this.socialMediaContext = socialMediaContext;
        }
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await socialMediaContext.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPost(int id )
        {
            var post = await socialMediaContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            return post;
        }
    }
}
