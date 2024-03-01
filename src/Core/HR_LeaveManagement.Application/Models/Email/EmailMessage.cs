using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Models.Email {
    public class EmailMessage {
        public string To { get; set; } = string.Empty;
        public string Subhect { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}