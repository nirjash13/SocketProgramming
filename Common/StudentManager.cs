using Common.Models;
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

        public static DateTime examEndTime;

        public static DateTime examStartTime;

        public static string StudentQuestionFolder;


        private static Dictionary<int, StudentModel> ConnectedStudentList; 

        static StudentManager()
        {
            StudentList = new Dictionary<int, StudentInformation>();
            dataService = new DataService();
            ConnectedStudentList = new Dictionary<int, StudentModel>();

            var programData = System.Environment.
                             GetFolderPath(
                                 Environment.SpecialFolder.CommonApplicationData
                             );
            StudentQuestionFolder = Path.Combine(programData, "StudentFolder");
        }

        public static Dictionary<int, StudentInformation> StudentList { get; set; }
        public static string FullQuestionFilePath { get; set; }

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

        public static bool CheckIfStudentAlreadyConnectedOnce(int studentId)
        {
            var studentExists = ConnectedStudentList.ContainsKey(studentId);
            if (studentExists)
            {
                return true;
            }
            return false;
        }

        public static void AddStudentToList(StudentInformation studentInformation)
        {
            var studentModel = new StudentModel
            {
                StudentId = studentInformation.StudentId,
                ExamEndTime = studentInformation.ExamEndTime,
                ExamStartTime = studentInformation.ExamStartTime,
                ExamTime = DateTime.UtcNow,
                IsExamFinished = false,
                IsBackupAvailable = false,
                StudentIpAddress = studentInformation.IPAddress
            };

            ConnectedStudentList.Add(studentInformation.StudentId, studentModel);
        }

        public static StudentInformation GetStudentInformationFromConnectedList(int studentId)
        {
            

            StudentModel studentModel = null;

            ConnectedStudentList.TryGetValue(studentId, out studentModel);

            if (studentModel == null)
            {
                return null;
            }

            var student = new StudentInformation
            {
                StudentId = studentModel.StudentId,
                IPAddress = studentModel.StudentIpAddress,
                   
            };

            return student;
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


        public static byte[] GetInValidStudentIdMessage(StudentInformation student)
        {
            student.IsStudentIdValid = false;
            var studentIdStart = int.Parse(ConfigurationManager.AppSettings["StudentIdRangeStart"]);
            var studentIdEnd = int.Parse(ConfigurationManager.AppSettings["StudentIdRangeEnd"]);

            student.StudentIdInvalidMessage =
                string.Format("Invalid Student Id! Please Send a valid studentId in the range from {0} to {1}",
                    studentIdStart, studentIdEnd);

            var data = GetByteArrayFromObject(student);

            return data;
        }

        public static bool IsExamStarted()
        {
            var startTime = GetStartTime();
            var endTime = GetEndTime();
            var currentTime = DateTime.Now;
            return currentTime >= startTime;
        }

        public static byte[] GetQuestionForStudent(StudentInformation student)
        {
            var file = FullQuestionFilePath;

            var fileData = File.ReadAllBytes(file);

            //var examStartedMessage =
            //string.Format("Exam has started! Please save the question file and click finish when done!");

            var examStartedMsg = string.Format("Your exam is started. please save the question file!");

            var studentInfo = new StudentInformation
            {
                StudentId = student.StudentId,
                IPAddress = student.IPAddress,
                //ExamTime = student.ExamTime,
                ExamStartTime = student.ExamStartTime,
                ExamEndTime = student.ExamEndTime,
                IsAlreadyRegistered = student.IsAlreadyRegistered,
                IsExamStarted = student.IsExamStarted,
                ExamStartedMessage = examStartedMsg,
                IsStudentIdValid = student.IsStudentIdValid,
                StudentAlreadyRegisteredMessage = student.StudentAlreadyRegisteredMessage,
                QuestionFileData = fileData
            };

            var serverData = GetByteArrayFromObject(studentInfo);

            return serverData;

        }

        public static byte[] GetExamTimeForStudent(StudentInformation student)
        {
            student.ExamStartTime = GetStartTime();
            student.ExamEndTime = GetEndTime();

            return GetByteArrayFromObject(student);
        }
    }
}