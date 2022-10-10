using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using Andonuts;
using Andonuts.Scenes;
using Andonuts.Scenes.Transitions;
using Raylib_cs;

namespace Game.Scenes
{
	internal class scene3 : StandardScene
	{
		public scene3()
		{
			Engine.camera.offset = new Vector2((int)Raylib.GetScreenWidth() / 2 - 8, (int)Raylib.GetScreenHeight() / 2 - 12);
			Engine.camera.target = playerPosition;

		}
		
		public Vector2 playerPosition = new Vector2(0, 0);
		public Vector2 inputVector = new Vector2(0, 0);


		public override void Update()
		{
			base.Update();
			inputVector.X = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT));
			inputVector.Y = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP));

			
			Engine.camera.target.X += (int)Math.Round(inputVector.X * Raylib.GetFrameTime() * 32);
			Engine.camera.target.Y += (int)Math.Round(inputVector.Y * Raylib.GetFrameTime() * 32);
			//Engine.camera.target = playerPosition;
			playerPosition.X += (int)Math.Round(inputVector.X * Raylib.GetFrameTime() * 32);
			playerPosition.Y += (int)Math.Round(inputVector.Y * Raylib.GetFrameTime() * 32);
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_HOME))
			{
				SceneManager.Instance.Transition = new ColorFadeTransition(0.5f, new Vector3(255, 255, 255));
				SceneManager.Instance.Push(new scene5());

			}

		}

		public override void Draw()
		{
			base.Draw();
			Raylib.ClearBackground(Raylib_cs.Color.BLACK);
			Raylib.DrawText(Convert.ToString(Engine.camera.target), 0, 0, 15, Raylib_cs.Color.LIGHTGRAY);
			Raylib.BeginMode2D(Engine.camera);
			Raylib.DrawText("fuck2", 0, 0, 15, Raylib_cs.Color.LIGHTGRAY);
			Raylib.DrawRectangle((int)playerPosition.X,(int)playerPosition.Y, 16,24, Raylib_cs.Color.WHITE);
			Raylib.EndMode2D();
		}
	}
}
