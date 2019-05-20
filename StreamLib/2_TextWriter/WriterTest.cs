using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace StreamLib._2_TextWriter
{
    public class WriterTest: BaseXunit
    {
        public WriterTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        private string Path => $"{new System.IO.DirectoryInfo("../..").FullName}/TestText/TestWrite.txt";

        /// <summary>
        /// 简单暴力型覆盖创建
        /// </summary>
        [Fact]
        public void Test1()
        {
            System.IO.File.WriteAllText(Path,"覆盖创建的头！\r\n",Encoding.UTF8);
        }


        /*
         * TextWriter 为 StreamWriter 的父级
         * StreamWriter的概念：实现一个 TextWriter，使其以一种特定的编码向流中写入字符。
         */


        /// <summary>
        /// StreamWriter 路径创建
        /// </summary>
        [Fact]
        public void Test2()
        {
            using (System.IO.StreamWriter sw = new StreamWriter(Path,true,Encoding.UTF8))
            {
                sw.WriteLine("路径创建新的第一行！");
                sw.WriteLine("路径创建新的第二行！");
                sw.Flush();
                sw.Close();
            }
        }


        /// <summary>
        /// 构造stream创建
        /// </summary>
        [Fact]
        public void Test3()
        {
            using (System.IO.FileStream f = System.IO.File.OpenWrite(Path))
            {
                //stream默认位置为0;
                f.Position = f.Length;
                using (System.IO.StreamWriter sw= new StreamWriter(f))
                {                   
                    sw.WriteLine("构造stream新的第一行！");
                    sw.WriteLine("构造stream新的第二行！");
                    sw.Flush();
                    sw.Close();
                }
                f.Close();
            }
        }
    }
}
