using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.model
{
    public class Doctor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string LicenseNumber { get; set; }

        [Required]
        public string ExperienceYear { get; set; }

        [Required]
        public string AvailabilitySlot { get; set; }
    }
}
