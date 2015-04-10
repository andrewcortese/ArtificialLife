
using System;

/// <summary>
/// This class is used for having events occur at specific time intervals.
/// A timer is started at 0 upon construction.
/// The client class should call tick() and pass in the amount of time that has passed since the last tick().
/// tick() then returns true if an interval has been completed (and automatically resets the timer) or false otherwise.
/// 
/// If a client class is a MonoBehavior, it is recommended to call tick() from that class' update() method, and pass
/// Time.deltaTime as an argument.
/// 
/// All times are in seconds and are float values.
/// </summary>
public class Timer : ITimer
{

	//the amount of time after which something should happen.
	float interval = 0f;

	//the amount of time that has passed so far in this interval. 
	float time = 0f;

	/// <summary>
	/// Initializes a new instance of the <see cref="AssemblyCSharp.Timer"/> class.
	/// </summary>
	/// <param name="interval">Interval.</param>
	public Timer (float interval)
	{
		this.interval = interval;
		this.time = 0f;
	}

	/// <summary>
	/// Increment the timer by deltaTime.
	/// If the interval is complete, return true and reset. return false otherwise.
	/// </summary>
	/// <param name="deltaTime">Delta time.</param>
	public bool tick (float deltaTime)
	{
		this.time += deltaTime;
		if (this.time >= this.interval) {
			//don't snip the time if we've gone over since last update
			float extraTimePassed = this.time - this.interval;
			this.time = extraTimePassed;
			return true;
		} else {
			return false;
		}
	}

	public float CurrentTime {
		get {
			return this.time;
		}
	}

	public float Interval {
		get {
			return this.interval;
		}
	}

	///
	//100*(time/interval) is the %complete
	public float percentComplete ()
	{
		float percent = 100 * (this.time / this.interval);
		return percent;
	}

	public override string ToString ()
	{
		double roundedTime = Math.Round(CurrentTime, 0);
		double roundedInterval = Math.Round(Interval, 0);
		double roundedPercent = Math.Round(percentComplete(), 0);
		return string.Format ("{0} / {1}  ({2}%)", roundedTime, roundedInterval, roundedPercent);
	}

}


