﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType {
    public class CreateLeaveTypeCommand: IRequest<int> {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
