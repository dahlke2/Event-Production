// Equipment.cs
// Created on October 25, 2015 by Ethan Dahlke
// Last updated, November 1, 2015

using System;

namespace ProductionOrganization
{

	public class Equipment{
		private string myID;			//Description of unit
		private decimal myWidth;		//Width of unit
		private decimal myLength;		//Length of unit 
		private decimal myHeight;		//Height of unit 
		private decimal myWeight;		//Weight of unit 
		private string[] myContents;	//Description of what the unit contains


		//Use myWidth, myHeight and myLength to calculate and draw footprint
		public void draw(){

		}

		public string ID
		{
			get
			{
				return myID;
			}

			set
			{
				myID = value; 
			}
		}

		public decimal Weight
		{
			get
			{
				return myWeight;
			} 

			set
			{
				myWeight = value; 
			}
		}

		public decimal Width {
			get {
				return myWidth;
			}
			set {
				myWidth = value;
			}
		}

		public decimal Length {
			get {
				return myLength;
			}
			set {
				myLength = value;
			}
		}

		public decimal Height{
			get {
				return myHeight;
			}
			set {
				myHeight = value;
			}
		}

	}
}

