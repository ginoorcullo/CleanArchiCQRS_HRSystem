﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes {
    public record GetLeaveTypesQuery: IRequest<List<LeaveTypeDto>>;
}