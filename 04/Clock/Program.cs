using System.CommandLine;

namespace Clock;

class Program
{
	public static int Main(string[] args)
	{
		var rootCommand = new RootCommand("Clock simulation");

        var tickSpanOption = new Option<int>(
            name: "--span",
            description: "Ticking interval span in seconds",
            getDefaultValue: () => 1
        );
						
        var tickCommand = new Command("tick", "Ticking every time")
			{
                tickSpanOption
            };

		tickCommand.SetHandler((span) =>
			{
				var clock = new Clock();
				clock.Tick += (time) => Console.WriteLine(time);
				clock.StartTick(TimeSpan.FromSeconds(span));

				Console.ReadKey();
			},
			tickSpanOption);

		var alarmSpanOption = new Option<int>(
			name: "--span",
			description: "Alarming after a timespan in seconds",
			getDefaultValue: () => 5
		);

		var alarmCommand = new Command("alarm", "Alarming after some time")
			{
				alarmSpanOption
			};

		alarmCommand.SetHandler((span) =>
			{
				var clock = new Clock();
				clock.Alarm += (time) => Console.WriteLine($"Time is up at {time}");
				Console.WriteLine($"Alarm starts at {DateTime.Now}");
				clock.StartAlarm(TimeSpan.FromSeconds(span));

				Console.ReadKey();
			},
			alarmSpanOption);

		rootCommand.AddCommand(tickCommand);
		rootCommand.AddCommand(alarmCommand);

		return rootCommand.Invoke(args);
	}
}
