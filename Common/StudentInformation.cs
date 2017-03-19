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
        public int OperationType { get; set; }
        public string IPAddress { get; set; }
        public int StudentId { get; set; }
        public DateTime ExamStartTime { get; set; }

        public DateTime ExamEndTime { get; set; }

        public DateTime ExamTime { get; set; }
               
    }
}
