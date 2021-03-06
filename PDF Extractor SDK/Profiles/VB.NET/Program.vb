'*******************************************************************
'       ByteScout PDF Extractor SDK
'                                                                   
'       Copyright © 2016 Bytescout, http://www.bytescout.com        
'       ALL RIGHTS RESERVED                                         
'                                                                   
'*******************************************************************

Imports Bytescout.PDFExtractor

' This example demonstrates the use of profiles. Profiles are set of properties 
' allowing to apply them to Extractor in any combination quickly. You can use 
' predefined profiles or create you own in JSON format like in this example.

Class Program
    Friend Shared Sub Main(args As String())

        ' Create Bytescout.PDFExtractor.TextExtractor instance
        Dim extractor As New TextExtractor()
        extractor.RegistrationName = "demo"
        extractor.RegistrationKey = "demo"
        extractor.OCRLanguageDataFolder = "c:\Program Files\Bytescout PDF Extractor SDK\net2.00\tessdata"

        ' Load sample PDF document
        extractor.LoadDocumentFromFile("sample_ocr.pdf")

        ' Apply predefined profiles
        extractor.Profiles = "scanned, no-layout"
        ' Extract text to file
        extractor.SaveTextToFile("result1.txt")


        extractor.Reset()


        ' Load another document
        extractor.LoadDocumentFromFile("sample_ocr.pdf")

        ' Load and apply custom profiles
        extractor.LoadProfiles("profiles.json")
        extractor.Profiles = "keep-formatting, ocr-forced-200dpi"
        ' Extract text to file
        extractor.SaveTextToFile("result2.txt")


    End Sub
End Class
