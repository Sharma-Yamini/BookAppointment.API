using System;
using System.Collections.Generic;

#nullable disable

namespace BookAppointment.API.Models
{
    public partial class DoctorDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string MobileNo { get; set; }
        public string Experience { get; set; }
        public DateTime? Availability { get; set; }
    }
}
