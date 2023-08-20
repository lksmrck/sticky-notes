
using Microsoft.Extensions.DependencyInjection;
using Notes.Validation.Services;
using Notes.Validation.Services.Interfaces;
using Notes.Validation.Validation;


namespace Notes.Validation.Config
{
    public static class ServicesConfig
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddScoped<NoteValidator>();
            services.AddScoped<INoteValidationService, NoteValidationService>();

            return services;
        }
    }
}
