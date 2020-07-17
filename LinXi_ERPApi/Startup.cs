using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using LinXi_Common;
using LinXI_ERPApi.Extensions;
using LinXi_Model;

//using LinXi_Model.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace LinXi_ERPApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region 注册的服务

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region 配置Swagger

            services.AddMySwagger();

            #endregion 配置Swagger

            services.AddSession();

            #region AutoMapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion AutoMapper

            #region 配置跨域Cors

            services.AddMyCors();

            #endregion 配置跨域Cors

            #region 注入DbContext

            #region MySql版

            services.AddTransient<DbContext, db_erpContext>();
            services.AddDbContext<db_erpContext>(optionsAction =>
            {
                optionsAction.UseMySql(Configuration.GetConnectionString("MyConn"));
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            #endregion MySql版

            #region SqlServer版

            //services.AddTransient<DbContext, LinXi_CloudStorageContext>();
            //services.AddDbContext<LinXi_CloudStorageContext>(optionsAction =>
            //{
            //    optionsAction.UseSqlServer("Integrated Security=True;DataBase=LinXi_CloudStorage;server=.;");
            //}, ServiceLifetime.Transient, ServiceLifetime.Transient);

            #endregion SqlServer版

            #endregion 注入DbContext

            #region Id4鉴权授权

            services.AddMyIdentityServer();

            #endregion Id4鉴权授权

            #endregion 注册的服务

            #region 控制器替换

            services.AddControllersWithViews(option =>
            {
                //option.Filters.Add(typeof(MyAuthorAttribute));
                option.RespectBrowserAcceptHeader = true; // false by default
            })
                .AddNewtonsoftJson(setup =>
                {
                    setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            #endregion 控制器替换
        }

        /// <summary>
        /// Autofac组件注册
        /// </summary>
        /// <param name="containerBuilder"></param>
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new AutofacModule());
        }

        /// <summary>
        /// 添加中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region 环境配置

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //异常 / 错误处理
                //app.UseExceptionHandler("/Home/Error");
                app.UseExceptionHandler(config =>
                {
                    config.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            var ex = error.Error;
                            await context.Response.WriteAsync(new
                            {
                                StatusCode = 500,
                                ErrorMessage = "服务器错误！"
                            }.ToString());
                        }
                    });
                });
                //HTTP 严格传输安全协议
                app.UseHsts();
            }

            #endregion 环境配置

            #region 添加的中间件

            //HTTPS 重定向
            app.UseHttpsRedirection();

            //静态文件服务器
            app.UseStaticFiles();

            //配置Swagger
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "swaggerTest");
                //s.DocInclusionPredicate((docName, description) => true);// 标注要使用的 XML 文档
            });

            //Cookie 策略实施
            app.UseCookiePolicy();

            //会话
            app.UseSession();

            app.UseRouting();

            //配置跨域，必须放在UseMVC之前UseRouting和UseEndpoints之间
            app.UseCors("AllowCors");

            //身份验证
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=WeatherForecast}/{id?}");

                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "/api/{controller}/{action}/{id?}");

                endpoints.MapControllers();
            });

            #endregion 添加的中间件
        }
    }
}