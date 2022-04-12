using System;
using System.Collections.Generic;

#nullable disable

namespace BookAppointment.API.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
    }
}
