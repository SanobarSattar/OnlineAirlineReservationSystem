//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineAirlineReservationSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int Id { get; set; }
        public Nullable<int> ReservationId { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}
