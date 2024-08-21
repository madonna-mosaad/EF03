using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Entities
{
    [Table("Course_Inst", Schema = "dbo")]
    internal class Course_Inst
    {
        [ForeignKey("Course")]
        [Key, Column(Order = 0)]
        public int? Course_Id { get; set; }
        [ForeignKey("Instructor")]
        [Key, Column(Order = 1)]
        public int? Ins_Id { get; set; }
        public int Evaluate { get; set; }
        public Course? Course { get; set; }
        public Instructor? Instructor { get; set; }
    }
}
