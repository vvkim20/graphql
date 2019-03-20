using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace Edgenuity.MongoDB
{
    public class DocumentRepository : IDocumentRepository
    {
        private IMongoDbContext _context = null;
        public DocumentRepository(IMongoDbContext context)
        {
            _context = context;
        }


        public Document AddDocument(string documentId)
        {
            try
            {
                var value = new Document() { DocumentId = documentId };
                _context.Documents.InsertOne(value);
                return value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Document>> GetDocuments()
        {
            return await _context.Documents.Find( _ => true).Limit(100).ToListAsync();
        }

        public async Task<IEnumerable<Document>> GetDocument(string documentId)
        {
            return await _context.Documents.Find( d=>d.DocumentId == documentId).Limit(100).ToListAsync();
        }

    }
}
