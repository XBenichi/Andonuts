using System;

namespace Andonuts.Scenes
{
	internal class EmptySceneStackException : Exception
	{
		public EmptySceneStackException() : base("The scene stack is empty.")
		{
		}
	}
}
