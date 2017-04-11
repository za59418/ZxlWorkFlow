using System;

namespace DCIIDS.Data
{
	public enum SQLStatementTypes
	{
		Others,
		Insert,
		Select,
		Delete,
		Update,
		Drop,
		Create,
		Transaction,
		StoredProcedure
	}
}
