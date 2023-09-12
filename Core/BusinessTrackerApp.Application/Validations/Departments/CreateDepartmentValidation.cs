using System;
using BusinessTrackerApp.Application.ViewModels.Department;
using FluentValidation;

namespace BusinessTrackerApp.Application.Validations.Departments
{
	public class CreateDepartmentValidation : AbstractValidator<CreateDepartmentRequestVM>
	{
		public CreateDepartmentValidation()
		{
			RuleFor(d => d.Name)
				.NotNull()
				.NotEmpty()
					.WithMessage("Lütfen Departman Name alanını boş bırakmayınız! ");

			RuleFor(d => d.ManagerId)
				.Matches(ValidationConstants.GuidRegex)
				.WithMessage("Lütfen geçerli bir ManagerId giriniz. ManagerId alanı Guid veri tipinde olmalıdır.");
		}
	}
}

