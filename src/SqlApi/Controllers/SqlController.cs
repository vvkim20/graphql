using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SqlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlController : ControllerBase
    {
        private IDocumentRepo _documentRepo;
        public SqlController(IDocumentRepo documentRepo)
        {
            _documentRepo = documentRepo;
        }
        
        // GET api/sql
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetAllDocuments()
        {
            var result = await _documentRepo.GetAllDocumentsAsync();
            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            return await _documentRepo.GetDcoument(id);
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocumentByUserName(string username)
        {
            var result = await _documentRepo.GetDocumentByUsernameAsync(username);
            return result.ToList();
        }
    }
}
