using Backend.Data;
using Backend.Repositories.ContactAudits;
using Backend.Repositories.Contacts;
using Backend.Repositories.UserAudits;
using Backend.Repositories.Users;
using Backend.Services.Auths;
using Backend.Services.ContactAudits;
using Backend.Services.Contacts;
using Backend.Services.UserAuditService;
using Backend.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
       $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Contact Management System API",
        Contact = new OpenApiContact
        {
            Name = "Shiela Mae Q. Lepon",
            Url = new Uri("https://github.com/shielamae02/ContactManagementSystemAPI.git")
        }
    });
});


// Configure CORS (Cross-Origin Resource Sharing) settings for the application.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

// Call ConfigureServices 
ConfigureServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Initialize();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable UseCors()
app.UseCors();

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

// Map controllers
app.MapControllers();


// Run the application s
app.Run();


void ConfigureServices(IServiceCollection services)
{
    //Register the DBContext
    services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

    //Register JWT Authentication
    services.AddAuthentication().AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
        };
    });

    //Register HttpContextAccessor
    builder.Services.AddHttpContextAccessor();


    //Register Automapper

    services.AddAutoMapper(typeof(Program).Assembly);

    //Register Repositories
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IContactRepository, ContactRepository>();
    builder.Services.AddScoped<IUserAuditRepository, UserAuditRepository>();
    builder.Services.AddScoped<IContactAuditRepository, ContactAuditRepository>();

    //Register Services
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IContactService, ContactService>();
    builder.Services.AddScoped<IUserAuditService, UserAuditService>();
    builder.Services.AddScoped<IContactAuditService, ContactAuditService>();
}