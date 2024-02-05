
namespace RunicApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Data.Instance = datamanger.File.LoadData();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            Task runapp = app.RunAsync();

            Task save = new Task(async () =>
            {
                while (true)
                {
                    Console.WriteLine("Saving Data");
                    datamanger.File.SaveData(Data.Instance);
                    await Task.Delay(600000);
                }
            });
            save.Start();
            runapp.Wait();
            runapp.Dispose();
            save.Dispose();
        }
    }
}
