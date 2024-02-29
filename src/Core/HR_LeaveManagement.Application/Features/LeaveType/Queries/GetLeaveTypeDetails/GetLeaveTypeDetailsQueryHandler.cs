using AutoMapper;
using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails {
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto> {

        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository) {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken) {
            //Get data from database
            var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.id);
            
            //Verify if record exists
            if(leaveTypeDetails == null ) {
                throw new Exceptions.NotFoundException(nameof(LeaveType), request.id);
            }

            //Transfer data objects to Dto
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetails);
            
            //return Dto
            return data;
        }
    }
}
