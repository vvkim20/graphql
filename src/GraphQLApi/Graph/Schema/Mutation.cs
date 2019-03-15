using AutoMapper;
using Edgenuity.ContentEngine.Entities;
using Entity;
using GraphQL.Conventions;
using GraphQLApi.Graph.Model;
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
        public async Task<FrameChainAttemptModel> AddFrameChainAttempt([Inject]IFrameChainAttemptRepository frameChainAttemptRepository, [Description("User Name")] NonNull<string> userName)
        {
            //var doc = await documentRepo.CreateDocument(documentBody, userName);
            //frameChainAttemptRepository.AddFrameChainAttempt();
            return Mapper.Map<FrameChainAttemptModel>(frameChainAttemptRepository.AddFrameChainAttempt(userName));
        }

        [Description("Add Document")]
        public async Task<DocumentModel> AddDocument([Inject] IDocumentRepo documentRepo, 
                                                     [Description("Body")] NonNull<string> documentBody,
                                                     [Description("UserName")] NonNull<string> userName)
        {
            var doc = await documentRepo.CreateDocument(documentBody, userName);            
            return Mapper.Map<DocumentModel>(doc);
        }
    }
}
