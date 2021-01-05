using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class tblDate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "CaseNo")]
        public int Caseid { get; set; }

        //Auto Generated Here Add the Function which work RunTime
        [Display(Name = "court Name")]
        public int Courtid { get; set; }


        [Display(Name = "Client Name")]
        public int clientId { get; set; }

        [Display(Name = "Next Expected Date")]
        [DataType(DataType.Date)]
        public string NextExpectedDate { get; set; }

        [Display(Name = "Case Stage")]
        public string casestage { get; set; }


        [ForeignKey("clientId")]
        public virtual tblClients TblClients { get; set; }

        [ForeignKey("Courtid")]
        public virtual tblcourt Tblcourt { get; set; }

        [ForeignKey("Caseid")]
        public virtual tblCases TblCases { get; set; }


    }
}
