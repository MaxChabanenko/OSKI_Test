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
        /// <summary>
        /// Later SelectedOptionId is compared with correct answer in DB and if true, question added to result as correct
        /// </summary>
        [DefaultValue(null)]
        public int? SelectedOptionId { get; set; }

    }
    
}
