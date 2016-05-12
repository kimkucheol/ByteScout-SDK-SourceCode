//*******************************************************************
//       ByteScout PDF Renderer SDK		                                     
//                                                                   
//       Copyright © 2016 ByteScout - http://www.bytescout.com       
//       ALL RIGHTS RESERVED                                         
//                                                                   
//*******************************************************************

using System;
using System.Drawing;
using System.Windows.Forms;

using Bytescout.PDFRenderer;


namespace PrintPDF
{
	public partial class Form1 : Form
	{
		private string _document = @"multipage.pdf";
	    readonly RasterRenderer _rasterRenderer = null;
		private int _page = 0;

		
		public Form1()
		{
			InitializeComponent();

			// Create an instance of Bytescout.PDFRenderer.RasterRenderer object and register it.
			_rasterRenderer = new RasterRenderer();
			_rasterRenderer.RegistrationName = "demo";
			_rasterRenderer.RegistrationKey = "demo";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				// Load PDF document
				_rasterRenderer.LoadDocumentFromFile(_document);
			}
			catch (Exception exception)
			{
				MessageBox.Show("Could not open PDF document.\n\n" + exception.Message);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void buttonPageSetup_Click(object sender, EventArgs e)
		{
			pageSetupDialog1.ShowDialog();
		}

		private void buttonPrintPreview_Click(object sender, EventArgs e)
		{
			_page = 0;
			printPreviewDialog1.Width = 800;
			printPreviewDialog1.Height = 600;
			printPreviewDialog1.ShowDialog();
		}

		private void buttonPrint_Click(object sender, EventArgs e)
		{
			if (printDialog1.ShowDialog() == DialogResult.OK)
			{
				printDocument1.Print();
			}
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Cursor = Cursors.WaitCursor;

		    try
		    {
		        // For the best quality set the rendering resoultion equal to the printer resoultion
		        _rasterRenderer.Resolution = e.PageSettings.PrinterResolution.X;

		        // Render page to image
		        using (Image image = _rasterRenderer.RenderPageToImage(_page))
		        {
		            // Fit image into the print rectangle keeping the aspect ratio

                    Rectangle printRect = e.MarginBounds;

		            float ratio = printRect.Width / (float) image.Width;
		            int width = printRect.Width;
		            int height = (int) (image.Height * ratio);

		            if (height > printRect.Height)
		            {
		                ratio = printRect.Height / (float) image.Height;
		                width = (int) (image.Width * ratio);
		                height = printRect.Height;
		            }

		            // Draw image on device
		            e.Graphics.DrawImage(image, new Rectangle(printRect.X, printRect.Y, width, height),
		                new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
		        }

		        if (_page < _rasterRenderer.GetPageCount() - 1)
		        {
		            _page++;
		            e.HasMorePages = true;
		        }
		    }
		    catch (Exception exception)
		    {
		        MessageBox.Show(exception.Message);
		    }
			finally
			{
				Cursor = Cursors.Default;
			}
		}
	}
}
