using System;
using System.Collections.Generic;

namespace FrontendDemo.Models
{
    public partial class Claim
    {
        public int? Id { get; set; }
        public string? PatientName { get; set; }
        public int? Age { get; set; }
        public string? ClaimCause { get; set; }
    }
}
