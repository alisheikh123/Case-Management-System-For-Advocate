using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class tblExibits
    {
        #region
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Case No")]
        public int Caseid { get; set; }

        [Display(Name = "Order No")]
        public int Orderid { get; set; }

        [Display(Name = "Title")]
        public string PageTitle { get; set; }

        [Display(Name = "Exibit Date")]
        public DateTime ExibitDate { get; set; }

        [Display(Name = "Image")]
        public string imgurl { get; set; }

        #endregion


        #region
        [ForeignKey("Caseid")]
        public virtual tblCases TblCases { get; set; }

        [ForeignKey("Orderid")]
        public virtual tblOrder TblOrder { get; set; }


        #endregion
    }

}
