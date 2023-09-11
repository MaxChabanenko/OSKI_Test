using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OSKI_Test.Models
{
    public class Question
    {
        //guid possible
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public List<Option> Options { get; set; }

    }
    
}
