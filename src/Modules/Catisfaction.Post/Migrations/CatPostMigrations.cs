using Catisfaction.Post.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Media.Fields;

namespace Catisfaction.Post.Migrations
{
    public class CatPostPartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public CatPostPartMigrations(IContentDefinitionManager contentDefinitionManager)
            => _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(CatPostPart), part => part
                .WithField(nameof(CatPostPart.Name), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Name")
                    .WithSettings(new TextFieldSettings() { Required = true })
                )
                .WithField(nameof(CatPostPart.Body), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Body")
                    .WithEditor("TextArea")
                )
                .WithField(nameof(CatPostPart.IsMeme), field => field
                    .OfType(nameof(BooleanField))
                    .WithDisplayName("Is meme")
                )
                .WithField(nameof(CatPostPart.Image), field => field
                    .OfType(nameof(MediaField))
                    .WithDisplayName("Image")
                    .WithEditor("Attached")
                )
            );

            _contentDefinitionManager.AlterTypeDefinition("CatPost", type => type
                .Creatable()
                .Listable()
                .Securable()
                .WithPart(nameof(CatPostPart))
            );

            return 2;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterTypeDefinition("CatPost", type => type
                .Creatable()
                .Listable()
                .Securable()
                .WithPart(nameof(CatPostPart))
            );

            return 2;
        }
    }
}