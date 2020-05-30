


namespace SocialMedia.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SocialMedia.Core.Entities;

    public class PostRepository
    {
        public IEnumerable<Post> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post
            {
                PostId = x,
                Description = $"Description No. {x}",
                Date = DateTime.Now,
                Image = $"http://miimage.com/{x}",
                UserId = x*2
            });

            return posts;
        }
    }
}
