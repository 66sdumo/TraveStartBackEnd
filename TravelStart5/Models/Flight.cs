//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelStart5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flight
    {
        public int FlightId { get; set; }
        public string Airport { get; set; }
        public string Airline { get; set; }
        public string Time { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Date { get; set; }
        public string Class { get; set; }
    }
}