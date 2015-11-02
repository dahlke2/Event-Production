using System;
using ProductionOrganization;

namespace ProductionOrganization
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//	Console.WriteLine ("Hello World!");

			Case case1 = new Case ();
		
			case1.ID = "N/A";
			Console.WriteLine ("Case 1 is {0}.", case1.ID);
			case1.ID = "Cables";
			Console.WriteLine ("Case 1 is {0}.", case1.ID);

			case1.Wheels = false;
			Console.WriteLine ("Case 1 has wheels: {0}",case1.Wheels);
			case1.Wheels = true;
			Console.WriteLine ("Case 1 has wheels: {0}",case1.Wheels);

			case1.IamaCase();
		}
	}
}
