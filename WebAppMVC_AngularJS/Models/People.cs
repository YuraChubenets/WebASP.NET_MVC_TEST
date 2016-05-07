using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMVC_AngularJS.Models
{
    public class People
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(120, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(120, MinimumLength =1)]
        public string NickName { get; set; }
    }
}