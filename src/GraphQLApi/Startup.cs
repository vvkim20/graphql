using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Edgenuity.ContentEngine.Entities;
using GraphQLApi.Graph.Model;
using GraphQL.Conventions;
using Schema = GraphQLApi.Graph.Schema;
using GraphQLApi.Graph;
using GraphiQl;
using GraphQL.DataLoader;
using Entity;
using Microsoft.EntityFrameworkCore;
using GraphQLApi.Resp;

namespace GraphQLApi
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
            services.AddMongoDbContext(Configuration.GetSection("ConnectionStrings:ContentEngineDb").Value, Configuration.GetSection("ConnectionStrings:ContentEngineDbCollection").Value);

            #region SQL EF
            services.AddDbContext<DocumentContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("DocumentDatabase"));
                    });
            services.AddScoped<IDocumenContext>(provider => provider.GetService<DocumentContext>());
            services.AddScoped<IDocumentRepo, DocumentRepo>();
            #endregion SQL EF

            services.AddSingleton(provider => new GraphQLEngine()
                .WithFieldResolutionStrategy(FieldResolutionStrategy.Normal)
                .BuildSchema(typeof(SchemaDefinition<Schema.Query, Schema.Mutation>)));
            services.AddScoped<IDependencyInjector, Injector>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IApiRequest, ApiRequest>();
            services.AddScoped<Schema.Query>();
            services.AddScoped<Schema.Mutation>();
            services.AddScoped<DataLoaderContext>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<FrameChainAttempt, FrameChainAttemptModel>();
                cfg.CreateMap<FrameAttempt, FrameAttemptModel>();
                cfg.CreateMap<StackAttempt, StackAttemptModel>();
                cfg.CreateMap<Document, DocumentModel>();
                cfg.CreateMap<User, UserModel>();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseGraphiQl("/graphql", "/graph");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
