using GraphQL.Conventions;
using System;

namespace GraphQLApi.Graph.Types
{

    [Description("FrameAttempt")]
    public class FrameAttemptGraphType
    {
        public Guid FrameProgressID { get; set; }
        public int Status { get; set; }
        public int NumStacks { get; set; }
        public int MinTime { get; set; }
        public string Address { get; set; }
        public string Captions { get; set; }
        public DateTime? TimeStarted { get; set; }
        public double TimeElapsed { get; set; }
    }
}
