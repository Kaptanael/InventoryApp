
var builder = WebApplication.CreateBuilder(args);

builder.AddIdentityServerServicesFromAppSettings()
    .AddApplicationServices();
builder.Services.AddInfrastructureServices()
    .AddPersistenceServices();

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers(config =>
{
    config.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().
        RequireAuthenticatedUser().
        RequireClaim(builder.Configuration["IdentityServer:ClaimType"], builder.Configuration["IdentityServer:ClaimValue"]).Build()));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseIdentityServer();
app.MapControllers();

app.Run();
