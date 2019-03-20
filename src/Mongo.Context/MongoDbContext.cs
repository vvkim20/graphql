using Microsoft.Extensions.Options;
using MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgenuity.MongoDB
{
    public interface IMongoDbContext
    {
        IMongoCollection<FrameAttempt> FrameAttempts { get; }
        IMongoCollection<FrameChainAttempt> FrameChainAttempts { get; }
        IMongoCollection<Document> Documents { get; }
    }

    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database = null;
        public MongoDbContext(IMongoDatabase mongoDatabase)
        {
            _database = mongoDatabase;
        }

        public IMongoCollection<FrameChainAttempt> FrameChainAttempts
        {
            get { return _database.GetCollection<FrameChainAttempt>(nameof(FrameChainAttempt)); }
        }

        public IMongoCollection<FrameAttempt> FrameAttempts
        {
            get { return _database.GetCollection<FrameAttempt>(nameof(FrameAttempt)); }
        }

        public IMongoCollection<Document> Documents
        {
            get { return _database.GetCollection<Document>(nameof(Document)); }
        }
    }
}
