using FluentValidation;

namespace HR_LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType {
    public class UpdateLeaveTypeCommandValidator: AbstractValidator<UpdateLeaveTypeCommand> {

        public UpdateLeaveTypeCommandValidator() {

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Property} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{Property} should be less than 70 characters");

            RuleFor(p => p.DefaultDays)
                .LessThan(100).WithMessage("{Property} cannot be more than 100")
                .GreaterThan(1).WithMessage("{Property} cannot be less than 1");
           
        }
    }
}
