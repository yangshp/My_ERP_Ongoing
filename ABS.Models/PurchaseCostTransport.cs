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
    
    public partial class PurchaseCostTransport
    {
        public long TransportCostID { get; set; }
        public Nullable<long> CostID { get; set; }
        public Nullable<int> CarrierAgentID { get; set; }
        public Nullable<int> LoadingLocationID { get; set; }
        public Nullable<int> DischargeLocationID { get; set; }
        public Nullable<int> VehicleID { get; set; }
        public Nullable<int> NoOfVehicle { get; set; }
        public Nullable<decimal> GoodsQtyPerVehicle { get; set; }
        public Nullable<int> PackingUnitID { get; set; }
        public Nullable<decimal> FarePerVehicle { get; set; }
        public Nullable<int> CurrencyID { get; set; }
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
    }
}
