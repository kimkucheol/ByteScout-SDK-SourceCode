//*******************************************************************
//       ByteScout BarCode Reader SDK		                                     
//                                                                   
//       Copyright © 2016 ByteScout - http://www.bytescout.com       
//       ALL RIGHTS RESERVED                                         
//                                                                   
//*******************************************************************

using System;
using System.IO;

using Bytescout.BarCodeReader;

namespace ReadGS1_128
{
    class Program
    {
        const string ImageFile = "GS1_128.png";

        static void Main()
        {
            Console.WriteLine("Reading barcode(s) from image {0}", Path.GetFullPath(ImageFile));

            Reader reader = new Reader();
            reader.RegistrationName = "demo";
			reader.RegistrationKey = "demo";

            // Set barcode type to find
            reader.BarcodeTypesToFind.GS1 = true; // "GS1-128" barcode type is subset of "Code 128"

            // Read barcodes
            FoundBarcode[] barcodes = reader.ReadFrom(ImageFile);

            foreach (FoundBarcode barcode in barcodes)
            {
                Console.WriteLine("Found barcode with type '{0}' and value '{1}'", barcode.Type, barcode.Value);
            }

            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }
    }
}
