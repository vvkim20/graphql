using AutoMapper;
using Edgenuity.MongoDB;
using Entity;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using GraphQLApi.Graph.Types;
using GraphQLApi.Resp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLApi.Graph.Schema
{
    [ImplementViewer(OperationType.Query)]
    internal sealed class Query
    {
        public async Task<IEnumerable<FrameChainAttemptGraphType>> FrameChainAttempts([Inject] IFrameChainAttemptRepository frameChainAttemptRepository) {
            var result = await frameChainAttemptRepository.GetFrameChainAttempts();
            return result.Select(m => Mapper.Map<FrameChainAttemptGraphType>(m));
        }

        public async Task<FrameChainAttemptGraphType> FrameChainAttempt([Inject] IFrameChainAttemptRepository frameChainAttemptRepository, [Description("UserName")] NonNull<string> userName)
        {
            var result = await frameChainAttemptRepository.GetFrameChainAttemptByUserName(userName);
            return Mapper.Map<FrameChainAttemptGraphType>(result);
        }

        public async Task<IEnumerable<DocumentGraphType>> Documents([Inject] IDocumentRepo documentRepo)
        {
            var result = await documentRepo.GetAllDocumentsAsync();
            
            return result.Select(m => Mapper.Map<DocumentGraphType>(m));
        }

        public async Task<IEnumerable<DocumentGraphType>> ApiDocuments([Inject] IApiRequest apiRequest)
        {
            var result = await apiRequest.GetDocuments();

            return result.Select(m => Mapper.Map<DocumentGraphType>(m));
        }

        public async Task<DocumentGraphType> ApiDocument([Inject] IApiRequest apiRequest, [Description("DocumentId")] int documentId)
        {
            var result = await apiRequest.GetDocument(documentId);

            return Mapper.Map<DocumentGraphType>(result);
        }


        public async Task<IEnumerable<DocumentGraphType>> ApiDocumentsByName([Inject] IApiRequest apiRequest, [Description("UserName")] string userName)
        {
            var result = await apiRequest.GetDocumentByUserName(userName);

            return result.Select(m => Mapper.Map<DocumentGraphType>(m));
        }

    }
}

