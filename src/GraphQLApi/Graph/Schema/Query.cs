using AutoMapper;
using Edgenuity.ContentEngine.Entities;
using Entity;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using GraphQLApi.Graph.Model;
using GraphQLApi.Resp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApi.Graph.Schema
{
    [ImplementViewer(OperationType.Query)]
    internal sealed class Query
    {
        public async Task<IEnumerable<FrameChainAttemptModel>> FrameChainAttempts([Inject] IFrameChainAttemptRepository frameChainAttemptRepository) {
            var result = await frameChainAttemptRepository.GetFrameChainAttempts();
            return result.Select(m => Mapper.Map<FrameChainAttemptModel>(m));
        }

        public async Task<FrameChainAttemptModel> FrameChainAttempt([Inject] IFrameChainAttemptRepository frameChainAttemptRepository, [Description("UserName")] NonNull<string> userName)
        {
            var result = await frameChainAttemptRepository.GetFrameChainAttemptByUserName(userName);
            return Mapper.Map<FrameChainAttemptModel>(result);
        }

        public async Task<IEnumerable<DocumentModel>> Documents([Inject] IDocumentRepo documentRepo)
        {
            var result = await documentRepo.GetAllDocumentsAsync();
            
            return result.Select(m => Mapper.Map<DocumentModel>(m));
        }

        public async Task<IEnumerable<DocumentModel>> ApiDocuments([Inject] IApiRequest apiRequest)
        {
            var result = await apiRequest.GetDocuments();

            return result.Select(m => Mapper.Map<DocumentModel>(m));
        }

        public async Task<DocumentModel> ApiDocument([Inject] IApiRequest apiRequest, [Description("DocumentId")] int documentId)
        {
            var result = await apiRequest.GetDocument(documentId);

            return Mapper.Map<DocumentModel>(result);
        }


        public async Task<IEnumerable<DocumentModel>> ApiDocumentsByName([Inject] IApiRequest apiRequest, [Description("UserName")] string userName)
        {
            var result = await apiRequest.GetDocumentByUserName(userName);

            return result.Select(m => Mapper.Map<DocumentModel>(m));
        }

    }
}

