using System;

namespace DCIIDS.Data
{
	public class ORMConfigException : ORMException
	{
		public ORMConfigException()
		{
		}

		public ORMConfigException(string message) : base(message)
		{
		}

		public ORMConfigException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
