using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OSKI_Test.Models
{
    public class Option
    {
        public int OptionId { get; set; }

        [Required]
        public string Text { get; set; }

    }
}
