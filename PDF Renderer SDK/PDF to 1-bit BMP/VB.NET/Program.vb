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

		' Load PDF document.
        renderer.LoadDocumentFromFile("multipage.pdf")

        Dim renderingOptions As New RenderingOptions()
        ' Set pixel format to 1-bit
        renderingOptions.ImageBitsPerPixel = ImageBitsPerPixel.BPP1

		For i As Integer = 0 To renderer.GetPageCount() - 1
            ' Save 1-bit image to file
            renderer.Save("image" & i & ".bmp", RasterImageFormat.BMP, i, 200, renderingOptions)
		Next

		' Open the first output file in default image viewer.
        System.Diagnostics.Process.Start("image0.bmp")

	End Sub
End Class
