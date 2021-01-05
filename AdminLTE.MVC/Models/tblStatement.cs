using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class tblStatement
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Case No")]
        public int caseid { get; set; }

        [Display(Name = "Witness Id")]
        public int witnid { get; set; }

        [Display(Name = "Order Id")]
        public int orderid { get; set; }

        [Display(Name = "Statement Date")]
        [DataType(DataType.Date)]
        public string StatementDate { get; set; }

        [ForeignKey("caseid")]
        public virtual tblCases TblCases { get; set; }
        [ForeignKey("witnid")]
        public virtual tblWitness TblWitness { get; set; }
        [ForeignKey("witnid")]
        public virtual tblOrder TblOrder { get; set; }
    }
}
