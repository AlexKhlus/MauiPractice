﻿using Microsoft.Extensions.Logging;
using ProsperDaily.Extensions;
using Syncfusion.Maui.Core.Hosting;


namespace ProsperDaily;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionCore()
			.ConfigureFonts(
				fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("Roboto-Black.ttf", "RobotoBlack");
					fonts.AddFont("LibreFranklin-Regular.ttf", "LibreFranklinRegular");
				});

		builder.Services.AddRepositories();

		#if DEBUG
		builder.Logging.AddDebug();
		#endif

		return builder.Build();
	}
}
