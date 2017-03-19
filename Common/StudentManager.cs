using ExamSystem.DataAccess;
using OnlineExamSystem.DataAccess;

namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Timers;

   

    public static class StudentManager
    {
        private static DataService dataService;

        private static DateTime examEndTime;

        private static DateTime examStartTime;

        static StudentManager()
        {
            StudentList = new Dictionary<int, StudentInformation>();
            dataService = new DataService();
        }

        public static Dictionary<int, StudentInformation> StudentList { get; set; }

        public static byte[] ConvertMessageToStudentInformation(StudentInformation obj)
        {
            if (obj == null) return null;

            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public static QuestionAnswer ConvertMsgToQuestionAnswer(byte[] arrBytes)
        {
            var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            var obj = (QuestionAnswer)binForm.Deserialize(memStream);

            return obj;
        }

        public static byte[] ExtractQuestionAnswerFromClientMsg(QuestionAnswer obj)
        {
            if (obj == null) return null;

            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public static StudentInformation ExtractStudentInformationFromClientMsg(byte[] arrBytes)
        {
            var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            var obj = (StudentInformation)binForm.Deserialize(memStream);

            return obj;
        }


        public static ConnectionMessage GetConnectionMessageFromServer(byte[] arrBytes)
        {
            var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            var obj = (ConnectionMessage)binForm.Deserialize(memStream);

            return obj;
        }

        public static byte[] GetConnectionMessageForStudent()
        {
            var msg = string.Format(
                "Connection successful. Your exam will start on {0} and end on {1}",
                GetStartTime().ToString(),
                GetEndTime().ToString());
            var connectionMessage = new ConnectionMessage() { CustomMessage = msg };

            return GetByteArrayFromObject(connectionMessage);
        }

        public static void SaveAnswerIntoServer(StudentInformation student)
        {
            /*if (student.OperationType == 0)
            {
                if (!Directory.Exists(student.StudentId.ToString()))
                {
                    Directory.CreateDirectory(student.StudentId.ToString());

                    StudentList.Add(student.StudentId, student);


                    //TODO new implementation

                    var studentDb = new Student()
                    {
                        StudentId = student.StudentId,
                        ExamStartTime = examStartTime,
                        ExamEndTime = examEndTime
                    };

                    dataService.CreateStudentIfNotExists(studentDb);
                }

            }*/
            if (student.OperationType == 1)
            {
                // TODO; file Save
                var dirName = student.StudentId.ToString();

                var filePath = Path.Combine(dirName, dirName + ".txt");
                if (Directory.Exists(dirName))
                {
                    //File.WriteAllBytes(filePath, student.FileData);
                }

                // TODO new implementation. save answer
                var studentDb = new Student() { StudentId = student.StudentId, ExamTime = DateTime.UtcNow };

                dataService.UpdateStudent(studentDb);
            }
        }

        public static void SaveQuestionsIntoDatabaseFromFile()
        {
            var filePath = ConfigurationManager.AppSettings["filePath"];
            var fullFilePath = string.Format("{0}{1}.txt", AppDomain.CurrentDomain.BaseDirectory, filePath);

            var questions = new List<Question>();
            if (File.Exists(fullFilePath))
            {
                var lines = File.ReadLines(fullFilePath);
                foreach (var line in lines)
                {
                    var question = new Question() { QuestionText = line };
                    questions.Add(question);
                }
            }

            SaveQuestionsIntoDatabase(questions);
        }

        public static void SaveStudentInformation(StudentInformation student)
        {
            if (student.OperationType == 0)
            {
                if (!Directory.Exists(student.StudentId.ToString()))
                {
                    Directory.CreateDirectory(student.StudentId.ToString());

                    StudentList.Add(student.StudentId, student);

                    // TODO new implementation
                    var studentDb = new Student()
                                        {
                                            StudentId = student.StudentId,
                                            ExamStartTime = GetStartTime(),
                                            ExamEndTime = GetEndTime()
                    };

                    dataService.CreateStudentIfNotExists(studentDb);
                }
            }
        }

        public static void SendExamInformationToClient()
        {
            // TODO: Send exam info to client
            var timer = new Timer(1800000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        public static bool VerifyStudentId(int studentId)
        {
            var studentIdStart = int.Parse(ConfigurationManager.AppSettings["StudentIdRangeStart"]);
            var studentIdEnd = int.Parse(ConfigurationManager.AppSettings["StudentIdRangeEnd"]);

            return studentId >= studentIdStart && studentId <= studentIdEnd;
        }

        private static byte[] GetByteArrayFromObject(object obj)
        {
            if (obj == null) return null;

            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // if exam time is equal ro less than start time start sending questions to student one by one
        }

        private static void SaveQuestionsIntoDatabase(List<Question> questions)
        {
            dataService.InsertQuestionIntoDatabase(questions);
        }

        private static DateTime GetStartTime()
        {
            var startTime = ConfigurationManager.AppSettings["StartTime"];

            
            examStartTime = DateTime.Parse(startTime);
            return examStartTime;
        }
        private static DateTime GetEndTime()
        {
            var endTime = ConfigurationManager.AppSettings["EndTime"];
             
            return DateTime.Parse(endTime);
        }
        private static DateTime GetExamTime()
        {
            var examTime = ConfigurationManager.AppSettings["EndTime"];
            return DateTime.Parse(examTime);

        }


    }
}