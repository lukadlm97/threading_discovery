using System;
using System.Collections.Generic;
using System.Text;

namespace simple_threading_discovery
{
    public class TestingPerformance
    {
		private DateTime _startTime;

		public DateTime StartTime
		{
			get { return _startTime; }
			set { _startTime = value; }
		}

		private DateTime _endTime;

		public DateTime EndTime
		{
			get { return _endTime; }
			set 
			{
				_endTime = value;
				SetTotalTime(value);
			}
		}

		private TimeSpan _totalTime;

		public TimeSpan TotalTime
		{
			get { return _totalTime; }
			set { _totalTime = value; }
		}
		private string _nameOfTesting;

		public string NameOfTesting
		{
			get { return _nameOfTesting; }
			set { _nameOfTesting = value; }
		}

		private void SetTotalTime(DateTime value)
		{
			_totalTime = value - _startTime;
		}

		public override string ToString()
		{
			return new string('-', 45) +
				"\nTesting "+_nameOfTesting+
				"\nStart time: "+_startTime+
				"\nEnd time: "+_endTime+
				". " +
				"\nTotal time: " +_totalTime.TotalMilliseconds+
				"\n"+new string('-', 45);
		}



	}
}
