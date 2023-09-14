using System;
using BusinessTrackerApp.Application.ViewModels.Employee;
using FluentValidation;

namespace BusinessTrackerApp.Application.Validations.Employees
{
	public class CreateEmployeeValidation : AbstractValidator<CreateEmployeeRequestVM>
	{
		const string GuidRegex = "^(?:\\{{0,1}(?:[0-9a-fA-F]){8}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){12}\\}{0,1})$";

		const string phoneRegex = "^\\(?([0-9]{3})\\)?([ .-]?)([0-9]{3})\\2([0-9]{4})";


        public CreateEmployeeValidation()
		{
			RuleFor(e => e.NameSurname)
				.NotEmpty()
				.NotNull()
					.WithMessage("Lütfen çalışan adını boş bırakmayınız.");

			RuleFor(e => e.Mail)
				.NotEmpty()
				.NotNull()
					.WithMessage("Lütfen çalışan mail alanını boş bırakmayınız.")
				.EmailAddress()
					.WithMessage("Lütfen geçerli bir mail adresi giriniz.");

			RuleFor(e => e.Phone)
				.NotNull()
				.NotEmpty()
					.WithMessage("Lütfen çalışan telefonu alanını boş bırakmayınız.")
				.Matches(ValidationConstants.PhoneRegex)
					.WithMessage("Geçerli bir telefon numarası giriniz.");
			RuleFor(e => e.DepartmentId)
				.NotEmpty()
				.NotNull()
					.WithMessage("Departman Id alanını boş bırakmayınız.")
				.Matches(ValidationConstants.GuidRegex)
					.WithMessage("Geçerli bir departman id giriniz. Departman Id alanı Guid yapısında olmalıdır.");

			RuleFor(e => e.TeamId)
				.Matches(ValidationConstants.GuidRegex)
					.WithMessage("Geçerli bir TeamId giriniz ya da boş bırakınız. Team Id alanı Guid yapısında olmalıdır.");			

		}
	}
}

