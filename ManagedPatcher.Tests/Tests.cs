using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ManagedPatcher.Tests
{
    public class Tests
    {
	    [Test]
        public async Task PatchDirectoryTest() {
	        string startDirectory = AppDomain.CurrentDomain.BaseDirectory;

			Console.WriteLine("Reading from: " + startDirectory);

			await Program.Main(new[] { "diff", "Before", "After", "Results" });
        }
	}
}