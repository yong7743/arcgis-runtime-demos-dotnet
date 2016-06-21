using System;

namespace RoutingSample.Converters
{
	public class TimeSpanFormatter : BaseValueConverter
	{
		protected override object Convert(object value, Type targetType, object parameter, string language)
		{
			if(value is TimeSpan)
			{
                try
                {
                    var ts = (TimeSpan)value;
                    if (ts.TotalDays > 1)
                        return string.Format("{0:d} days {0:h} h", ts);
                    if (ts.TotalHours > 1)
                        return string.Format("{0:hh}:{0:mm}", ts);
                    if (ts.TotalSeconds > 0)
                        return string.Format("{0:mm}:{0:ss}", ts);
                    else
                        return ts.ToString();
                }
                catch { }
			}
			return value;
		}

		protected override object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
