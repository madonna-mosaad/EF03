using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Entities
{
    internal class Topic
    {
        [Key]
        public int TId { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [InverseProperty("Topic")]
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
