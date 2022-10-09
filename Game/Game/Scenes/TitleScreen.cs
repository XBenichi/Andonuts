using System;
using System.IO;
using System.Reflection;
using System.Numerics;
using Andonuts;
using Andonuts.Scenes;
using Andonuts.Scenes.Transitions;
using Raylib_cs;


namespace Game.Scenes
{
	internal class TitleScene : StandardScene
	{
		public TitleScene()
		{
		
		}


		public override void Update()
		{
			base.Update();
		}
		public override void Draw()
		{
			base.Draw();
			Raylib.ClearBackground(Raylib_cs.Color.BLACK);
			Raylib.DrawText("Title Screen", 160, 90, 15, Raylib_cs.Color.LIGHTGRAY);
			Raylib.DrawFPS(0, 0);
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_END))
			{
				SceneManager.Instance.Transition = new ColorFadeTransition(0.5f, new Vector3(0,0,0));
				SceneManager.Instance.Push(new scene5());

			}
		}

	}
}
