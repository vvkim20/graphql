using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity
{
    public interface IDocumentRepo
    {
        Task<Document> CreateDocument(string body, string userName);
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document> GetDcoument(int documentId);
        Task<IEnumerable<Document>> GetDocumentByUsernameAsync(string username);
    }
}