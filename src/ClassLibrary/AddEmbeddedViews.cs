using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClassLibraryEmbeddedViewsExtensions
    {
        public static IServiceCollection AddEmbeddedViews(this IServiceCollection services)
        {
            var optionsSetup = new ConfigureOptions<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(
                    new EmbeddedFileProvider(
                        typeof(ClassLibraryEmbeddedViewsExtensions).GetTypeInfo().Assembly,
                        "ClassLibrary"));
            });
            services.AddSingleton<IConfigureOptions<RazorViewEngineOptions>>(optionsSetup);

            return services;
        }
    }
}