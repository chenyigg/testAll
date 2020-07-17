using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                   Host.CreateDefaultBuilder(args)
                   .ConfigureLogging(configureLogging =>
                   {
                       //���˵�System��Microsoft��ͷ�������ռ��µ���������ľ��漶��һ�µ���־
                       //configureLogging.AddFilter("System", LogLevel.Warning);
                       //configureLogging.AddFilter("Microsoft", LogLevel.Warning);
                       configureLogging.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.Warning);
                       //ע��log4net
                       configureLogging.AddLog4Net(AppDomain.CurrentDomain.BaseDirectory + "Log4net.config");
                   })
                   .ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.ConfigureKestrel((context, options) =>
                       {
                           //����Ӧ�÷�����Kestrel���������Ϊ150MB
                           options.Limits.MaxRequestBodySize = 152428800;
                       });
                       webBuilder.UseStartup<Startup>().UseIIS();
                   }).UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}