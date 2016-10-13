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
    
    public partial class PurchasePIDetail
    {
        public long PIDetailID { get; set; }
        public Nullable<long> PIID { get; set; }
        public Nullable<long> ItemID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> FreightCharge { get; set; }
        public Nullable<decimal> FOBValue { get; set; }
        public Nullable<int> OriginCountryID { get; set; }
        public string HSCode { get; set; }
        public Nullable<int> PackingUnitID { get; set; }
        public Nullable<decimal> PackingQty { get; set; }
        public Nullable<decimal> GrossWeight { get; set; }
        public Nullable<decimal> NetWeight { get; set; }
        public Nullable<int> WeightUnitID { get; set; }
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
    }
}
