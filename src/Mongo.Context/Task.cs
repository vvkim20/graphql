using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Edgenuity.ContentEngine.Entities
{
    public class Task : MongoDbBaseObject
    {
        public Guid Guid { get; set; }
        public bool IsQuestion { get; set; }
        public string Text { get; set; }
        public bool IsRequired { get; set; }
        public int? Points { get; set; }
    }
}
