using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgenuity.ContentEngine.Entities
{
    public static class MongoDbExtension
    {
        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, string mongoDbconn, string mongoDbName)
        {
            // Explicit the mongoDb interface
            services.AddSingleton<IMongoDatabase>(sp =>
            {
                var client = new MongoClient(mongoDbconn);                
                return client.GetDatabase(mongoDbName);
            });

            services.AddSingleton<IFrameChainAttemptRepository, FrameChainAttemptRepository>();
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            return services;
        }
    }
}
