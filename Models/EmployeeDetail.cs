using System;
using System.Collections.Generic;

#nullable disable

namespace BookAppointment.API.Models
{
    public partial class EmployeeDetail
    {
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
