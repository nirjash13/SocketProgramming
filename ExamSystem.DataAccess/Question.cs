namespace OnlineExamSystem.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question
    {
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public string AnswerText { get; set; }
    }
}
