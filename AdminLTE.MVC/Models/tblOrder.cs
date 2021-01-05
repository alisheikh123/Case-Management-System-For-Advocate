using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class tblOrder
    {
        #region
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Case No")]
        public int Caseid { get; set; }

        [Display(Name = "Order Type")]
        public orderType orderType { get; set; } 

        //Auto Generated Here Add the Function which work RunTime
        [Display(Name = "Order No")]
        public string OrderNo { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Hearing Date")]
        public DateTime hearingDate { get; set; }

        [Display(Name = "Next Proceeding")]
        public string NextProceeding { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }




        #endregion

        #region
        [ForeignKey("Caseid")]
        public virtual tblCases TblCases { get; set; }

       
        #endregion
    }
    public enum orderType
    {
        NormalOrder= 1,
        FinalOrder=2
        


    }
}
