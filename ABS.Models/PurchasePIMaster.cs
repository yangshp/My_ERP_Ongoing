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
    
    public partial class PurchasePIMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchasePIMaster()
        {
            this.PurchaseTCs = new HashSet<PurchaseTC>();
        }
    
        public long PIID { get; set; }
        public string PINo { get; set; }
        public Nullable<System.DateTime> PIDate { get; set; }
        public string RefPINo { get; set; }
        public Nullable<long> RequisitionID { get; set; }
        public Nullable<long> CSID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<bool> IsPartialShipment { get; set; }
        public Nullable<bool> IsTransShipment { get; set; }
        public Nullable<System.DateTime> LastShipmentDate { get; set; }
        public Nullable<int> AdvisingBankID { get; set; }
        public Nullable<int> AdvisingBankBranchID { get; set; }
        public string BankAccountNo { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseTC> PurchaseTCs { get; set; }
    }
}
