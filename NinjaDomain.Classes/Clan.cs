using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDomain.Classes
{
	public class Clan
	{
		public int Id { get; set; }
		public string ClanName { get; set; }
		public List<Ninja> Ninjas { get; set; }
	}
}
