using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApplication
{
	class Program
	{
		static void Main( string[] args )
		{
			Database.SetInitializer( new NullDatabaseInitializer<NinjaContext>() );
			InsertNinja();
			InsertMultipleNinjas();
			SimpleNinjaQueries();
			//QueryAndUpdateNinja();
			//DeleteNinja();
			//RetrieveDataWithFind();
			//RetrieveDataWithStoredProc();
			//DeleteNinjaWithKeyValue();
			//DeleteNinjaViaStoredProcedure();
			//QueryAndUpdateNinjaDisconnected();

			//InsertNinjaWithEquipment();
			//SimpleNinjaGraphQuery();
			//ProjectionQuery();
			//QueryAndUpdateNinjaDisconnected();

			//ReseedDatabase();
			Console.ReadKey();
		}

		private static void InsertNinja()
		{
			var ninja = new Ninja {
				Name = "SampsonSan",
				ServedInOniwaban = false,
				DateOfBirth = new DateTime( 2008, 1, 28 ),
				ClanId = 1

			};
			using ( var context = new NinjaContext() )
			{
				context.Database.Log = Console.WriteLine;
				context.Ninjas.Add( ninja );
				context.SaveChanges();
			}
		}

		private static void InsertMultipleNinjas()
		{
			var ninja1 = new Ninja {
				Name = "Leonardo",
				ServedInOniwaban = false,
				DateOfBirth = new DateTime( 1984, 1, 1 ),
				ClanId = 1
			};
			var ninja2 = new Ninja {
				Name = "Raphael",
				ServedInOniwaban = false,
				DateOfBirth = new DateTime( 1985, 1, 1 ),
				ClanId = 1
			};
			using ( var context = new NinjaContext() )
			{
				context.Database.Log = Console.WriteLine;
				context.Ninjas.AddRange( new List<Ninja> { ninja1, ninja2 } );
				context.SaveChanges();
			}
		}

		private static void SimpleNinjaQueries()
		{
			using ( var context = new NinjaContext() )
			{
				context.Database.Log = Console.WriteLine;
				var ninjas = context.Ninjas
					.Where( n => n.DateOfBirth >= new DateTime( 1984, 1, 1 ) )
					.OrderBy( n => n.Name )
					.Skip( 1 ).Take( 1 );

				//var query = context.Ninjas;
				// var someninjas = query.ToList();
				foreach ( var ninja in ninjas )
				{
					Console.WriteLine( ninja.Name );
				}
			}
		}
	}
}
