var builder = WebApplication.CreateBuilder(args);
//cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        builder =>
        {
            builder.WithOrigins("https://localhost:3000",
                                "https://localhost.3000");
        });

    options.AddPolicy("AnotherPolicy",
        builder =>
        {
            builder.WithOrigins("https://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
