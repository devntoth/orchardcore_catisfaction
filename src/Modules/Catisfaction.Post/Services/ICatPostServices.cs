using System.Collections.Generic;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;

namespace Catisfaction.Post.Services
{
    public interface ICatPostServices
    {
        public Task<IEnumerable<ContentItem>> ListCatPostsAsync();

        public Task<IEnumerable<ContentItem>> ListCatMemesAsync();
    }
}