using OverviewService.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("countryClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5201/");
});
builder.Services.AddHttpClient("exchangeClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5012/");
});
builder.Services.AddOptions();

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
