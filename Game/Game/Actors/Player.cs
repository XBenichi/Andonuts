using System;
using System.Numerics;
using Andonuts;
using Andonuts.Actors;
using Andonuts.Graphics;
using Raylib_cs;

namespace Game.Actors
{
    internal class Player : SolidActor
    {
		public Player(Vector2 position)
		{
			this.position = position;
			this.speed = 1f;
			
		}
		public override void Update()
		{
			base.Update();
			sprite.Update();
			inputVector.X = Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) - Raylib.IsKeyDown(KeyboardKey.KEY_LEFT);
			inputVector.Y = Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) - Raylib.IsKeyDown(KeyboardKey.KEY_UP);

			velocity = inputVector * speed;
			//position += inputVector;
			sprite.position = position;

			if (!lastPosition.Equals(position))
			{

			}

			if (inputVector == Vector2.Zero)
			{
				sprite.changeAnimation("idle");
			}
			else
			{
				sprite.changeAnimation("walk");
			}

			this.Draw();
		}
		private void Draw()
        {
			Raylib.BeginMode2D(Engine.camera2D);
			//sprite.Draw();
			Raylib.EndMode2D();
		} 

		private States playerState = States.idle;
        private Vector2 inputVector = new Vector2(0, 0);
        public Graphic sprite = new Graphic("animation", new Vector2(0, 0));
    }
}
