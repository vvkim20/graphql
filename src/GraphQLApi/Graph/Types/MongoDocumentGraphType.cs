using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLApi.Graph.Types
{
    public class MongoDocumentGraphType
    {
        public Guid Id { get; set; }

        public string DocumentId { get; set; }
    }
}
