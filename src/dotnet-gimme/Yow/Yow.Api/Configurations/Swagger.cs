using System;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.Processors.Security;

namespace Yow.Api.Configurations {
    public static class Swagger {
        internal static void ConfigureSwagger (IApplicationBuilder app, IHostingEnvironment env) {
            app.UseSwaggerUi3 (typeof (Swagger).GetTypeInfo ().Assembly, s => {
                s.GeneratorSettings.Title = "Yow";
                s.GeneratorSettings.Description = $"Yow Web Api Description (Env: {env.EnvironmentName})";
                s.GeneratorSettings.DefaultUrlTemplate = "{controller}/{action}/{id?}";
                s.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;

                // TODO: Uncomment if you want to secure endpoints
                // s.GeneratorSettings.OperationProcessors.Add (new OperationSecurityScopeProcessor ("JWT Token"));
                // s.GeneratorSettings.DocumentProcessors.Add (new SecurityDefinitionAppender ("JWT Token",
                //     new SwaggerSecurityScheme {
                //             Type = SwaggerSecuritySchemeType.ApiKey,
                //             Name = "Authorization",
                //             Description = "Set value 'Bearer ' + valid JWT token into the field",
                //             In = SwaggerSecurityApiKeyLocation.Header,
                //             Scheme = JwtBearerDefaults.AuthenticationScheme
                //     }));
            });
        }
    }
}