using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class tblWitness
    {

        #region
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Case No")]
        public int Caseid { get; set; }

        [Display(Name = "Witness Type")]
        public witnessType witnessType { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Display(Name = "CNIC")]
        public string CNIC { get; set; }

        [Display(Name = "Designation")]
        public string designation { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }


        [Display(Name = "Exibit Date")]
        public DateTime ExibitDate { get; set; }

        [Display(Name = "Image")]
        public string imgurl { get; set; }


        [ForeignKey("Caseid")]
        public virtual tblCases TblCases { get; set; }
        #endregion
    }
public enum witnessType
{
    Official = 1,
    Private = 2



}
}
