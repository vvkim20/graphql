using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgenuity.ContentEngine.Entities
{
    public class StackAttempt : MongoDbBaseObject
    {
        public Guid StackProgressID;
        public int Order = 0;
        public bool Complete = false;
        public bool Attempted = false;

        public List<TaskAttempt> Tasks = new List<TaskAttempt>();

        public StackAttempt() { }

        public StackAttempt(Stack stack)
        {
            StackProgressID = Guid.NewGuid();
            Order = stack.Order;
            Complete = false;

            foreach (var task in stack.Tasks)
            {
                Tasks.Add(new TaskAttempt(task));
            }
        }

        public static StackAttempt CreatePreview(Stack stack)
        {
            StackAttempt preview = new StackAttempt()
            {
                StackProgressID = Guid.NewGuid(),
                Order = stack.Order,
                Complete = false
            };

            foreach (var task in stack.Tasks)
            {
                preview.Tasks.Add(TaskAttempt.CreatePreview(task));
            }

            return preview;
        }
    }

}
