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
    
    public partial class PrdSizingMRRMachineStop
    {
        public long SizeMachineStopID { get; set; }
        public long SizeMachineStopMasterID { get; set; }
        public System.DateTime StopDate { get; set; }
        public int ShiftID { get; set; }
        public int StopID { get; set; }
        public string Description { get; set; }
        public Nullable<long> MachineID { get; set; }
        public Nullable<System.TimeSpan> StopTime { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<int> StopInMin { get; set; }
        public int CompanyID { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateOn { get; set; }
        public string CreatePc { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateOn { get; set; }
        public string UpdatePc { get; set; }
        public Nullable<bool> IsNextDate { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> DeleteBy { get; set; }
        public Nullable<System.DateTime> DeleteOn { get; set; }
        public string DeletePc { get; set; }
    
        public virtual HRMShift HRMShift { get; set; }
        public virtual PrdBWSlist PrdBWSlist { get; set; }
    }
}
