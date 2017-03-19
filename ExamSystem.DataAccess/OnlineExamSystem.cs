using System.Data.Entity;
using OnlineExamSystem.DataAccess;

namespace ExamSystem.DataAccess
{
    using System;
    
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineExamSystem : DbContext
    {
        public OnlineExamSystem()
            : base("name=OnlineExamSystem")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
