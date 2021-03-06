//*******************************************************************
//       ByteScout PDF SDK		                                     
//                                                                   
//       Copyright © 2016 ByteScout - http://www.bytescout.com       
//       ALL RIGHTS RESERVED                                         
//                                                                   
//*******************************************************************

using System;
using System.Diagnostics;
using Bytescout.PDF;

namespace FillFormExample
{
	/// <summary>
	/// This example demonstrates how to fill PDF form programmatically.
	/// </summary>
	class Program
	{
		static void Main()
		{
			// Load PDF form
			Document pdfDocument = new Document(@"form.pdf");
			pdfDocument.RegistrationName = "demo";
			pdfDocument.RegistrationKey = "demo";

		    Page page = pdfDocument.Pages[0];

			// Get widget by its name and change value
		    ((EditBox) page.Annotations["editBox1"]).Text = "Test 123";
		    ((EditBox) page.Annotations["editBox2"]).Text = "Test 456";
		    ((CheckBox) page.Annotations["checkBox1"]).Checked = true;

		    // Save modified document
			pdfDocument.Save("result.pdf");

			// Cleanup 
			pdfDocument.Dispose();

			// Open document in default PDF viewer app
			Process.Start("result.pdf");
		}
	}
}
