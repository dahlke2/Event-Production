// Program.cs
// Created on October 25, 2015 by Ethan Dahlke
// Last updated, November 19, 2015

using System;
using System.Text;
using System.Xml;
using ProductionOrganization;

namespace ProductionOrganization
{
//	struct XMLDocData
//	{
//		string path;
//		XmlDocument XMLDoc;
//	}

	class MainClass
	{
		// Class to hold information about XML file
		public class XMLDocData
		{
			public XMLDocData(){
				path = "/";
				XMLDoc = new XmlDocument();
			}
			public string path;
			public XmlDocument XMLDoc;
		}
			

		public static void Main (string[] args)
		{
			XMLDocData KnoxArray = new XMLDocData();
			EquipmentListHeadandFoot KnoxArrayEquipment = new EquipmentListHeadandFoot ();
			KnoxArray.path = "/Users/ethandahlke/Projects/ProductionOrganization/ProductionOrganization/Equipment.xml";
			LoadXMLdoc (ref KnoxArray);
			XML.LoadXMLdata (ref KnoxArray, ref KnoxArrayEquipment);
			PrintList (ref KnoxArrayEquipment);
			XML.XMLSave (ref KnoxArray.XMLDoc);

//			xmldoc.Load ("../Projects/ProductionOrganization/ProductionOrganization/Equipment.xml");
//			xmldoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
//			Console.WriteLine (xmldoc.DocumentElement.SelectSingleNode("weight").InnerText);
		}
			
		// Import equipement data from XML File
		private static void LoadXMLdoc(ref XMLDocData doc)
		{
			doc.XMLDoc.Load (doc.path);

		}

		// Iterate throigh entire linked list and print list to console
		private static void PrintList(ref EquipmentListHeadandFoot list)
		{
			EquipmentNode cur = list.Head;
			int i = 0;
			while (i < list.Total) {
//			while(cur != list.Foot){
				cur = cur.Next;
				Console.Write (cur.unit.Group+", ");
				Console.Write (cur.unit.ID);
//				Console.Write (cur.unit.Contents);
				Console.WriteLine();
				i++;
			}
		}

	}



	class XML
	{
		//Save XMLDocument to file
		public static void XMLSave(ref XmlDocument doc){
			EquipmentXML template = new EquipmentXML ();
//			template.doc = doc;
			template.doc.Save ("/Users/ethandahlke/Desktop/Save_Test.xml");
		}

		// Equipment XML Template
		public class EquipmentXML
		{
			public XmlDocument doc;

			public EquipmentXML(){
				doc = new XmlDocument();

				XmlNode rootNode = doc.CreateElement("Equipment");
				doc.AppendChild(rootNode);

				XmlNode unitNode = doc.CreateElement("unit");
			
				unitNode.Attributes.Append(doc.CreateAttribute("ID"));
				unitNode.Attributes.Append(doc.CreateAttribute("Type"));
				unitNode.Attributes.Append(doc.CreateAttribute("Group"));
				unitNode.AppendChild(doc.CreateElement("contents"));
				unitNode.AppendChild(doc.CreateElement("length"));
				unitNode.AppendChild(doc.CreateElement("width"));
				unitNode.AppendChild(doc.CreateElement("height"));
				unitNode.AppendChild(doc.CreateElement("weight"));
				unitNode.AppendChild(doc.CreateElement("consumables"));
				unitNode.AppendChild(doc.CreateElement("companions"));
				unitNode.AppendChild(doc.CreateElement("notes"));
				unitNode.AppendChild(doc.CreateElement("shoplocation"));
				rootNode.AppendChild(unitNode);
			}


		}

