using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Learun.Application.WebApi.Modules
{
    public class GetPdf : BaseApi
    {
        public GetPdf()
         : base("/by/pdf")
        {
            Post["/getpdf"] = GetPdfBySource;
        }

        /// <summary>
        /// 根据用户ID获取订单列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Stream GetPdfBySource(dynamic _)
        {
            FileStream fileStream = new FileStream("C:/Users/Z/Desktop/标院/20200302/333.pdf", FileMode.Open); //打开文件

            // 读取文件Byte[]
            byte[] bt = new byte[fileStream.Length];
            fileStream.Read(bt, 0, bt.Length);
            fileStream.Close();
            var base64Str = Convert.ToBase64String(bt);
            Stream stream = new MemoryStream(bt); //byte[]转换为Stream
            return stream;
        }


    }
}