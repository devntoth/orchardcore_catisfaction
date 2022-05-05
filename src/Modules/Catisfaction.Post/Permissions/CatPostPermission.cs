using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace Catisfaction.Post.Permissions
{
    public class CatPostPermission : IPermissionProvider
    {
        public static readonly Permission ViewCatPosts =
            new(nameof(ViewCatPosts), "View the Cat Posts list.");

        public Task<IEnumerable<Permission>> GetPermissionsAsync() =>
            Task.FromResult(new[] { ViewCatPosts }.AsEnumerable());

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() =>
            new[]
            {
            new PermissionStereotype()
            {
                Name = "Administrator",
                Permissions = new[] { ViewCatPosts },
            },
            new PermissionStereotype()
            {
                Name = "Anonymus",
                Permissions = new[] { ViewCatPosts },
            }
            };
    }
}