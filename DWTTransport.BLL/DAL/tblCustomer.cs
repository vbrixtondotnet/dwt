//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DWTTransport.BLL.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCustomer
    {
        public int CustID { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public string Name { get; set; }
        public Nullable<int> Colour { get; set; }
        public Nullable<bool> SysCode { get; set; }
        public string WorkingFolder { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<int> Gen_WorkingFolder { get; set; }
        public byte[] s_ColLineage { get; set; }
        public Nullable<int> s_Generation { get; set; }
        public Nullable<System.Guid> s_GUID { get; set; }
        public byte[] s_Lineage { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
