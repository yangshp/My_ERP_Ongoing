﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABS.Models.ViewModel.SystemCommon
{
   public class vmCmnWorkFlowDetail
    {
        public int? UserTeamID { get; set; }
         
        public int WorkFlowDetailID { get; set; }
         
        public int WorkFlowID { get; set; }
         
        public int StatusID { get; set; }
         
        public int EmployeeID { get; set; }
         
        public int Sequence { get; set; }
         
        public int CompanyID { get; set; }
        public int? DBID { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string CreatePc { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public string UpdatePc { get; set; }
         
        public bool IsDeleted { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteOn { get; set; }
        public string DeletePc { get; set; }
         
        public bool Transfer { get; set; }
    }
}
