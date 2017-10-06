using System;
using Impression;

namespace Example01Font
{
    class Program
    {
        static void Main(string[] args)
		{
			using(var game = new Example01FontGame())
            {
                game.Run();
            }
		}
    }
}