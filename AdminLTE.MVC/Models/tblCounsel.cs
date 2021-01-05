using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class tblCounsel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int barid { get; set; }

        [Display(Name = "Bar Name")]
        public string barName { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Image")]
        public string imgurl { get; set; }
    }
}
