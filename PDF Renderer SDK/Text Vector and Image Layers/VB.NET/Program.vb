'*******************************************************************
'       ByteScout PDF Renderer SDK
'                                                                   
'       Copyright © 2016 Bytescout, http://www.bytescout.com        
'       ALL RIGHTS RESERVED                                         
'                                                                   
'*******************************************************************


Imports Bytescout.PDFRenderer


Class Program
	Friend Shared Sub Main(args As String())

        ' Create an instance of Bytescout.PDFRenderer.RasterRenderer object and register it.
		Dim renderer As New RasterRenderer()
		renderer.RegistrationName = "demo"
		renderer.RegistrationKey = "demo"

        Dim renderingOptions As New RenderingOptions()

        ' Enable text objects rendering
        renderingOptions.RenderTextObjects = True
        ' DISABLE vector objects rendering
        renderingOptions.RenderVectorObjects = False
        ' DISABLE image objects rendering
        renderingOptions.RenderImageObjects = False
        
		' Load PDF document.
		renderer.LoadDocumentFromFile("multipage.pdf")

		For i As Integer = 0 To renderer.GetPageCount() - 1
            ' Render document page to PNG image file
            renderer.Save("image" & i & ".png", RasterImageFormat.PNG, i, 300, renderingOptions)
		Next

		' Open the first output file in default image viewer.
		System.Diagnostics.Process.Start("image0.png")
	End Sub
End Class
