using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class tblCases
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Case Category")]
        public int CaseCatgoryid { get; set; }

        //Auto Generated Here Add the Function which work RunTime
        [Display(Name = "Case No")]
        public string CaseNo { get; set; }

        [EnumDataType(typeof(caseType))]
        [Display(Name = "Case Nature")]
        public caseType Type { get; set; } 

        [Display(Name = "Case Title")]
        public string Title { get; set; }

        [Display(Name = "Client Name")]
        public int ClientId { get; set; }


        [Display(Name = "Court Name")]
        public int courtid { get; set; }

        [Display(Name = "Opposite Name")]
        public string oppositeName { get; set; }

        [Display(Name = "Date of Institution")]
        public DateTime dateInstitution { get; set; }

        [Display(Name = "File No")]
        public string File { get; set; }


        

        #region
        [ForeignKey("CaseCatgoryid")]
        public virtual tblcaseCategory TblcaseCategory { get; set; }

        [ForeignKey("courtid")]
        public virtual tblcourt Tblcourt { get; set; }

        [ForeignKey("ClientId")]
        public virtual tblClients TblClients { get; set; }
        #endregion
    }
     public enum caseType 
    {
        Civil,
        Criminal,
        Other
        
    
    }
}
