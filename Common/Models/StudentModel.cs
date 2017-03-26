using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public DateTime? ExamStartTime { get; set; }

        public DateTime? ExamEndTime { get; set; }

        public DateTime? ExamTime { get; set; }

        public bool  IsBackupAvailable { get; set; }

        public string BackUpAnswerFilePath { get; set; }

        public string ActualAnswerFilePath { get; set; }

        public bool IsExamFinished { get; set; }
        public string StudentIpAddress { get; set; }  


    }
}