		// Trasfer Equipment class data to XMLNode
		private static XmlDocument DatatoXML(ref Equipment unit){
			EquipmentXML template = new EquipmentXML ();
			XmlDocument AddMe = template.doc;

			//Set Attributes
			AddMe.DocumentElement.SetAttribute ("ID", unit.ID);
			AddMe.DocumentElement.SetAttribute ("Type", unit.Type);
			AddMe.DocumentElement.SetAttribute ("Group", unit.Group);
			//Set Child Elements
			AddMe.DocumentElement.SelectSingleNode("contents").InnerText = unit.Contents;
			AddMe.DocumentElement.SelectSingleNode ("length").InnerText = unit.Length;
			AddMe.DocumentElement.SelectSingleNode ("width").InnerText = unit.Width;
			AddMe.DocumentElement.SelectSingleNode ("height").InnerText = unit.Height;
			AddMe.DocumentElement.SelectSingleNode ("weight").InnerText = unit.Weight;
			AddMe.DocumentElement.SelectSingleNode ("consumables").InnerText = unit.Consumables;
			AddMe.DocumentElement.SelectSingleNode ("companions").InnerText = unit.Companions;
			AddMe.DocumentElement.SelectSingleNode ("notes").InnerText = unit.Notes;
			AddMe.DocumentElement.SelectSingleNode ("shoplocation").InnerText = unit.Shoplocation;

			return AddMe;
		}

		// Add a node to the end of the linked list
		public void XMLAppend(ref EquipmentListHeadandFoot list, EquipmentNode AddMe)
		{
			EquipmentNode last = NodeIterate (ref list, list.Total);
			last.Next = new EquipmentNode ();
			last.Next = AddMe;

		}

		// Add a node to the linked list at the specified index
		public void XMLAdd(ref EquipmentListHeadandFoot list, ref EquipmentNode AddMe, int index){
			EquipmentNode previous = NodeIterate (ref list, (index - 1));
			AddMe.Next = previous.Next;
			previous.Next = AddMe;
		}

		// Iterate through linked list to index and return the node
		private static EquipmentNode NodeIterate(ref EquipmentListHeadandFoot list, int index){
			EquipmentNode cur = list.Head.Next;
			int i; 
			for (i=0; i<index; i++) {
				cur = cur.Next;
			}
			return cur;
		}
			
		// Export Equipment Data to XML File
		public static void StoreNewXMLData(ref MainClass.XMLDocData doc, Equipment AddMe)
		{
			XmlDocument xml = new XmlDocument ();
			xml = DatatoXML (ref AddMe);
			doc.XMLDoc.DocumentElement.AppendChild (xml.SelectSingleNode ("unit"));
			XMLSave (ref doc.XMLDoc);
		}

		public static void LoadXMLdata(ref MainClass.XMLDocData doc, ref EquipmentListHeadandFoot list)
		{
			EquipmentNode cur = list.Head;	//Assign Linked List Head
			EquipmentNode Next;				//Object to hold new EquipmentNode object
			foreach (XmlNode node in doc.XMLDoc.DocumentElement.SelectNodes("unit")) {

				//				Console.WriteLine (node.Name);

				Next = new EquipmentNode ();		//Create new Node object

				//Iterate through XML file and import data to Linked List
				if ((node) != null) {
					cur.Next = Next;
					cur = cur.Next;

					cur.unit.ID = node.Attributes ["ID"].Value;
					cur.unit.Type = node.Attributes ["Type"].Value;
					cur.unit.Group = node.Attributes ["Group"].Value;
					cur.unit.Contents = node.SelectSingleNode ("contents").InnerText;
					cur.unit.Length = node.SelectSingleNode ("length").InnerText;
					cur.unit.Width = node.SelectSingleNode ("width").InnerText;
					cur.unit.Height = node.SelectSingleNode ("height").InnerText;
					cur.unit.Weight = node.SelectSingleNode ("weight").InnerText;
					cur.unit.Consumables = node.SelectSingleNode ("consumables").InnerText;
					cur.unit.Companions = node.SelectSingleNode ("companions").InnerText;
					cur.unit.Notes = node.SelectSingleNode ("notes").InnerText;
					cur.unit.Shoplocation = node.SelectSingleNode ("shoplocation").InnerText;

					list.Total++;
				}

			}

		}
	}
}
