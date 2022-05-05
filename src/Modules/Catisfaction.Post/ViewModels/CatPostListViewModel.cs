using System.Collections.Generic;
using OrchardCore.ContentManagement;

namespace Catisfaction.Post.ViewModels
{
    public class CatPostListViewModel
    {
        public IEnumerable<ContentItem> CatPosts { get; }

        public CatPostListViewModel(IEnumerable<ContentItem> catPosts)
        {
            CatPosts = catPosts;
        }
    }
}