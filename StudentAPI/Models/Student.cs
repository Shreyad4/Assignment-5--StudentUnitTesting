using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace StudentAPI.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        public string Name { get; set; } = null!;

        public string? Class { get; set; }

        public string? Address { get; set; }

        public List<Subject> Subject { get; set; }
        
    }
}
