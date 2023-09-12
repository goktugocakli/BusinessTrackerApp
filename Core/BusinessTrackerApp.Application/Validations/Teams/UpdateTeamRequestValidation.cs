using System;
using BusinessTrackerApp.Application.ViewModels.Team;
using FluentValidation;

namespace BusinessTrackerApp.Application.Validations.Teams
{
    public class UpdateTeamRequestValidation : AbstractValidator<UpdateTeamRequestVM>
	{
		public UpdateTeamRequestValidation()
		{
            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull()
                .Matches(ValidationConstants.GuidRegex);

            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(t => t.DepartmentId)
                .NotEmpty()
                .NotNull()
                .Matches(ValidationConstants.GuidRegex);

            RuleFor(t => t.LeaderId)
                .Matches(ValidationConstants.GuidRegex)
                    .WithMessage("Lütfen geçerli bir Emloyee Id giriniz. Employee Id Guid veri yapısında olmalıdır.");


            RuleForEach(t => t.EmployeesId)
                .Matches(ValidationConstants.GuidRegex)
                    .WithMessage("Lütfen geçerli Employee Id giriniz.");
        }
	}
}

