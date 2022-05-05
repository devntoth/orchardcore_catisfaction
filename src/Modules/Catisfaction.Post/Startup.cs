using System;
using Catisfaction.Post.Controllers;
using Catisfaction.Post.Handlers;
using Catisfaction.Post.Migrations;
using Catisfaction.Post.Models;
using Catisfaction.Post.Permissions;
using Catisfaction.Post.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Security.Permissions;

namespace Catisfaction.Post
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services
                .AddContentPart<CatPostPart>()
                .AddHandler<CatPostHandler>();
            services.AddScoped<IDataMigration, CatPostPartMigrations>();
            services.AddScoped<ICatPostServices, CatPostServices>();
            services.AddScoped<IPermissionProvider, CatPostPermission>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Catisfaction.Post.Home",
                areaName: "Catisfaction.Post",
                pattern: string.Empty,
                defaults: new { controller = typeof(CatPostController), action = nameof(CatPostController.List) }
            );
        }
    }
}