using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubId { get; set; }

        public string SubName { get; set; }

        public int MaxMarks { get; set; }

        public int MarksObtained { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
    }
}
