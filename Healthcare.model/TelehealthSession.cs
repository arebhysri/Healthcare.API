using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.model
{
    public class TelehealthSession
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Status { get; set; } // 0: Scheduled, 1: In Progress, 2: Completed, 3: Cancelled
    }
}
