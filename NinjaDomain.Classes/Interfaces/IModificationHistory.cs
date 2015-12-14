using System;

namespace NinjaDomain.Classes
{
	interface IModificationHistory
	{
		DateTime DateCreated { get; set; }
		DateTime DateModified { get; set; }
	}
}
