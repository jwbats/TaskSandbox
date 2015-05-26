using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSandbox
{
	class Program
	{
		static void Main(string[] args)
		{

			Task task = new Task(() => {

				Console.WriteLine("Begin of main task.");

				Task subTask1 = new Task(() => {
					Console.WriteLine("About to piss away 1000 milliseconds.");
					System.Threading.Thread.Sleep(1000);
					Console.WriteLine("Pissed away 1000 milliseconds.");
				}, TaskCreationOptions.AttachedToParent);

				subTask1.Start();

				Task subTask2 = new Task(() => {
					Console.WriteLine("About to piss away 2000 milliseconds.");
					System.Threading.Thread.Sleep(2000);
					Console.WriteLine("Pissed away 2000 milliseconds.");
				}, TaskCreationOptions.AttachedToParent);

				subTask2.Start();

				Console.WriteLine("End of main task.");
			});

			task.Start();

			task.Wait();

			Console.WriteLine("ReadKey()");

			Console.ReadKey();
		}
	}
}
