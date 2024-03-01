using AutoMapper;
using HR_LeaveManagement.Application.Contracts.Logging;
using HR_LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType {
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int> {

        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<CreateLeaveTypeCommandHandler> _logger;
        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<CreateLeaveTypeCommandHandler> logger) {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken) {
            //Validation
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid) {
                _logger.LogWarning("Validation error in Create {1}", nameof(LeaveType));
                throw new Exceptions.BadRequestException("Invalid Leavetype", validationResult);
            }

            //Convert to domain entity object
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
            //Add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            //return record id
            return leaveTypeToCreate.Id;
        }
    }
}
