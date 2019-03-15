using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLApi.Graph.Model
{
    public class StackAttemptModel
    {
        public Guid StackProgressID { get; set; }
        public int Order { get; set; }
        public bool Complete { get; set; }
        public bool Attempted { get; set; }
    }
}
