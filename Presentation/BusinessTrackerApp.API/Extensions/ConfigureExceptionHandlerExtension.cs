using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using BusinessTrackerApp.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BusinessTrackerApp.API.Extensions
{
	static public class ConfigureExceptionHandlerExtension
	{
		public static void ConfigureExceptionHandler<T>(this WebApplication application)
		{
			application.UseExceptionHandler(builder =>
			{
				builder.Run(async context =>
				{
					context.Response.ContentType = MediaTypeNames.Application.Json;

					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

					if (contextFeature != null)
					{
						context.Response.StatusCode = contextFeature.Error switch
						{
							ConflictException => (int) HttpStatusCode.Conflict,
							NotFoundException => (int) HttpStatusCode.NotFound,
							_ => (int) HttpStatusCode.InternalServerError
						} ;

						await context.Response.WriteAsync(JsonSerializer.Serialize(new
						{
							StatusCode = context.Response.StatusCode,
							Message = contextFeature.Error.Message,
							Title = "Hata alındı!"
						}));
					}
				});
			});
		}
	}
}

