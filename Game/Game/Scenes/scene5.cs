using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using Andonuts;
using Andonuts.Scenes;
using Andonuts.Scenes.Transitions;
using Andonuts.Graphics;
using Raylib_cs;
using System.Collections.Generic;

namespace Game.Scenes
{
    internal class scene5 : StandardScene
    {
        public scene5()
        {
            player = new Player();
            Engine.camera.offset = new Vector2((int)Raylib.GetScreenWidth() / 2 - 8, (int)Raylib.GetScreenHeight() / 2 - 12);
            Engine.camera.target = player.playerPosition;

        }

        public class Player
        {

            public Graphic sprite = new Graphic("animation",new Vector2(0,0));

            public Vector2 playerPosition = new Vector2(0, 0);
            public enum states { idle, walk };
            public states playerState = states.idle;
            public Vector2 inputVector = new Vector2(0, 0);
        }


        public Player player;


        //public Raylib_cs.Texture2D ando = Raylib.LoadTexture("C:/Users/My HP/OneDrive/Documents/Andonuts/Engine/Andonuts/Game/Game/Resources/sprite.png");




        public override void Update()
        {
            base.Update();




            player.sprite.Update();



            player.inputVector.X = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT));
            player.inputVector.Y = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP));


            Engine.camera.target.X += (int)Math.Round(player.inputVector.X * Raylib.GetFrameTime() * 32);
            Engine.camera.target.Y += (int)Math.Round(player.inputVector.Y * Raylib.GetFrameTime() * 32);
            //Engine.camera.target = playerPosition;
            player.playerPosition.X += (int)Math.Round(player.inputVector.X * Raylib.GetFrameTime() * 32);
            player.playerPosition.Y += (int)Math.Round(player.inputVector.Y * Raylib.GetFrameTime() * 32);
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_HOME))
            {
                SceneManager.Instance.Transition = new ColorFadeTransition(0.5f, new Vector3(255, 255, 255));
                SceneManager.Instance.Push(new scene3());

            }

            

            if (player.inputVector == Vector2.Zero)
            {
                player.sprite.changeAnimation("idle");
            }
            else
            {
                player.sprite.changeAnimation("walk");
            }

        }

        public override void Draw()
        {
            base.Draw();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            Raylib.DrawText(Convert.ToString(Engine.camera.target), 0, 0, 15, Raylib_cs.Color.LIGHTGRAY);
            Raylib.BeginMode2D(Engine.camera);
            Raylib.DrawText("fuck", 0, 0, 15, Raylib_cs.Color.LIGHTGRAY);
            //Raylib.DrawRectangle((int)playerPosition.X,(int)playerPosition.Y, 16,24, Raylib_cs.Color.WHITE);
            player.sprite.Draw();
            Raylib.EndMode2D();
        }
    }
}
