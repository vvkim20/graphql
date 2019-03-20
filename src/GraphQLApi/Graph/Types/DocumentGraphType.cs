using AutoMapper;
using GraphQL.Conventions;
using MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edgenuity.MongoDB;
namespace GraphQLApi.Graph.Types
{
    public class DocumentGraphType
    {
        private IDocumentRepository _documentRepository;

        public int DocumentId { get; set; }
        public string Body { get; set; }
        public string ReferenceId { get; set; }

        public int CreateUserId { get; set; }
        public UserGraphType CreatedUser { get; set; }

        public async Task<IEnumerable<MongoDocumentGraphType>> MongoDocument([Inject] IDocumentRepository documentRepository)
        {
            var result = await documentRepository.GetDocument(DocumentId.ToString());
            return result.Select(d => Mapper.Map<MongoDocumentGraphType>(d));
        }

    }
}
