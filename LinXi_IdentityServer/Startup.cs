using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LinXi_CloudStorageApi.Extensions;
using LinXi_IdentityServer.ServerModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LinXi_IdentityServer
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
            #region ����Կ��

            //using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048))
            //{
            //    Console.WriteLine("PublicKey" + Convert.ToBase64String(provider.ExportCspBlob(false)));   //PublicKey

            //    Console.WriteLine("PrivateKey" + Convert.ToBase64String(provider.ExportCspBlob(true)));    //PrivateKey
            //}
            //var rsa = new RSACryptoServiceProvider();
            ////�������ļ���ȡ����֤��
            //rsa.ImportCspBlob(Convert.FromBase64String(Configuration.GetValue<string>("SigningCredential")));
            //Console.WriteLine("��Կ" + Convert.ToBase64String(rsa.ExportCspBlob(false)));
            //Console.WriteLine("˽Կ" + Convert.ToBase64String(rsa.ExportCspBlob(true)));

            #endregion ����Կ��

            services.AddControllersWithViews();
            services.AddMyCors();
            services.AddIdentityServer()
              .AddInMemoryIdentityResources(Config.GetIdentityResources())
               //.AddDeveloperSigningCredential()
               //.AddSigningCredential(new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256))    //���ü���֤��
               //�����Զ������֤��
               .AddSigningCredential(
                        new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Configuration["Certificates:Path"]),
                         Configuration["Certificates:Password"]))
              .AddInMemoryApiResources(Config.GetApiResources())

              .AddInMemoryApiScopes(Config.GetApiScopes())

              .AddInMemoryClients(Config.GetClients())
             .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddProfileService<ProfileService>();

            //Inject the classes we just created
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            //���ÿ��򣬱������UseMVC֮ǰUseRouting��UseEndpoints֮��
            app.UseCors("AllowCors");
            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}