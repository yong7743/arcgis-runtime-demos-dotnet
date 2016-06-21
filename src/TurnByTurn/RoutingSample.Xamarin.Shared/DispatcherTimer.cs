#if __ANDROID__ || __IOS__

using System;
using System.Timers;

namespace RoutingSample
{
	/// <summary>
	/// Timer for Xamarin use that mimics Windows DispatcherTimer in Android / iOS
	/// </summary>
	/// <remarks>
	/// - Raises Tick events on the UI thread
	/// </remarks>
	internal class DispatcherTimer : IDisposable
	{
		private Timer _timer;
		private bool _isInitialized;

		/// <summary>
		/// Sets time interval of Tick event callbacks
		/// </summary>
		public TimeSpan Interval
		{
			get { return (_timer != null) ? TimeSpan.FromMilliseconds(_timer.Interval) : TimeSpan.Zero; }
			set
			{
				if (_timer != null)
					_timer.Interval = value.TotalMilliseconds;
			}
		}

		/// <summary>
		/// Checks / starts / stops the timer
		/// </summary>
		public bool IsEnabled
		{
			get { return (_timer != null && _timer.Enabled); }
			set
			{
				if (_timer != null)
					_timer.Enabled = value;
			}
		}

		/// <summary>
		/// Event fired at each Interval
		/// </summary>
		public event EventHandler Tick;

		public DispatcherTimer()
		{
			_timer = new Timer();
			_timer.AutoReset = true;
			_isInitialized = false;
		}

		public void Start()
		{
			// check for a disposed timer
			if (_timer == null)
				return;

			if (!_isInitialized)
			{
				_timer.Interval = Interval.TotalMilliseconds;
				_timer.Elapsed += timer_Elapsed;
				_isInitialized = true;
			}

			_timer.Start();
		}

		public void Stop()
		{
			if (_timer != null)
				_timer.Stop();
		}

		private void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			var tick = Tick;
			if (tick != null)
			{
				Action action = () => { tick(sender, e); };
				Dispatcher.RunAsyncAction(action);
			}
		}

		public void Dispose()
		{
			if (_timer != null)
			{
				if (_timer.Enabled)
					_timer.Stop();
				if (_isInitialized)
					_timer.Elapsed -= timer_Elapsed;
				_timer.Dispose();
				_timer = null;
			}
		}
	}
}
#endif