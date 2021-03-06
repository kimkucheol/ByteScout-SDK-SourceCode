//*******************************************************************
//       ByteScout PDF SDK		                                     
//                                                                   
//       Copyright © 2016 ByteScout - http://www.bytescout.com       
//       ALL RIGHTS RESERVED                                         
//                                                                   
//*******************************************************************

using System.Diagnostics;
using Bytescout.PDF;

namespace Watermarks
{
	/// <summary>
	/// This example demonstrates how add text watermark to document page.
	/// </summary>
	class Program
	{
		static void Main()
		{
			// Create new document
			Document pdfDocument = new Document();
			pdfDocument.RegistrationName = "demo";
			pdfDocument.RegistrationKey = "demo";
			// Add page
			Page page = new Page(PaperFormat.A4);
			pdfDocument.Pages.Add(page);

			// Add watermark
            TextWatermark watermark1 = new TextWatermark("Center Watermark");
		    watermark1.Font = new Font("Arial", 16);
		    watermark1.Left = 240;
		    watermark1.Top = 450;
            watermark1.Angle = -45;
            page.Watermarks.Add(watermark1);

            // Add another watermark
            TextWatermark watermark2 = new TextWatermark("Bottom Watermark");
            watermark2.Font = new Font("Arial", 16);
            watermark2.Left = 240;
            watermark2.Top = 800;
            page.Watermarks.Add(watermark2);
			
			// Save document to file
			pdfDocument.Save("result.pdf");

			// Cleanup 
			pdfDocument.Dispose();

			// Open document in default PDF viewer app
			Process.Start("result.pdf");
		}
	}
}
