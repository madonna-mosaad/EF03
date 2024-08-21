using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Entities
{
    [Table("Stud_Course", Schema = "dbo")]
    internal class Stud_Course
    {
        [ForeignKey("Student")]
        [Key, Column(Order = 0)]
        public int? Stud_Id { get; set; }
        [ForeignKey("Course")]
        [Key, Column(Order = 1)]
        public int? Course_Id { get; set; }
        public double Grade { get; set; }
        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}
