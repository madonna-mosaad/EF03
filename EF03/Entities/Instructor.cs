using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Entities
{
    [Table("Instructors", Schema = "dbo")]
    internal class Instructor
    {
        [Key]
        public int InsId { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Name { get; set; }
        public double Bouns { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public int HourRate { get; set; }
        [InverseProperty("Instructors")]
        public Department? Department { get; set; }
        [ForeignKey("Department")]
        public int? Dept_Id { get; set; }
        public ICollection<Course_Inst> Courses { get; set; } = new HashSet<Course_Inst>();

    }
}
