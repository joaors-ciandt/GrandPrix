using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.IO;

namespace CustomFramework.Runtime
{
    public class AssemblyLoader
    {
        public static object LoadAssembly(string AssemblyKey, string UserType)
        {
            return Activator.CreateInstance(Assembly.LoadFrom(Path.Combine(Assembly.GetExecutingAssembly().CodeBase, AssemblyKey)).GetType(UserType));
        }
    }
}
