using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgenuity.ContentEngine.Entities
{
    public class AnswerAttempt : MongoDbBaseObject
    {
        public string Answer = "";
        public int PointsReceived = 0;
    }
}
