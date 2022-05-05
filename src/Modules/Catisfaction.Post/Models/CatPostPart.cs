using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;

namespace Catisfaction.Post.Models
{
    public class CatPostPart : ContentPart
    {
        public TextField Name { get; set; }
        public TextField Body { get; set; }
        public MediaField Image { get; set; }
        public BooleanField IsMeme { get; set; }
    }
}