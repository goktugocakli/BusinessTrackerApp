using System;
using BusinessTrackerApp.Application.ViewModels.Team;
using FluentValidation;

namespace BusinessTrackerApp.Application.Validations.Teams
{
	public class CreateTeamValidation : AbstractValidator<CreateTeamRequestVM>
	{
		public CreateTeamValidation()
		{
            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull();
            //.WithMessage("Lütfen Name alanını boş bırakmayınız.");

            RuleFor(t => t.DepartmentName)
                .NotEmpty()
                .NotNull();

        }
	}
}

