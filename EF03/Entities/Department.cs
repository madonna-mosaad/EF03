using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Entities
{
    [Table("Departments", Schema = "dbo")]
    internal class Department
    {
        [Key]
        public int DId { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        public Instructor? Instructor { get; set; }
        [ForeignKey("Instructor")]
        public int? ins_Id { get; set; }
        public DateTime HiringDate { get; set; }
        [InverseProperty("Department")]
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        [InverseProperty("Department")]
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
