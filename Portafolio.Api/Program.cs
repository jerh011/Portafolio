using PORTAFOLIO.API.Configurations;
using PORTAFOLIO.API.Services;

var builder = WebApplication.CreateBuilder(args);

//MongoDataBase
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDataBase"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<PortafolioServices>();//Agregar servicios
builder.Services.AddScoped<PortafolioServices>();

builder.Services.AddCors(options => options.AddPolicy("AngularClient", policy => {
	policy.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader();
})); 

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 app.UseHttpsRedirection();

 app.UseAuthorization();

 app.MapControllers();

 app.UseCors("AngularClient");

 app.Run();