using System;

namespace model
{
	public class PowerFunction : IFunctions
	{
		private int _base;
		private int _power;

		public PowerFunction() { }

		public PowerFunction(int _base, int _power) { this._base = _base; this._power = _power; }

		public void setBase(int _base) { this._base = _base; }
		public int getBase() { return _base;  }	
		public void setPower(int _power) { this._power = _power; }
		public int getPower() { return _power;  }

		public double getResult() { 
			return Math.Pow(_base, _power);
		}

		public void toString()
        {
			Console.WriteLine("y = " + _base + "`" + _power);
        }
	}
}