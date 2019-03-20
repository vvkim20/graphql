using System.Collections.Generic;
using System.Threading.Tasks;

namespace Edgenuity.MongoDB
{
    public class Stack 
    {
        public int Order { get; set; }
        public List<Task> Tasks { get; set; }
    }

}
