using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class StudentInformation
    {
        public OperationType OperationType { get; set; }

        public ServerOperationType ServerOperationType { get; set; }
        public string ServerIPAddress { get; set; }
        public int StudentId { get; set; }
        public DateTime ExamStartTime { get; set; }

        public DateTime ExamEndTime { get; set; }

        public DateTime ExamTime { get; set; }

        public bool IsStudentIdValid { get; set; }

        public string StudentIdInvalidMessage { get; set; }

        public string StudentAlreadyRegisteredMessage { get; set; }
        public bool IsAlreadyRegistered { get; set; }

        public bool IsExamStarted { get; set; }
        public byte[] QuestionFileData { get; set; }

        public bool IsQuestionPaperRequested { get; set; }

        public string ExamStartedMessage { get; set; }

        public string ConnectionSuccessfulMessage { get; set; }

        public int BackUpInterValInMinute { get; set; }

        public bool  IsBackedUpAnswerAvailable { get; set; }
               
    }
}
