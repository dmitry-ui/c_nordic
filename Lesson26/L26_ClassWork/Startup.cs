using DataStore.Core;
using DataStore.InMemory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace L26_ClassWork
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.SetCompatibilityVersion(
					CompatibilityVersion.Version_2_2)
				.AddMvcOptions(
					o => o.OutputFormatters.Add(
						new XmlDataContractSerializerOutputFormatter()));

			services.AddSingleton<ICitiesDataStore>(
				new CitiesDataStore());
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStatusCodePages();
			app.UseMvc();
		}
	}
}
