using PasswordStorage.API.Data;
using PasswordStorage.API.Repositories;
using PasswordStorage.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
const string policyName = "FrontendPolicy";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEntityFrameworkInMemoryDatabase();
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddScoped<IUserPasswordRepository, UserPasswordRepository>();
builder.Services.AddScoped<IWebsitePasswordRepository, WebsitePasswordRepository>();
builder.Services.AddScoped<IEmailPasswordRepository, EmailPasswordRepository>();
builder.Services.AddCors(options =>
    options.AddPolicy(policyName,
        policy => policy.WithOrigins("http://localhost:4200")
            .WithMethods("GET", "POST")
            .AllowAnyHeader()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors(policyName);
app.Run();