using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgenuity.MongoDB
{
    public class Document 
    {
        [BsonId]
        public Guid Id { get; set; }

        public string DocumentId { get; set; }
    }
}
