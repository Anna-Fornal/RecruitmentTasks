using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightBDD.XUnit2;
using OrderingTests;

[assembly: ConfiguredLightBddScope]
[assembly: ClassCollectionBehavior(AllowTestParallelization = false)]

namespace OrderingTests
{
    internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {
    }
}
