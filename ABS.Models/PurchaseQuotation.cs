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
    
    public partial class PurchaseQuotation
    {
        public long QuotationID { get; set; }
        public string QuotationNo { get; set; }
        public Nullable<System.DateTime> QuotationDate { get; set; }
        public Nullable<long> RequisitionID { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> PartyID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> FreightCharge { get; set; }
        public Nullable<decimal> FOBValue { get; set; }
        public Nullable<int> TransportTypeID { get; set; }
        public Nullable<int> LoadingLocationID { get; set; }
        public Nullable<int> DischargeLocationID { get; set; }
        public Nullable<bool> IsConfirm { get; set; }
        public Nullable<long> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateOn { get; set; }
        public string CreatePc { get; set; }
        public Nullable<long> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateOn { get; set; }
        public string UpdatePc { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<long> DeleteBy { get; set; }
        public Nullable<System.DateTime> DeleteOn { get; set; }
        public string DeletePc { get; set; }
    }
}
