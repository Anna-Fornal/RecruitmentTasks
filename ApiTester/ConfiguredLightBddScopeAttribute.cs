using System;
using System.IO;
using LightBDD.Core.Configuration;
using LightBDD.XUnit2;
using ApiTester;

[assembly: ClassCollectionBehavior(AllowTestParallelization = true)]
[assembly: ConfiguredLightBddScope]

namespace ApiTester
{
    internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {

    }
}