var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(c => {
    c.AddPolicy("MyCors", builder => {
        builder.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("MyCors");

app.MapControllers();

app.Run();
