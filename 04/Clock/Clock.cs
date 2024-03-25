using System.Reactive.Linq;

namespace Clock;

public class Clock
{
	public event Action<DateTime>? Tick;
	
	public event Action<DateTime>? Alarm;

	public void StartTick(TimeSpan span)
	{
		var interval = Observable.Interval(span);

		interval.Subscribe(_ =>
		{
			Tick?.Invoke(DateTime.Now);
		});
	}

	public void StartAlarm(TimeSpan span)
	{
		var timer = Observable.Timer(span);

		timer.Subscribe(_ =>
		{
			Alarm?.Invoke(DateTime.Now);
		});
	}
}
