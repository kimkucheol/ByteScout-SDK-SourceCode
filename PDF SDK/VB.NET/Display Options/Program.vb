'*******************************************************************
'       ByteScout PDF SDK
'                                                                   
'       Copyright © 2016 Bytescout, http://www.bytescout.com        
'       ALL RIGHTS RESERVED                                         
'                                                                   
'*******************************************************************

Imports Bytescout.PDF

''' <summary>
''' This example demonstrates how to set display options for a viewer application.
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

        ' Set page mode (which panels should be shown at viewing application start)
        pdfDocument.PageMode = PageMode.Thumbnail ' show thumbnails panel

        ' Show/hide various interface elements
        pdfDocument.ViewerPreferences.CenterWindow = True
        pdfDocument.ViewerPreferences.FitWindow = True
        pdfDocument.ViewerPreferences.HideMenubar = True
        pdfDocument.ViewerPreferences.HideToolbar = True
        pdfDocument.ViewerPreferences.HideWindowUI = False

        ' Save document to file
        pdfDocument.Save("result.pdf")

        ' Cleanup 
		pdfDocument.Dispose()

        ' Open document in default PDF viewer app
        Process.Start("result.pdf")

    End Sub

End Class
