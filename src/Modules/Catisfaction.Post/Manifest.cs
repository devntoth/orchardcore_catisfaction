using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Catisfaction.Post",
    Author = "Norbert Toth",
    Version = "1.0.0",
    Description = "Module for Catisfaction posts",
    Category = "Content Management",
    Dependencies = new[]
    {
        "OrchardCore.ContentTypes",
        "OrchardCore.ContentFields",
        "OrchardCore.Media",
        "OrchardCore.Content"
    }
)]
