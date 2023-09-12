using System;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;
using FluentValidation;

namespace BusinessTrackerApp.Application.Validations.DailyPlans
{
	public class UpdateDailyPlansRequestValidation : AbstractValidator<UpdateDailyPlanRequestVM>
	{
		public UpdateDailyPlansRequestValidation()
		{
            RuleFor(p => p.Id)
                .Matches(ValidationConstants.GuidRegex);

            RuleFor(p => p.Header)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Date)
                .NotEmpty()
                .NotNull()
                .Custom((date, context) =>
                {
                    DateTime today = DateTime.Today;
                    int todayDayOfWeek = (int)today.DayOfWeek;
                    int dayOfWeek = (int)date.DayOfWeek;
                    if (dayOfWeek == 0 || dayOfWeek == 6)
                        context.AddFailure("Haftasonuna plan girilemez.");

                    if (!(today.AddDays(-(todayDayOfWeek - 1)) <= date && date < today.AddDays(6 - todayDayOfWeek)))
                        context.AddFailure("Yalnızca bulunduğunuz hafta için plan girebilirsiniz.");
                });

            RuleFor(p => p.Status)
                .IsInEnum()
                .WithMessage("Status aralığı 0 ile 4 arasındadır. " +
                "0:NotStarted " +
                "1:InProgress " +
                "2:Completed " +
                "3:PartiallyCompleted "); 
		

        }
	}
}

