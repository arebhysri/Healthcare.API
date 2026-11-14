using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.model
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime VisitedDate { get; set; }
        public string Notes { get; set; }
        public string Attachments { get; set; } // Could be a JSON string or a path to the file(s)
    }
}
