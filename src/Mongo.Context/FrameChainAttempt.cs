using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Edgenuity.MongoDB
{
    public class FrameChainAttempt
    {
        public Guid Key { get; set; }
        [BsonId]
        public Guid Id { get; set; }
        public Guid CreateById { get; set; }
        public BsonDocument DeleteById { get; set; }
        public string ModifyById { get; set; }
        public Guid EnrollmentKey { get; set; }
        public Guid LearningObjectKey { get; set; }
        public DateTime CreateDate { get; set; }
        public BsonDocument DeleteDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Message { get; set;  }
        public bool Complete { get; set; }
        public decimal Score { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int DocumentId { get; set; }
        public int ActivityTime { get; set; }
        public bool UseProxy { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// Zero indexed
        /// </summary>
        public int CurrentFrameOrder { get; set; }

        public FrameAttempt[] Frames { get; set; }

        //public FrameChainAttempt(FrameChainActivity activity, Guid userKey, Guid resultKey)
        //{
        //    Key = resultKey;
        //    LearningObjectKey = activity.Key;
        //    EnrollmentKey = userKey;
        //    CurrentFrameOrder = 0;
        //    Width = activity.Width;
        //    Height = activity.Height;
        //    Frames = new List<FrameAttempt>();
        //    UseProxy = activity.UseProxy;
        //    foreach (var frame in activity.Frames)
        //    {
        //        Frames.Add(new FrameAttempt());
        //    }
        //}
    }
}
