﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABS.Models.ViewModel.SystemCommon
{
    public class vmCmnUserWiseCompany
    {
        [Display(Name = "User Company I D")]
        [Required(ErrorMessage = "{0} is Required")]
        public Int64 UserCompanyID { get; set; }

        [Display(Name = "User I D")]
        public int? UserID { get; set; }

        [Display(Name = "Company I D")]
        public int? CompanyID { get; set; }
        public String CompanyName { get; set; }

        [Display(Name = "Create By")]
        public int? CreateBy { get; set; }

        [Display(Name = "Create On")]
        public DateTime? CreateOn { get; set; }

        [Display(Name = "Create Pc")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string CreatePc { get; set; }

        [Display(Name = "Update By")]
        public int? UpdateBy { get; set; }

        [Display(Name = "Update On")]
        public DateTime? UpdateOn { get; set; }

        [Display(Name = "Update Pc")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string UpdatePc { get; set; }

        [Display(Name = "Is Deleted")]
        [Required(ErrorMessage = "{0} is Required")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Delete By")]
        public int? DeleteBy { get; set; }

        [Display(Name = "Delete On")]
        public DateTime? DeleteOn { get; set; }

        [Display(Name = "Delete Pc")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string DeletePc { get; set; }
    }
}
