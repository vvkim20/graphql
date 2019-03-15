using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class DocumentRepo : IDocumentRepo
    {
        private IDocumenContext _docContext;
        public DocumentRepo(IDocumenContext documentContext)
        {
            _docContext = documentContext;
        }

        public async Task<Document> CreateDocument(string body, string userName)
        {
            var document = new Document() { Body = body, CreatedUser = new User() { UserName = userName } };
            _docContext.Documents.Add(document);
            await _docContext.ContextSaveChangeAsync();
            return document;
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _docContext.Documents.Include(d => d.CreatedUser).OrderBy(d => d.DocumentId).ToListAsync();
        }


        public async Task<Document> GetDcoument(int documentId)
        {
            var result = await _docContext.Documents.Include(d => d.CreatedUser).FirstOrDefaultAsync(d => d.DocumentId == documentId);
           return result;
        }

        public async Task<IEnumerable<Document>> GetDocumentByUsernameAsync(string username)
        {
            var query = from e in _docContext.Documents
                        where e.CreatedUser.UserName == username
                        select e;
            return await query.Include(d=>d.CreatedUser).ToListAsync();
        }
    }
}
