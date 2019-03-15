using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgenuity.ContentEngine.Entities
{
    public abstract class MongoDbBaseObject
    {
        public Guid Key { get; set; }
    }
}
