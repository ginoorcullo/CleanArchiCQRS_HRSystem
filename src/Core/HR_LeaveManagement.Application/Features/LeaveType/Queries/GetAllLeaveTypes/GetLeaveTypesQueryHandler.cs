﻿using AutoMapper;
using HR_LeaveManagement.Application.Contracts.Logging;
using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR_LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes {
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>> {

        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        
        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository) {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken) {

            
            //Query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            //convert data objeccts to DTO objects
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            //return list of DTO object
            _logger.LogInformation("Leave types were retrieved succssfully.");
            return data;
        }
    }
}
