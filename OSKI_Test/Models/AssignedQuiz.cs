using System.Text.Json.Serialization;

namespace OSKI_Test.Models
{/// <summary>
 /// Result model with score and correct questions
 /// User shouldnt know where exaclty (in options) he was right or wrong. The right ones (questions) are saved here - the rest are wrong
 /// </summary>
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
