//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using ABS.Models;

namespace ABS.Web.ViewModels
{
    public class ViewModelAC1
    {
        //public AC1()
        //{
        //    this.AC2 = new HashSet<AC2>();
        //}
    
        public int Id { get; set; }
        [DisplayName("Name (Level-1)")]
        public string AC1Name { get; set; }
         [DisplayName("Code (Level-1)")]
        public string AC1ManualCode { get; set; }
        public bool Transfered { get; set; }
        public string AddedBy { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<AccAC2> AC2 { get; set; }


        public AccAC1 AC1ViewModel()
        {

            var AC1 = new AccAC1();
            AC1.Id = this.Id;
            AC1.AC1Name = this.AC1Name;

            return AC1;
        }

    }


     
}
