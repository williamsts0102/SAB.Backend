using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SAB.Backend.Business;
using SAB.Backend.DataAccess;
using SAB.Backend.Models.SAB.DB;
using SAB.Backend.Providers;
using SAB.Backend.SignalR;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(setupAction: CorsOptions options =>
//    {
//        options.AddPolicy(name: "AllowSpecificOrigin",
//            configurePolicy: CorsPolicyBuilder builder => builder
//                .WithOrigins(origins: "http://localhost:4200")
//                .AllowAnyHeader()
//                .AllowAnyMethod());
//    });
//});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigin",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "https://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                      });
});
//builder.Logging.AddLog4Net();

// Configurar SignalR
builder.Services.AddSignalR();

builder.Services.AddDbContext<SABContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//var key = builder.Configuration.GetValue<string>("JwtSettings:key");
//var keyBytes = Encoding.ASCII.GetBytes(key);

//builder.Services.AddAuthentication(config =>
//{
//    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(config =>
//{
//    config.RequireHttpsMetadata = false;
//    config.SaveToken = true;
//    config.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ClockSkew = TimeSpan.Zero
//    };
//});
//OWASPSettings START
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
    options.Secure = CookieSecurePolicy.Always;
});
builder.Services.AddAntiforgery(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; ;
});
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie();
//OWASPSettings END

builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<ISABBO, SABBO>();
builder.Services.AddScoped<ISABDO, SABDO>();

var key = builder.Configuration.GetValue<string>("JwtSettings:key");
var keyBytes = Encoding.ASCII.GetBytes(key);

#endregion;

var app = builder.Build();

#region Apps
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
//OWASPSettings START
app.UseRouting();
app.UseCookiePolicy();
app.Use(async (context, next) =>
{
    context.Response.Headers.Remove("Server");
    context.Response.Headers.Remove("X-AspNet-Version");
    context.Response.Headers.Remove("X-AspNetMvc-Version");

    context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
    context.Response.Headers.Add("Feature-Policy", "accelerometer 'none'; camera 'none'; geolocation 'none'; gyroscope 'none'; magnetometer 'none'; microphone 'none'; payment 'none'; usb 'none'");

    await next();
});
app.UseCors("AllowSpecificOrigin");
//OWASPSettings END

//app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

// Configurar el endpoint de SignalR
app.MapHub<AlertHub>("/alerthub");

app.Run();
#endregion
