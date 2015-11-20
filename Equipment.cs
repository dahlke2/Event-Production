// Equipment.cs
// Created on October 25, 2015 by Ethan Dahlke
// Last updated, November 19, 2015

using System;

namespace ProductionOrganization
{
	// Class for the equipment linked list
	public class EquipmentNode{
		private EquipmentNode next;
		public Equipment unit;

		public EquipmentNode Next{
			get{ return next; }
			set{ next = value; }
		}

		public EquipmentNode(){
//			next = new EquipmentNode ();
			unit = new Equipment ();
		}
	}

	// Class to hold the head of the linked list, and foot(?)
	public class EquipmentListHeadandFoot{
		private EquipmentNode myHead;
		private EquipmentNode myFoot;
		private int myTotal;

		public int Total{
			get{ return myTotal; }
			set{ myTotal = value; }
		}

		public EquipmentListHeadandFoot(){
			myHead = new EquipmentNode ();
			myFoot = new EquipmentNode ();
			myFoot.Next = null;
			myFoot.unit = null;
			myHead.unit = null;
			myHead.Next = null;
			myTotal = 0;
		}

		public EquipmentNode Head{
			get {return myHead;}
			set {myHead = value;}
		}

		public EquipmentNode Foot{
			get { return myFoot; }
			set { myFoot = value; }
		}
	}

	// Class to hold information about each unit of equipment
	public class Equipment{

		public Equipment(){

		}

		private string myID;			//Description of unit
		private string myType;			//Type of Equipment
		private string myGroup; 		//System unit belongs to
		private string myWidth;		//Width of unit
		private string myLength;		//Length of unit 
		private string myHeight;		//Height of unit 
		private string myWeight;		//Weight of unit 
		private string myContents;	//Description of what the unit contains
		private string myConsumables;	//List of consumables 
		private string myCompanions;	//List of equipment that is used along with this one
		private string myNotes; 		//Other notes to include anymore information
		private string myShoplocation;

		//Use myWidth, myHeight and myLength to calculate and draw footprint
		public void draw(){

		}

		public string Shoplocation{
			get{ return myShoplocation; }
			set{ myShoplocation = value; }
		}

		public string Group{
			get { return myGroup; }
			set { myGroup = value; }
		}

		public string ID
		{
			get	{return myID;}
			set	{myID = value; }
		}

		public string Type
		{
			get{ return myType; }
			set{ myType = value; }
		}

		public string Weight
		{
			get	{return myWeight;} 
			set	{myWeight = value;}
		}

		public string Width {
			get {return myWidth;}
			set {myWidth = value;}
		}

		public string Length {
			get {return myLength;}
			set {myLength = value;}
		}

		public string Height{
			get {return myHeight;}
			set {myHeight = value;}
		}

		public string Contents
		{
			get{ return myContents; }
			set{ myContents = value; }
		}

		public string Consumables
		{
			get{ return myConsumables; }
			set{ myConsumables = value; }
		}

		public string Companions
		{
			get{ return myCompanions; }
			set{ myCompanions = value; }
		}

		public string Notes
		{
			get{ return myNotes; }
			set{ myNotes = value; }
		}

	}
}

