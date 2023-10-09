using Implementation;
using Interfaces;
using Serilog;
using Types.Models.Settings;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

HttpClientSettings settings = new();
builder.Configuration.GetSection("HttpClientSettings").Bind(settings);

//builder.Services.AddHttpClient();

builder.Services.AddHttpClient(
    settings.Name, 
    httpClient =>
{
    httpClient.DefaultRequestHeaders.Add("Authorization", "someToken");
    httpClient.Timeout = TimeSpan.FromSeconds(
        builder.Configuration.GetValue<uint>("HttpClientSettings:Timeout", 120));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddTransient<IUserService, UserService>();

string? allowedHost = builder.Configuration.GetValue<string>("ApiSettings:AllowedHosts");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(allowedHost ?? "");
        });
});

builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
