using AutoMapper;
using Edgenuity.ContentEngine.Entities;
using GraphQL.Conventions;
using GraphQL.DataLoader;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLApi.Graph.Model
{
    [Description("FrameChainAttempt")]
    public class FrameChainAttemptModel 
    {
        public Guid Id { get; set; }
        public Guid CreateById { get; set; }
        public string DeleteById { get; set; }
        public string ModifyById { get; set; }
        public Guid EnrollmentKey { get; set; }
        public Guid LearningObjectKey { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public bool Complete { get; set; }
        public decimal Score { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ActivityTime { get; set; }
        public bool UseProxy { get; set; }
        public int DocumentId { get; set; }
        public int CurrentFrameOrder { get; set; }

        public FrameAttemptModel[] Frames { get; set; }        
    }
}
