using FluentValidation;
using HR_LeaveManagement.Application.Contracts.Persistence;

namespace HR_LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType {
    public class UpdateLeaveTypeCommandValidator: AbstractValidator<UpdateLeaveTypeCommand> {
        
       private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository) {

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveTypeMustExist);

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Property} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{Property} should be less than 70 characters");

            RuleFor(p => p.DefaultDays)
                .LessThan(100).WithMessage("{Property} cannot be more than 100")
                .GreaterThan(1).WithMessage("{Property} cannot be less than 1");

            RuleFor(p => p)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave type already exists");


            _leaveTypeRepository = leaveTypeRepository;

        }

        private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token) {
            
            return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);

        }

        private async Task<bool> LeaveTypeMustExist(int arg1, CancellationToken token) {
            var result = await _leaveTypeRepository.GetByIdAsync(arg1);
            return result != null;
        }
    }
}
