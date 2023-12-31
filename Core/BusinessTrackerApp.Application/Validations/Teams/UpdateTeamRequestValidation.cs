﻿using System;
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
                .NotNull();
                

            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull();
        }
	}
}

