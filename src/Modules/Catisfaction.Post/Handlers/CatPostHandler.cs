using System.Threading.Tasks;
using Catisfaction.Post.Models;
using OrchardCore.ContentManagement.Handlers;

namespace Catisfaction.Post.Handlers
{
    public class CatPostHandler : ContentPartHandler<CatPostPart>
    {
        // This will display the "Name" property of the Cat Post in the Admin Panel list.
        public override Task UpdatedAsync(UpdateContentContext context, CatPostPart instance)
        {
            context.ContentItem.DisplayText = instance.Name.Text;

            return Task.CompletedTask;
        }
    }
}