'*******************************************************************
'       ByteScout PDF SDK
'                                                                   
'       Copyright © 2016 Bytescout, http://www.bytescout.com        
'       ALL RIGHTS RESERVED                                         
'                                                                   
'*******************************************************************

Imports Bytescout.PDF

''' <summary>
''' This example demonstrates how add text watermark to document page.
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

        ' Add watermark
        Dim watermark1 = New TextWatermark("Center Watermark")
        watermark1.Font = New Font("Arial", 16)
        watermark1.Left = 240
        watermark1.Top = 450
        watermark1.Angle = -45
        page.Watermarks.Add(watermark1)

        ' Add another watermark
        Dim watermark2 = New TextWatermark("Bottom Watermark")
        watermark2.Font = New Font("Arial", 16)
        watermark2.Left = 240
        watermark2.Top = 800
        page.Watermarks.Add(watermark2)

        ' Save document to file
        pdfDocument.Save("result.pdf")

        ' Cleanup 
		pdfDocument.Dispose()

        ' Open document in default PDF viewer app
        Process.Start("result.pdf")

    End Sub

End Class
