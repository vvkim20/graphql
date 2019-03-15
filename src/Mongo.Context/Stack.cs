using System.Collections.Generic;
using System.Threading.Tasks;

namespace Edgenuity.ContentEngine.Entities
{
    public class Stack : MongoDbBaseObject
    {
        public int Order { get; set; }
        public List<Task> Tasks { get; set; }
    }

}
