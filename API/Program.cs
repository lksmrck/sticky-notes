
using API;
using backend.Data;
using backend.Repository;
using backend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
            });

            builder.Services.AddScoped<DbContext, ApplicationDbContext>();

            builder.Services.AddScoped<INoteRepository, NoteRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: "AllowAll",
            //                      policy =>
            //                      {
            //                          policy.WithOrigins("http://localhost:3008",
            //                                              "http://www.xxx.com"); // add the allowed origins  
            //                      });
            //});

            // Add services to the container.

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddControllers();
            builder.Services.AddTransient<Seed>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Seed DB context before app starts
            if (args.Length == 1 && args[0].ToLower() == "seeddata")
                SeedData(app);

            void SeedData(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<Seed>();
                    service.SeedDbContext();
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}