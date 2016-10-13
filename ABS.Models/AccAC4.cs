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
    
    public partial class AccAC4
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccAC4()
        {
            this.AccACDetails = new HashSet<AccACDetail>();
        }
    
        public int AC1Id { get; set; }
        public int AC2Id { get; set; }
        public int AC3Id { get; set; }
        public int Id { get; set; }
        public string AC4ManualCode { get; set; }
        public string AC4Name { get; set; }
        public Nullable<bool> Transfered { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public bool IsAccountLedger { get; set; }
    
        public virtual AccAC3 AccAC3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccACDetail> AccACDetails { get; set; }
    }
}
