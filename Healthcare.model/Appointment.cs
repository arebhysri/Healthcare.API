using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.model
{
    public class Appointment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppoinmentDate { get; set; }

        [Required]
        public int Status { get; set; } // 0: Pending, 1: Confirmed, 2: Cancelled, 3: Completed

        [Required]
        public int Type { get; set; } // 0: In-person, 1: Telemedicine

    }
}
