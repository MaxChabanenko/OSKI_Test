using System.Text.Json.Serialization;

namespace OSKI_Test.Models
{
    public class AssignedQuiz
    {
        public int QuizId { get; set; }
        public string UserId { get; set; }
        public int Score { get; set; }

        public List<Question> CorrectQuestions { get; set; }

        [JsonIgnore]
        public Quiz Quiz { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }


    }
}
