using System;

namespace Zxl.Data
{
	public class ORMException : Exception
	{
		public ORMException()
		{
		}

		public ORMException(string message) : base(message)
		{
		}

		public ORMException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
