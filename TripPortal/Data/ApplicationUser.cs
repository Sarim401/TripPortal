﻿using Microsoft.AspNetCore.Identity;

namespace TripPortal.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
