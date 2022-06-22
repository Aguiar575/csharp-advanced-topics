using System;

namespace Dynamic;

class Program
{
    public static void Main()
    {
        object obj = "foo";

        //use reflection
        var hash = obj.GetType().GetMethod("GetHashCode");
        hash.Invoke(null, null);

        //or just do with dynamic
        dynamic dynamicObj = "bar";
        dynamicObj.SomeMethod();
    }
}
