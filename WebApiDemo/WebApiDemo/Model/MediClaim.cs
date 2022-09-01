using System;
using System.Collections.Generic;

namespace WebApiDemo.Model
{
    public partial class MediClaim
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public int? Age { get; set; }
        public string? ClaimCause { get; set; }
    }
}
