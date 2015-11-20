// Audio.cs
// Created on October 25, 2015 by Ethan Dahlke
// Last updated, November 1, 2015

using System;

namespace ProductionOrganization
{
	
	//Class for trunks and cases
	class Case : Equipment
	{
		private bool HasWheels;

		public bool Wheels {
			get {
				return HasWheels;
			}
			set {
				HasWheels = value;
			}
		}
	}

	//Class for units with a rack
	class Rack : Equipment
	{
		private int myRackUnits;

		public int RackUnits{
			get
			{
				return myRackUnits;
			}
			set
			{
				myRackUnits = value;
			}
		}
	}


	//Class for speaker units 
	class Speaker : Equipment
	{
		private string mySpeakerType;
		private string[] myDrivers;
	}
}

