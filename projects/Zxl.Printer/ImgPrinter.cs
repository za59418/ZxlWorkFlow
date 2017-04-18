using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace Zxl.Printer
{
	public class ImgPrinter : BaseGHPrinter
	{
		private string sourceFile = null;

		protected override bool doLoadSourceFile(string sourceFile)
		{
			this.sourceFile = sourceFile;
			return true;
		}

		protected override bool doConvertToPdf(string saveAsFile)
		{
			Document document = null;
			Image image = null;
			bool result;
			try
			{
				image = Image.GetInstance(this.sourceFile);
				Rectangle rectangle = new Rectangle(image.Width, image.Height, 0);
				document = new Document(rectangle, 0f, 0f, 0f, 0f);
				PdfWriter.GetInstance(document, new System.IO.FileStream(saveAsFile, System.IO.FileMode.CreateNew));
				document.Open();
				document.Add(image);
				result = true;
			}
			catch (System.Exception var_3_62)
			{
				throw;
			}
			finally
			{
				if (document != null)
				{
					document.Close();
					document = null;
				}
				if (image != null)
				{
					image = null;
				}
			}
			return result;
		}
	}
}
