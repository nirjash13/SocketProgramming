namespace Common
{
    using System;

    [Serializable]
    public class QuestionAnswer
    {
        public int QuestionId { get; set; }

        public int StudentId { get; set; }

        public string Answer { get; set; }

        public DateTime AnsweredTime { get; set; }
    }
}