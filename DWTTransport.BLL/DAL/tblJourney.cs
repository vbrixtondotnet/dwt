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
    
    public partial class tblJourney
    {
        public int ID { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string Journey { get; set; }
        public Nullable<decimal> Base { get; set; }
        public Nullable<int> Gen_Journey { get; set; }
        public byte[] s_ColLineage { get; set; }
        public Nullable<int> s_Generation { get; set; }
        public Nullable<System.Guid> s_GUID { get; set; }
        public byte[] s_Lineage { get; set; }
    }
}
