using System.Text.Json.Serialization;

namespace OSKI_Test.Models
{/// <summary>
 /// Model for storing true answers
 /// This model isn't sent to API, so user shouldn't know true answers
 /// </summary>
    public class TrueAnswer
    {

        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }

        //for foreign keys
        [JsonIgnore]
        public Quiz Quiz { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
        [JsonIgnore]
        public Option Option { get; set; }
    }
}
