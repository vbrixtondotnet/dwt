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
    
    public partial class tblTransaction
    {
        public int TID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public string Details { get; set; }
        public Nullable<int> Gen_Details { get; set; }
        public byte[] s_ColLineage { get; set; }
        public Nullable<int> s_Generation { get; set; }
        public Nullable<System.Guid> s_GUID { get; set; }
        public byte[] s_Lineage { get; set; }
    }
}
