//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyNote.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trash
    {
        public Nullable<System.DateTime> SDate { get; set; }
        public string NodeID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Nullable<System.DateTime> DeDate { get; set; }
        public string TrashID { get; set; }
    
        public virtual LoginUser LoginUser { get; set; }
        public virtual ConfigureTrash ConfigureTrash { get; set; }
    }
}
