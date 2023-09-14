using System;
using BusinessTrackerApp.Application.ViewModels.Department;
using FluentValidation;

namespace BusinessTrackerApp.Application.Validations.Departments
{
	public class UpdateDepartmentValidation : AbstractValidator<UpdateDepartmentRequestVM>
	{
		public UpdateDepartmentValidation()
		{
			RuleFor(d => d.Id)
				.NotEmpty()
				.NotNull()
					.WithMessage("Lütfen Id alanını boş bırakmayınız.")
				.Matches(ValidationConstants.GuidRegex)
					.WithMessage("Lütfen Geçerli bir Id giriniz. Department Id Guid yapısında olmalıdır.");

            RuleFor(d => d.Name)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Lütfen Departman Name alanını boş bırakmayınız! ");

        }
	}
}

