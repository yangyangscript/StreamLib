using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace StreamLib._4_MemoryStream
{
    public class MemoryStreamTest:BaseXunit
    {
        public MemoryStreamTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        private string ReadPath => $"{new System.IO.DirectoryInfo("../..").FullName}/TestText/TestRead.txt";
        private string ImagePath => $"{new System.IO.DirectoryInfo("../..").FullName}/ImageTest/";
        /*
         *MemoryStream
         *  MemoryStream是内存流,为系统内存提供读写操作，
         *  担当起了一些其他流进行数据交换时的中间工作，同时可降低应用程序中对临时缓冲区和临时文件的需要
         *  注意OutOfMemory的错误
         */

        /// <summary>
        /// StreamReader 中间
        /// </summary>
        [Fact]
        public void Test1()
        {
            using (var f = System.IO.File.OpenRead(ReadPath))
            {                
                System.IO.MemoryStream ms = new MemoryStream();

                f.CopyTo(ms);
                //Copy或者读取之后记得重置位置
                ms.Position = 0;

                using (System.IO.StreamReader sr = new StreamReader(ms))
                {
                    _testOutput.WriteLine(sr.ReadToEnd());
                }
                ms.Close();
                f.Close();
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        [Fact]
        public void Test2()
        {
            var cachCode = new CahceCode();
            Image im = Image.FromStream(cachCode.GetCode());
            im.Save($"{ImagePath}{DateTime.Now.ToLongDateString()}.jpg",ImageFormat.Jpeg);
        }
    }
}
