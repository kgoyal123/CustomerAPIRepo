﻿namespace CustomerAPIProj.Models.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string CustName { get; set; }
        public string CustAge { get; set; }
        public string Email { get; set; }
    }
}
