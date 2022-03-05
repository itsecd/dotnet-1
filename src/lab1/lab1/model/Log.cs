using System;
namespace model
{
	public class Log : IFunctions
	{

		private int log_base;
		private int log_arg;

		private static double LOG_E = 2.7;

		public Log() { }
		public Log(int log_base, int log_args) { this.log_base = log_base; log_arg = log_args; }

		public void setLogBase(int _base) { log_base = _base; }
		public int getLogBase() { return log_base; }
		public void setLogArg(int _arg) { log_arg = _arg; }
		public int getLogArg() { return log_arg; }

		public double getResult() { return Math.Log(log_base, log_arg); }
		

	
		public void toString()
        {
			Console.WriteLine("y = Log" + log_base + "(" + log_arg + ")");
        }

	}
}
