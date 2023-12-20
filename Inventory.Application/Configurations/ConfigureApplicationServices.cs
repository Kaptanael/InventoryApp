﻿namespace Inventory.Application.Configurations;

public static class ConfigureApplicationServices
{
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.AddSerilogFromAppSettings();
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddScoped<IUserService, UserService>();
        return builder;
    }

    private static WebApplicationBuilder AddSerilogFromSerilogConfig(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
           .ReadFrom.Configuration(new ConfigurationBuilder()
           .AddJsonFile("serilog.development.config.json")
           .Build())
           .Enrich.FromLogContext()
           .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddSerilog(logger);

        return builder;
    }

    private static WebApplicationBuilder AddSerilogFromAppSettings(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddSerilog(logger);

        return builder;
    }
}
