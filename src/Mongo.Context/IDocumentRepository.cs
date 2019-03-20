using System.Collections.Generic;
using System.Threading.Tasks;

namespace Edgenuity.MongoDB
{
    public interface IDocumentRepository
    {
        Document AddDocument(string documentId);
        Task<IEnumerable<Document>> GetDocument(string documentId);
        Task<IEnumerable<Document>> GetDocuments();
    }
}