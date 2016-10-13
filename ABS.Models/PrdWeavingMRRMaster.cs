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
    
    public partial class PrdWeavingMRRMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrdWeavingMRRMaster()
        {
            this.PrdFinishingMRRMasters = new HashSet<PrdFinishingMRRMaster>();
        }
    
        public long WeavingMRRID { get; set; }
        public string WeavingMRRNo { get; set; }
        public int WeavingMRRTypeID { get; set; }
        public Nullable<System.DateTime> WeavingMRRDate { get; set; }
        public Nullable<int> DoffingNo { get; set; }
        public Nullable<long> ItemID { get; set; }
        public Nullable<long> MachineConfigID { get; set; }
        public Nullable<long> SetID { get; set; }
        public Nullable<long> SizeMRRID { get; set; }
        public Nullable<int> ShiftID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<decimal> UnitID { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> OperatorID { get; set; }
        public Nullable<bool> IsIssued { get; set; }
        public Nullable<bool> IsReceived { get; set; }
        public Nullable<int> IssuedDepartmentID { get; set; }
        public int StatusID { get; set; }
        public int CompanyID { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateOn { get; set; }
        public string CreatePc { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateOn { get; set; }
        public string UpdatePc { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> DeleteBy { get; set; }
        public Nullable<System.DateTime> DeleteOn { get; set; }
        public string DeletePc { get; set; }
        public Nullable<bool> IsFinishid { get; set; }
    
        public virtual PrdWeavingMRRMaster PrdWeavingMRRMaster1 { get; set; }
        public virtual PrdWeavingMRRMaster PrdWeavingMRRMaster2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrdFinishingMRRMaster> PrdFinishingMRRMasters { get; set; }
        public virtual CmnItemMaster CmnItemMaster { get; set; }
    }
}
