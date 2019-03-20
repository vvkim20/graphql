using System;
using System.Collections.Generic;
using MongoDB;

namespace Edgenuity.MongoDB
{
    public class FrameAttempt 
    {
        public Guid FrameProgressID { get; set; }
        public int Status { get; set; }
        public int NumStacks { get; set; }
        public int MinTime { get; set; }
        public string Address { get; set; }
        public string Captions { get; set; }
        public DateTime? TimeStarted { get; set; }

        public double TimeElapsed { get; set; }

        public List<StackAttempt> Stacks { get; set; }
    }

}
