//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SOP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public int Schedule_ID { get; set; }
        public string Class_ID { get; set; }
        public Nullable<int> Day_ID { get; set; }
        public Nullable<int> Slot_ID { get; set; }
        public Nullable<int> Subject_ID { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Day Day { get; set; }
        public virtual Slot Slot { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
