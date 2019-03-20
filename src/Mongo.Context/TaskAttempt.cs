using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgenuity.MongoDB
{
    public class TaskAttempt 
    {
        public Guid Guid;
        public bool IsQuestion;
        public bool Complete;
        public string Text;
        public int? Points;
        public bool IsRequired = false;
        public string SuspendedState = string.Empty;
        public List<AnswerAttempt> Answers = new List<AnswerAttempt>();

        public TaskAttempt() { }

        public TaskAttempt(Task task)
        {
            Guid = task.Guid;
            IsQuestion = task.IsQuestion;
            Complete = false;
            Text = task.Text;
            IsRequired = task.IsRequired;
            Points = task.Points ?? 1;
        }

        public static TaskAttempt CreatePreview(Task task)
        {
            TaskAttempt preview = new TaskAttempt(task);

            var answer = new AnswerAttempt()
            {
                PointsReceived = task.Points ?? 1
            };

            preview.Answers.Add(answer);

            return preview;
        }
    }

}
