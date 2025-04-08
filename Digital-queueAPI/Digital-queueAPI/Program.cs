using Digital_queueAPI.BLL;
using Digital_queueAPI.DAL;
using Digital_queueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Digital_queueAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //register services and repositories
            builder.Services.AddTransient<UserRepository>();
            builder.Services.AddTransient<UserService>();

            builder.Services.AddTransient<QueueRepository>();
            builder.Services.AddTransient<QueueService>();

            builder.Services.AddTransient<QueueEntryRepository>();
            builder.Services.AddTransient<QueueEntryService>();

            builder.Services.AddTransient<NotificationRepository>();
            builder.Services.AddTransient<NotificationService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(c => {c.CreateMap<Notification, NotificationDTOs>().ReverseMap(); },AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
