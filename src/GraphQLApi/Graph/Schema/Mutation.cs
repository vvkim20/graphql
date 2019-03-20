using AutoMapper;
using Entity;
using GraphQL.Conventions;
using GraphQLApi.Graph.Types;
using Edgenuity.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLApi.Graph.Schema
{
    internal sealed class Mutation
    {
        [Description ("Add FrameChainAttempt")]
        public FrameChainAttemptGraphType AddFrameChainAttempt([Inject]IFrameChainAttemptRepository frameChainAttemptRepository, [Description("User Name")] NonNull<string> userName)
        {
            //var doc = await documentRepo.CreateDocument(documentBody, userName);
            //frameChainAttemptRepository.AddFrameChainAttempt();
            return Mapper.Map<FrameChainAttemptGraphType>(frameChainAttemptRepository.AddFrameChainAttempt(userName));
        }

        [Description("Add Document")]
        public async Task<DocumentGraphType> AddDocument([Inject] IDocumentRepo documentRepo, 
                                                     [Inject] IDocumentRepository mongoDocRepo,
                                                     [Description("Body")] NonNull<string> documentBody,
                                                     [Description("UserName")] NonNull<string> userName)
        {
            var doc = await documentRepo.CreateDocument(documentBody, userName);
            mongoDocRepo.AddDocument(doc.DocumentId.ToString());
            return Mapper.Map<DocumentGraphType>(doc);
        }
    }
}
