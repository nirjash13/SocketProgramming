namespace OnlineExamSystem.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Answer
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public bool IsAnswered { get; set; }

        public int StudentId { get; set; }

        public int QuestionId { get; set; }
    }
}
