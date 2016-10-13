//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvMrrDetail
    {
        public long MrrDetailID { get; set; }
        public long MrrID { get; set; }
        public long ItemID { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> AdditionalQty { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public int UnitID { get; set; }
        public Nullable<long> BatchID { get; set; }
        public Nullable<int> GradeID { get; set; }
        public Nullable<long> LotID { get; set; }
        public Nullable<bool> IsQcCompleted { get; set; }
        public Nullable<long> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateOn { get; set; }
        public string CreatePc { get; set; }
        public Nullable<long> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateOn { get; set; }
        public string UpdatePc { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<long> DeleteBy { get; set; }
        public Nullable<System.DateTime> DeleteOn { get; set; }
        public string DeletePc { get; set; }
    
        public virtual CmnUOM CmnUOM { get; set; }
        public virtual InvMrrMaster InvMrrMaster { get; set; }
        public virtual CmnItemMaster CmnItemMaster { get; set; }
    }
}
