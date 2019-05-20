using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamLib
{
    public class BaseXunit
    {
        protected Xunit.Abstractions.ITestOutputHelper _testOutput;

        public BaseXunit(Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            _testOutput = testOutputHelper;
        }
    }
}
