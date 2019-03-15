using System;
using System.Collections.Generic;

namespace Edgenuity.ContentEngine.Entities
{
    public class FrameAttempt : MongoDbBaseObject
    {
        public Guid FrameProgressID { get; set; }
        public int Status { get; set; }
        public int NumStacks { get; set; }
        public int MinTime { get; set; }
        public string Address { get; set; }
        public string Captions { get; set; }
        public DateTime? TimeStarted { get; set; }

        [MongoDB.Bson.Serialization.Attributes.BsonDefaultValue(0.00)]
        [MongoDB.Bson.Serialization.Attributes.BsonIgnoreIfNull]
        public double TimeElapsed { get; set; }

        public List<StackAttempt> Stacks { get; set; }
    }

}
