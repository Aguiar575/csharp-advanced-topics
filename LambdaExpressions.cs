using System;

namespace LambdaExpressions;
					
public class Program
{
    static void Main()
    {
		//Some lambda expressions options
		Func<int, int> lmbdaSquare = number => number * number;
		Console.WriteLine(lmbdaSquare(5));
		
		//Is equals to
		Func<int, int> lmbdaMathOps = number => SomeMathOps.Square(number);
		Console.WriteLine(lmbdaMathOps(5));
    }	
}

public class SomeMathOps
{
	public static int Square(int number) => 
		number * number;
}
	