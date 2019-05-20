using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.IO;
using Xunit.Abstractions;

namespace StreamLib
{
    public class ShowPath: BaseXunit
    {
        public ShowPath(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
        /// <summary>
        /// Debug路径（控制台和客户端）
        /// </summary>
        [Fact]
        public void Test1()
        {
            //取得或设置当前工作目录的完整限定路径
            _testOutput.WriteLine(Environment.CurrentDirectory);

            //获取基目录，它由程序集冲突解决程序用来探测程序集
            _testOutput.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        }



        /// <summary>
        /// 上级目录
        /// 引用System.IO;
        /// </summary>
        [Fact]
        public void Test2()
        {
            //当前目录的上级目录 bin
            var path1 = new System.IO.DirectoryInfo("..");

            //当前应用程序路径的上级目录 StreamLib
            var path2 = new System.IO.DirectoryInfo("../..");
            _testOutput.WriteLine(path1.FullName);
            _testOutput.WriteLine(path2.FullName);
        }       
    }
}
