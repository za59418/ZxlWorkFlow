using System;
using System.Data;

namespace Zxl.Data
{
	public class PaginatedSqlca : Sqlca
	{
		private int m_nRealCount = 0;

		private bool m_isBeginPaginate = false;

		private bool m_isEndPaginage = false;

		public int PageSize
		{
			get;
			set;
		}

		public int PageNo
		{
			get;
			set;
		}

		public int RowsCount
		{
			get;
			set;
		}

		public int StartPosition
		{
			get
			{
				return Math.Max(0, this.PageSize * this.PageNo);
			}
		}

		public PaginatedSqlca(IDbConnection conn) : base(conn)
		{
		}

		public PaginatedSqlca(IDbConnection conn, IDbTransaction trans) : base(conn, trans)
		{
		}

		public PaginatedSqlca(Sqlca sqcal) : base(sqcal)
		{
		}

		public PaginatedSqlca(string strDriver, string strConnectionString) : base(strDriver, strConnectionString)
		{
		}

		public void RemovePageInfo()
		{
			this.m_isBeginPaginate = false;
			this.m_isEndPaginage = false;
			this.m_nRealCount = 0;
			this.RowsCount = 0;
			this.PageSize = -1;
			this.PageNo = 0;
		}

		public void BeginPaginate()
		{
			this.RowsCount = 0;
			this.PageNo = Math.Max(0, this.PageNo);
			if (this.PageSize > 0)
			{
				int num = this.PageNo * this.PageSize;
				for (int i = 0; i < num; i++)
				{
					if (!this.Next())
					{
						break;
					}
				}
			}
			this.m_nRealCount = 0;
			this.m_isBeginPaginate = true;
			this.m_isEndPaginage = false;
		}

		public override int Execute()
		{
			this.m_isBeginPaginate = false;
			this.m_isEndPaginage = false;
			this.RowsCount = 0;
			this.m_nRealCount = 0;
			return base.Execute();
		}

		public override bool Next()
		{
			bool result;
			if (this.PageSize > 0 && this.m_isBeginPaginate && this.m_isEndPaginage)
			{
				result = false;
			}
			else
			{
				bool flag = base.Next();
				if (flag)
				{
					if (this.m_isBeginPaginate)
					{
						if (this.PageSize > 0)
						{
							this.m_nRealCount++;
							if (this.m_nRealCount == this.PageSize)
							{
								this.m_isEndPaginage = true;
							}
						}
					}
					this.RowsCount++;
				}
				result = flag;
			}
			return result;
		}

		public void EndPaginate()
		{
			if (this.PageSize > 0)
			{
				this.m_isEndPaginage = true;
				while (base.Next())
				{
					this.RowsCount++;
				}
			}
		}
	}
}
