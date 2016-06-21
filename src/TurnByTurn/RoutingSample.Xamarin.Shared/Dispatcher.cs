#if __IOS__ || __ANDROID__

using System;
using System.Threading.Tasks;

#if __ANDROID__
using Android.OS;
#elif __IOS__
using Foundation;
using CoreFoundation;
#endif

namespace RoutingSample
{
	/// <summary>
	/// Provides methods for invoking functionality on the Main (UI) thread
	/// </summary>
	internal static class Dispatcher
	{
#if __ANDROID__
        static Handler s_handler = new Handler(Looper.MainLooper);
#endif

        /// <summary>
        /// Executes the specified action on the UI thread asynchronously
        /// </summary>
        /// <remarks>
        /// - Uses Xamarin.Forms Device class to invoke action on the UI thread
        /// - void return - fire and forget
        /// </remarks>
        internal static void RunAsyncAction(Action a, bool highPriority = true)
		{
#if __IOS__
			DispatchQueue.MainQueue.DispatchAsync(a);
#elif __ANDROID__
			s_handler.Post(a);
#endif
		}

		/// <summary>
		/// Executes the specified action on the UI thread asynchronously
		/// </summary>
		/// <remarks>
		/// - Uses Xamarin.Forms Device class to invoke action on the UI thread
		/// - Returns a task that can be awaited if necessary
		/// </remarks>
		internal static Task InvokeAsync(Action a)
		{
			var tcs = new TaskCompletionSource<bool>();
			Action action = () =>
			{
				try
				{
					a();
					tcs.TrySetResult(true);
				}
				catch (Exception ex)
				{
					tcs.TrySetException(ex);
				}
			};
			RunAsyncAction(action);
			return tcs.Task;
		}
	}
}
#endif