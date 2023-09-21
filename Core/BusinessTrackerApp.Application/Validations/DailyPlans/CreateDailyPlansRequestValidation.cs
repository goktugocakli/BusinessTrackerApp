using System;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;
using FluentValidation;

namespace BusinessTrackerApp.Application.Validations.DailyPlans
{
	public class CreateDailyPlansRequestValidation : AbstractValidator<CreateDailyPlanRequestVM>
	{
		public CreateDailyPlansRequestValidation()
		{
			RuleFor(p => p.Header)
				.NotEmpty()
				.NotNull()
					.WithMessage("Header alanını boş bırakmayınız.");

			RuleFor(p => p.Description)
				.NotEmpty()
				.NotNull();

			RuleFor(p => p.Date)
				.NotEmpty()
				.NotNull()
				.Custom((date, context) =>
					{
						DateOnly today = DateOnly.FromDateTime(DateTime.Today);
						int todayDayOfWeek = (int) today.DayOfWeek;
						int dayOfWeek = (int) date.DayOfWeek;
						if (dayOfWeek == 0 || dayOfWeek == 6)
							context.AddFailure("Haftasonuna plan girilemez.");

						if (!(today.AddDays(-(todayDayOfWeek - 1)) <= date && date < today.AddDays(6 - todayDayOfWeek)))
							context.AddFailure("Yalnızca bulunduğunuz hafta için plan girebilirsiniz.");
					});
		}
	}
}

