﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class AppUser:IdentityUser<int>
	{
		//bizim kullancıların  geleceği sınıfı özelleştirmemizi sağlıyor
		public string Name { get; set; }
		public string Surname { get; set; }

	}
}
