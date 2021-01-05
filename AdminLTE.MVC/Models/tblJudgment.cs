using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class tblJudgment
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "CaseNo")]
        public int caseid { get; set; }

        [Display(Name = "Court Id")]
        public int courtid { get; set; }

        [Display(Name = "DateofDecision")]
        [DataType(DataType.Date)]
        public string DateofDecision { get; set; }

        [ForeignKey("caseid")]
        public virtual tblCases TblCases { get; set; }
        [ForeignKey("courtid")]
        public virtual tblcourt Tblcourt { get; set; }

    }
}
