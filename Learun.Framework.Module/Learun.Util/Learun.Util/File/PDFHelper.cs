using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util.File
{
    /// <summary>
    /// 日 期：2017.03.04
    /// 描 述：PDF操作类
    /// </summary>
    public static partial class PDFHelper
    {
        /// <summary>
        /// 加水印
        /// </summary>
        /// <param name="Json">json字串</param>
        /// <returns></returns>
        public static bool PDFWatermark(string filePath, string text)
        {
            PdfReader pdfReader = null;
            PdfStamper pdfStamper = null;
            string tempPath = Path.GetDirectoryName(filePath) + Path.GetFileNameWithoutExtension(filePath) + "_temp.pdf";

            try
            {
                pdfReader = new PdfReader(filePath);
                pdfStamper = new PdfStamper(pdfReader, new FileStream(tempPath, FileMode.Create));
                int total = pdfReader.NumberOfPages + 1;
                iTextSharp.text.Rectangle psize = pdfReader.GetPageSize(1);
                float width = psize.Width;
                float height = psize.Height;
                PdfContentByte content;
                BaseFont font = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\SIMFANG.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                PdfGState gs = new PdfGState();
                for (int i = 1; i < total; i++)
                {
                    content = pdfStamper.GetOverContent(i);//在内容上方加水印
                                                           //content = pdfStamper.GetUnderContent(i);//在内容下方加水印
                                                           //透明度
                    gs.FillOpacity = 0.3f;
                    content.SetGState(gs);
                    //content.SetGrayFill(0.3f);
                    //开始写入文本
                    content.BeginText();
                    content.SetColorFill(BaseColor.RED);
                    content.SetFontAndSize(font, 30);
                    content.SetTextMatrix(0, 0);
                    content.ShowTextAligned(Element.ALIGN_CENTER, text, width - 120, height - 120, -45);
                    //content.SetColorFill(BaseColor.BLACK);
                    //content.SetFontAndSize(font, 8);
                    //content.ShowTextAligned(Element.ALIGN_CENTER, waterMarkName, 0, 0, 0);
                    content.EndText();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pdfStamper != null)
                    pdfStamper.Close();

                if (pdfReader != null)
                    pdfReader.Close();
                System.IO.File.Copy(tempPath, filePath, true);
                System.IO.File.Delete(tempPath);
            }
            return true;
        }


        /// 加平铺图片水印
        /// </summary>
        /// <param name="inputfilepath"></param>
        /// <param name="outputfilepath"></param>
        /// <param name="ModelPicName"></param>
        /// <returns></returns>
        public static bool PDFWatermark(string inputfilepath, string outputfilepath, string ModelPicName)
        {
            //throw new NotImplementedException();
            PdfReader pdfReader = null;
            PdfStamper pdfStamper = null;
            try
            {
                pdfReader = new PdfReader(inputfilepath);

                int numberOfPages = pdfReader.NumberOfPages;
                iTextSharp.text.Rectangle psize = pdfReader.GetPageSize(1);

                float width = psize.Width;
                float height = psize.Height;
                pdfStamper = new PdfStamper(pdfReader, new FileStream(outputfilepath, FileMode.Create));

                PdfContentByte waterMarkContent;
                PdfGState gs = new PdfGState();
                gs.FillOpacity = 0.2f;

                iTextSharp.text.Image imgTemp = iTextSharp.text.Image.GetInstance(ModelPicName);
                float imgWidth = (float)Math.Cos(Math.PI / 6) * imgTemp.Width + 100;
                float imgHeight = (float)Math.Sin(Math.PI / 6) * imgTemp.Width + 100;


                //每一页加水印,也可以设置某一页加水印
                for (int i = 1; i <= numberOfPages; i++)
                {
                    //waterMarkContent = pdfStamper.GetUnderContent(i);//内容下层加水印
                    waterMarkContent = pdfStamper.GetOverContent(i);//内容上层加水印
                    waterMarkContent.SetGState(gs);

                    for (float left = 0; left < width; left += imgWidth)
                    {
                        for (float top = 0; top < height; top += imgHeight)
                        {
                            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(ModelPicName);
                            image.GrayFill = 100;//透明度，灰色填充
                            //image.Rotation = 45;//旋转
                            image.RotationDegrees = 45;//旋转角度
                            image.SetAbsolutePosition(left, height - image.Height - top);
                            //Console.WriteLine(left + ":" + (height - image.Height - top));
                            waterMarkContent.AddImage(image);
                        }
                    }
                }
                //strMsg = "success";
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

                if (pdfStamper != null)
                    pdfStamper.Close();

                if (pdfReader != null)
                    pdfReader.Close();
            }
        }

    }
}
