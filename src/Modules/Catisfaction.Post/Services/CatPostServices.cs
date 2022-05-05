using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catisfaction.Post.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using YesSql;

namespace Catisfaction.Post.Services
{
    public class CatPostServices : ICatPostServices
    {
        private readonly ISession _session;

        public CatPostServices(ISession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<ContentItem>> ListCatPostsAsync()
        {
            var query = _session
                .Query<ContentItem, ContentItemIndex>(index => index.Published)
                .Where(index => index.ContentType == "CatPost");

            return await query.ListAsync();
        }

        public async Task<IEnumerable<ContentItem>> ListCatMemesAsync()
        {
            // Get all Cat Posts from DB
            var posts = await _session
                .Query<ContentItem, ContentItemIndex>(index => index.Published)
                .Where(index => index.ContentType == "CatPost")
                .ListAsync();

            // Filter out non-memes
            var memes = posts.Where(post => post.As<CatPostPart>().IsMeme.Value);

            return memes;
        }
    }
}