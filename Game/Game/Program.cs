using System;
using System.IO;
using Andonuts;
using Andonuts.Scenes;
using Game.Scenes;
using Raylib_cs;

namespace Game
{
	internal class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				Engine.Initialize(args);
				Scene newScene = new TitleScene();
				SceneManager.Instance.Push(newScene);
				//Console.WriteLine(SceneManager.Instance);
				while (Engine.Running)
				{
					Engine.Update();
					
					
				}
			}
			catch (Exception value)
			{
				StreamWriter streamWriter = new StreamWriter("error.log", true);
				streamWriter.WriteLine("At {0}:", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:fff"));
				streamWriter.WriteLine(value);
				streamWriter.WriteLine();
				streamWriter.Close();
			}
		}
	}
}
