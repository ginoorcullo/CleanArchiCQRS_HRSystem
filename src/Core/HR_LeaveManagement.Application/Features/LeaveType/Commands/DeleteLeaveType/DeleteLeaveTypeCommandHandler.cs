using AutoMapper;
using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType {
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit> {
       
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository) {
            _leaveTypeRepository = leaveTypeRepository;
        }
        
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken) {
            //Validate incoming request

            //get leavetype to delete in database
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //verify if record exists
            if(leaveTypeToDelete == null )
                throw new Exceptions.NotFoundException(nameof(LeaveType), request.Id);

            //remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            //return Unit.Value
            return Unit.Value;

        }
    }
}
