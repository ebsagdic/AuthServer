using SharedLibrary.Configuration;

var builder = WebApplication.CreateBuilder(args);
//Options Pattern ,appsettings.json dosyas�nda yer alan yap�land�rma verilerini g��l� bir �ekilde y�netmek amac�yla kullan�l�r. 
builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));

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

app.Run();
