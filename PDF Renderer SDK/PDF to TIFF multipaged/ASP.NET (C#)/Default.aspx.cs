//*******************************************************************
//       ByteScout PDF Renderer SDK		                                     
//                                                                   
//       Copyright © 2016 ByteScout - http://www.bytescout.com       
//       ALL RIGHTS RESERVED                                         
//                                                                   
//*******************************************************************

using System;
using System.Web.UI;
using Bytescout.PDFRenderer;

namespace BasicExample
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// Prepare a test document.
			// Multipage.pdf file will be copied to the project directory on the pre-build event (see the project properties).
			String inputDocument = Server.MapPath("multipage.pdf");

			// Create an instance of Bytescout.PDFRenderer.RasterRenderer object and register it.
			RasterRenderer renderer = new RasterRenderer();
			renderer.RegistrationName = "demo";
			renderer.RegistrationKey = "demo";

			// Load PDF document.
			renderer.LoadDocumentFromFile(inputDocument);

            // Write the response.
            Response.Clear();
            Response.ContentType = "text/html";

            Response.Write("Converting into multipaged TIFF image...<br>");
            Response.Flush();

			// Render document to multi-page TIFF file at 300 DPI resoultion
            renderer.SaveMultipageTiff(Server.MapPath("output.tiff"), 0, -1, 300);

            Response.Write("Done! Check <a href=\"output.tiff\">output.tiff</a> file saved");

			Response.End();
		}
	}
}
