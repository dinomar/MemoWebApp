using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoWebAppDAL.Models
{
    [Table("Memos")]
    public partial class Memo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [StringLength(128)]
        public string Title { get; set; }

        [StringLength(1028)]
        public string Text { get; set; }

        public bool Deleted { get; set; } = false;

        [ForeignKey("UserId")]
        public virtual AspNetUsers User { get; set; }
    }
}
