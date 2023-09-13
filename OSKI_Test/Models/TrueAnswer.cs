using System.Text.Json.Serialization;

namespace OSKI_Test.Models
{
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
