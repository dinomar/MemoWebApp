using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemoWebApp.Models
{
    //public class MemoViewModels
    //{
    //    [Required]
    //    [StringLength(128)]
    //    public string Title { get; set; }

    //    [Required]
    //    [StringLength(1028)]
    //    public string Text { get; set; }
    //}

    public class MemoCreateViewModel
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(1028)]
        public string Text { get; set; }
    }

    public class MemoEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(1028)]
        public string Text { get; set; }
    }
}