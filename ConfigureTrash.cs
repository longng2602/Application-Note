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
    
    public partial class ConfigureTrash
    {
        public string TrashID { get; set; }
        public string FontTrash { get; set; }
        public Nullable<int> SizeTrash { get; set; }
        public Nullable<int> Boldtxt { get; set; }
        public Nullable<int> Italictxt { get; set; }
        public Nullable<int> Underlinetxt { get; set; }
        public Nullable<int> Striketxt { get; set; }
        public Nullable<int> Colortxt { get; set; }
    
        public virtual Trash Trash { get; set; }
    }
}
