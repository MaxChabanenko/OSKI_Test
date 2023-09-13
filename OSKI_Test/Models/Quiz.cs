using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSKI_Test.Models
{
    public class Quiz : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public string QuizName { get; set; }

        public List<Question> Questions { get; set; }
    }
}
