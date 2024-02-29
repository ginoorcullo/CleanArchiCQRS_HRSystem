using HR_LeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Domain {
    public class LeaveType: BaseEntity<int> {
                
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
