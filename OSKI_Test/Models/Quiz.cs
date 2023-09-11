using System.ComponentModel.DataAnnotations.Schema;

namespace OSKI_Test.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }

        public List<Question> Questions { get; set; }
    }
}
