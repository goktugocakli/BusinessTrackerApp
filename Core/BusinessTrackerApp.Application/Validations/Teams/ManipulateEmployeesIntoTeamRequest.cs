using System;
using BusinessTrackerApp.Application.ViewModels.Team;
using FluentValidation;

namespace BusinessTrackerApp.Application.Validations.Teams
{
	public class ManipulateEmployeesIntoTeamRequestValidation : AbstractValidator<ManipulateEmployeesIntoTeamRequest>
	{
		public ManipulateEmployeesIntoTeamRequestValidation()
		{

			RuleFor(r => r.TeamId)
				.NotEmpty()
				.NotNull();
                

			RuleForEach(r => r.employeeUsernames)
				.ChildRules(ManipulateStruct =>
				{
					ManipulateStruct
					.RuleFor(x => x.Code)
					.IsInEnum()
					.WithMessage("Code değeri 0 ya da 1 olmalıdır. Eğer code 0 ise kullanıcı takımdan silinir, eğer code 1 ise kullanıcı takıma eklenir.");
				});
			
        }
	}
}

