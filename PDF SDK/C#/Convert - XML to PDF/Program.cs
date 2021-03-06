//*******************************************************************
//       ByteScout PDF SDK		                                     
//                                                                   
//       Copyright © 2016 ByteScout - http://www.bytescout.com       
//       ALL RIGHTS RESERVED                                         
//                                                                   
//*******************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Bytescout.PDF;

namespace ConvertXmlToPdfExample
{
	/// <summary>
	/// This example demonstrates how to create table from some XML data.
	/// Since your XML file has different structure the example just shows technique of XML data reading 
	//  and PDF table creation.
	/// </summary>
	class Program
	{
		static void Main()
		{
			// Load XML document
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(@"sample.xml");

			// Read columns information from XML data
			List<string> columns = new List<string>();
			XmlNodeList columnNodeList = xmlDocument.SelectNodes("/Report/Columns/Column");
			foreach (XmlNode node in columnNodeList)
				columns.Add(node.Attributes["Name"].Value);

			// Read row nodes from XML data
			XmlNodeList rowNodeList = xmlDocument.SelectNodes("/Report/ReportData");
			

			// Create new PDF document
			Document pdfDocument = new Document();
			pdfDocument.RegistrationName = "demo";
			pdfDocument.RegistrationKey = "demo";
			// Add page
			Page page = new Page(PaperFormat.A4);
			pdfDocument.Pages.Add(page);
			
			DeviceColor lightGrayColor = new ColorGray(200);
			DeviceColor whiteColor = new ColorGray(255);


			// Create PDF table
			Table table = new Table();
			table.BackgroundColor = lightGrayColor;

			// Add columns
			for (int c = 0; c < columns.Count; c++)
			{
				TableColumn column = new TableColumn(columns[c], columns[c]);
				// Set column width
				column.Width = (c == 0)? 100 : 60;
				table.Columns.Add(column);
			}

			// Add rows
			foreach (XmlNode rowNode in rowNodeList)
			{
				// Create new row and set its background color
				TableRow row = table.NewRow();
				row.BackgroundColor = whiteColor;
				
				// Get cell values from XML data
				foreach (XmlNode childNode in rowNode.ChildNodes)
				{
					// Get cell info from XML data
					string columnName = childNode.Name;
					int columnIndex = columns.IndexOf(childNode.Name);
					string cellValue = childNode.InnerText;

					// Set cell text
					row[columnName].Text = cellValue;
					// Set cell text alignment
					row[columnName].TextFormat.HorizontalAlign = (columnIndex == 0) ? HorizontalAlign.Left : HorizontalAlign.Right;
				}

				// Add the row to the table
				table.Rows.Add(row);
			}

			// Draw the table on canvas
			page.Canvas.DrawTable(table, 20, 20);


			// Save document to file
			pdfDocument.Save("result.pdf");

			// Cleanup 
			pdfDocument.Dispose();

			// Open document in default PDF viewer application
			Process.Start("result.pdf");
		}
	}
}
