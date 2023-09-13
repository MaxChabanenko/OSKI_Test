using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OSKI_Test.Models
{
    public class Question : IEntity<int>
    {
        //guid possible
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public List<Option> Options { get; set; }

        [DefaultValue(null)]
        public int? SelectedOptionId { get; set; }

    }
    
}
