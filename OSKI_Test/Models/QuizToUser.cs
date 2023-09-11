using System.Text.Json.Serialization;

namespace OSKI_Test.Models
{
    public class QuizToUser
    {
        public int QuizId { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public Quiz Quiz { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
