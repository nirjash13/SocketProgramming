using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using OnlineExamSystem.DataAccess;

namespace ExamSystem.DataAccess
{
    public class DataService
    {
        public void InsertQuestionIntoDatabase(List<Question> questions)
        {
            using (var context = new OnlineExamSystem())
            {
                var dbQuestions = context.Questions.ToList();
                context.Questions.RemoveRange(dbQuestions);

                //context.SaveChanges();
                //dbQuestions = context.Questions.ToList();
                context.Questions.AddRange(questions);

                context.SaveChanges();
            }
            
        }

        public void InsertAnswerIntoDatabase(Question question)
        {
            using (var context = new OnlineExamSystem())
            {
                context.Questions.Add(question);

                context.SaveChanges();
            }
        }
        /*public Question GetNextQuestionFromDB()
        {
            using (var context = new ExamSystem())
            {
                var questions = context.Questions.Where(x => x.IsAnswered == false).OrderBy(o => o.Id);

                return questions.FirstOrDefault();
            }
        }*/

        public void CreateStudentIfNotExists(Student student)
        {
            using (var context = new OnlineExamSystem())
            {
                var std = context.Students.Where(x => x.StudentId == student.StudentId).SingleOrDefault();

                if (std == null)
                {
                    context.Students.Add(student);

                    var questions = context.Questions;

                    var answers = new List<Answer>();
                    foreach (var question in questions)
                    {
                        var answer = new Answer
                        {
                            StudentId = student.Id,
                            QuestionId = question.Id,
                            IsAnswered = false

                        };

                        answers.Add(answer);
                    }

                    context.Answers.AddRange(answers);


                    context.SaveChanges();
                }
            }
        }


        public Student GetStudentById(int id)
        {
            using (var context = new OnlineExamSystem())
            {
                var student = context.Students.SingleOrDefault(x => x.StudentId == id);

                return student;
            }
        }

        public List<Student> GetAllStudents()
        {
            using (var context = new OnlineExamSystem())
            {
                return context.Students.ToList();
            }
        }


        public void UpdateStudent(Student student)
        {
            using (var context = new OnlineExamSystem())
            {
                var std = context.Students.Where(x => x.StudentId == student.StudentId).SingleOrDefault();

                if (std != null)
                {
                    context.Students.Remove(std);
                    context.Students.Add(student);
                    context.SaveChanges();
                }
            }
        }

        public  void SaveQuestionsIntoDatabaseFromFile()
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

            InsertQuestionIntoDatabase(questions);
        }
        
    }
}