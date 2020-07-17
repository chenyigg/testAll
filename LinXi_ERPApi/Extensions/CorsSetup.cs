using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinXI_ERPApi.Extensions
{
    public static class CorsSetup
    {
        public static void AddMyCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("AllowCors", policy =>
                {
                    //Vue项目地址
                    policy.WithOrigins("http://localhost:56569").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    policy.WithExposedHeaders("Content-Disposition");
                });
            });
        }
    }
}