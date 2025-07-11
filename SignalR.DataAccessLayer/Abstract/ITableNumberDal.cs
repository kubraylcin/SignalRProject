﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface ITableNumberDal: IGenericDal<TableNumber>
	{
		public int TableNumberCount();
		void ChangeTableNumberStatusToTrue(int İd);
		public void ChangeTableNumberStatusToFalse(int id);
	}
}
