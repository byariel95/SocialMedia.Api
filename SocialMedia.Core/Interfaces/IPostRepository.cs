

namespace SocialMedia.Core.Interfaces
{
    using Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}
