'*******************************************************************
'       ByteScout PDF SDK
'                                                                   
'       Copyright © 2016 Bytescout, http://www.bytescout.com        
'       ALL RIGHTS RESERVED                                         
'                                                                   
'*******************************************************************

Imports Bytescout.PDF

''' <summary>
''' This example demonstrates how to use color profiles.
''' </summary>
Class Program

    Shared Sub Main()

        ' Create new document
        Dim pdfDocument = New Document()
        pdfDocument.RegistrationName = "demo"
		pdfDocument.RegistrationKey = "demo"
        ' Add page
        Dim page = New Page(PaperFormat.A4)
        pdfDocument.Pages.Add(page)

        ' Load ICC color profile
        Dim iccProfile = New ICCBasedColorspace("USWebCoatedSWOP.icc")
        ' Create profiled color brush
        Dim iccColor = New ColorICC(iccProfile, New ColorCMYK(0, 100, 0, 0))
        Dim iccBrush = New SolidBrush(iccColor)
        ' Draw a circle using the brush
        page.Canvas.DrawCircle(iccBrush, 200, 200, 100)

        ' Save document to file
        pdfDocument.Save("result.pdf")

        ' Cleanup 
		pdfDocument.Dispose()

        ' Open document in default PDF viewer app
        Process.Start("result.pdf")

    End Sub

End Class
