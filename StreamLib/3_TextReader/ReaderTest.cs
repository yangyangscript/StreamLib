using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace StreamLib._3_TextReader
{
    public class ReaderTest:BaseXunit
    {
        public ReaderTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)  
        {
        }

        private string Path => $"{new System.IO.DirectoryInfo("../..").FullName}/TestText/TestRead.txt";



        /// <summary>
        /// 简单读取方法
        /// </summary>
        [Fact]
        public void Test1()
        {
            var ret = System.IO.File.ReadAllText(Path, Encoding.UTF8);
            _testOutput.WriteLine(ret);
        }


        /*
         * TextReader 为 StreamReader 的父级
         * StreamReader ：实现一个 TextReader，使其以一种特定的编码从字节流中读取字符。
         */


        /// <summary>
        /// StreamReader 路径创建
        /// </summary>
        [Fact]
        public void Test2()
        {
            using (System.IO.StreamReader sr = new StreamReader(Path,Encoding.UTF8))
            {
                var ret=sr.ReadToEnd();
                _testOutput.WriteLine(ret);
                sr.Close();
            }
        }


        /// <summary>
        /// 构造stream创建
        /// </summary>
        [Fact]
        public void Test3()
        {
            using (var f= System.IO.File.OpenRead(Path))
            {
                using (System.IO.StreamReader sr =new StreamReader(f))
                {
                    var ret = sr.ReadToEnd();
                    _testOutput.WriteLine(ret);
                    sr.Close();
                }
            }
        }
    }
}
