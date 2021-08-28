#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using ModdingToolkit.Diffing;
using ModdingToolkit.Magicka.Decompiling;
using ModdingToolkit.Patching;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ManagedPatcher
{
	public static class Program
	{
		public static async Task Main(string[] args) {
			string command = args[0].ToLower();

			Console.WriteLine($"Received command: {command}");

			switch (command) {
				case "decompile":
					Console.WriteLine($"Decompiling: {args[1]} to directory {args[2]}");
					await new Decompiler().DecompileFile(args[1], args[2]);
					Console.WriteLine("Decompilation finished.");
					break;

				case "patch":
					Console.WriteLine($"Applying patches: {args[1]} patched by {args[2]}");
					await new StandardPatcher().Patch(new DirectoryInfo(args[2]), new DirectoryInfo(args[1]));
					Console.WriteLine("Patching finished.");
					break;

				case "diff":
					Console.WriteLine($"Diffing: {args[1]} -> {args[2]}, using {args[3]}");
					await new StandardDiffer().DiffFolders(new DirectoryInfo(args[1]), new DirectoryInfo(args[2]), new DirectoryInfo(args[3]));
					break;
			}

			await Task.CompletedTask;
		}
	}
}