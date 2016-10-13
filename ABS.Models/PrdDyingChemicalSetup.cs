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
    
    public partial class PrdDyingChemicalSetup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrdDyingChemicalSetup()
        {
            this.PrdDyingChemicalSetupDetails = new HashSet<PrdDyingChemicalSetupDetail>();
        }
    
        public long ChemicalSetupID { get; set; }
        public int ColorID { get; set; }
        public decimal Qty { get; set; }
        public int DepartmentID { get; set; }
        public int UserID { get; set; }
        public int UnitID { get; set; }
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
    
        public virtual CmnUOM CmnUOM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrdDyingChemicalSetupDetail> PrdDyingChemicalSetupDetails { get; set; }
        public virtual CmnItemColor CmnItemColor { get; set; }
        public virtual CmnUser CmnUser { get; set; }
    }
}
