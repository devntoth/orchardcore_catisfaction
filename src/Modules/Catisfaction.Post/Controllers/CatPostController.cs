using System.Threading.Tasks;
using Catisfaction.Post.Permissions;
using Catisfaction.Post.Services;
using Catisfaction.Post.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catisfaction.Post.Controllers
{
    public class CatPostController : Controller
    {
        private ICatPostServices _catPostServices;
        private readonly IAuthorizationService _authorizationService;

        public CatPostController(ICatPostServices catPostServices, IAuthorizationService authorizationService)
        {
            _catPostServices = catPostServices;
            _authorizationService = authorizationService;
        }

        // Lists every Cat Post.
        public async Task<ActionResult> List()
        {
            if (!(await AuthorizeForCatPostsAsync()))
            {
                return View("NoPermission");
            }

            var posts = await _catPostServices.ListCatPostsAsync();
            var model = new CatPostListViewModel(posts);

            return View(model);
        }

        // Lists every Cat Post that is flagged as a meme.
        public async Task<ActionResult> ListMemes()
        {
            if (!(await AuthorizeForCatPostsAsync()))
            {
                return View("NoPermission");
            }

            var memes = await _catPostServices.ListCatMemesAsync();
            var model = new CatPostListViewModel(memes);

            return View(nameof(List), model);
        }

        private async Task<bool> AuthorizeForCatPostsAsync()
            => await _authorizationService.AuthorizeAsync(User, CatPostPermission.ViewCatPosts);
    }
}