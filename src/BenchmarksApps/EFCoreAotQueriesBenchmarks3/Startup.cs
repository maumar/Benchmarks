using Microsoft.EntityFrameworkCore;

namespace EFCoreAotQueriesBenchmarks3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
					Console.WriteLine("starting the app");

					using (var ctx = new EFCoreAotBenchmarkContext())
					{
						await context.Response.WriteAsync("accessing model");

						var model = ctx.Model;

						await context.Response.WriteAsync("On model creating ran? - " + EFCoreAotBenchmarkContext.OnModelCreatingRan);

						await context.Response.WriteAsync("accessing model - done");

						await context.Response.WriteAsync("running queries");

						var result0 = await ctx.Entities0.Where(x => x.Name1.Contains("e")).OrderBy(x => x.Id).Take(10).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
						var result1 = await ctx.Entities1.Where(x => x.Name2.Contains("e")).OrderBy(x => x.Id).Take(11).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
						var result2 = await ctx.Entities2.Where(x => x.Name3.Contains("e")).OrderBy(x => x.Id).Take(12).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
						var result3 = await ctx.Entities3.Where(x => x.Name4.Contains("e")).OrderBy(x => x.Id).Take(13).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
						var result4 = await ctx.Entities4.Where(x => x.Name5.Contains("e")).OrderBy(x => x.Id).Take(14).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
						var result5 = await ctx.Entities5.Where(x => x.Number1 > 5).OrderBy(x => x.Id).Take(15).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
						var result6 = await ctx.Entities6.Where(x => x.Number2 < 5).OrderBy(x => x.Id).Take(3).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
						var result7 = await ctx.Entities7.Where(x => x.Number3 == 7).OrderBy(x => x.Id).Take(17).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
						var result8 = await ctx.Entities8.Where(x => !x.Name1.Contains("e")).OrderBy(x => x.Id).Take(18).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
						var result9 = await ctx.Entities9.Where(x => !x.Name1.Contains("a")).OrderBy(x => x.Id).Take(4).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();

						await context.Response.WriteAsync("result0.Count");

						await context.Response.WriteAsync("result1 name1: " + result1[0].Name1);

						await context.Response.WriteAsync("running queries - done");
					}

					await context.Response.WriteAsync("finished running the app");
                });
            });

            //Console.WriteLine($"AspNetCore location: {typeof(IWebHostBuilder).GetTypeInfo().Assembly.Location}");
            //Console.WriteLine($"AspNetCore version: {typeof(IWebHostBuilder).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}");

            //Console.WriteLine($"NETCoreApp location: {typeof(object).GetTypeInfo().Assembly.Location}");
            //Console.WriteLine($"NETCoreApp version: {typeof(object).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}");
    
        }
    }
}