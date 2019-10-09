using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNETProject
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		//можно добавить сервисы в контейнер(доступно в рамках приложений)
		public void ConfigureServices(IServiceCollection services)
		{
			//добавим сервис мвс и совместили его с дотнетом2.2
			//конец для xml
			services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2).
				AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		//настраивается конвейер обработки запросов
		//делегаты и  т.д.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//более менее красивая страница с ошибкой
			app.UseStatusCodePages();


			//use mvc
			//используем созданный сервис мвс
			//app.UseMvc(config=> config.MapRoute(name: "Default",
			//									template: "{controller}/{action}/{id?}",
			//									defaults: new
			//									{
			//										controller = "Cities",
			//										action = "GetCities"
			//									}));
			////создадим сервис по получ инфы по городам

			app.UseMvc();


		}
	}
}
