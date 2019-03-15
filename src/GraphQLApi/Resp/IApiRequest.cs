using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLApi.Resp
{
    public interface IApiRequest
    {
        Task<IEnumerable<Document>> GetDocuments();
        Task<Document> GetDocument(int documentId);
        Task<IEnumerable<Document>> GetDocumentByUserName(string userName);
    }
}