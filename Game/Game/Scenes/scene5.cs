using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using Andonuts;
using Andonuts.Scenes;
using Andonuts.Audio;
using Andonuts.Scenes.Transitions;
using Andonuts.Actors;
using Game.Actors;
using Andonuts.Graphics;
using Andonuts.Collision;
using Raylib_cs;
using Box2DX;
using System.Collections.Generic;


namespace Game.Scenes
{
    internal class scene5 : StandardScene
    {
        public scene5()
        {
            player = new Player(new Vector2(0,0));
            Engine.camera2D.offset = new Vector2((int)Engine.screenSize.X/2, (int)Engine.screenSize.Y/ 2);
            Engine.camera2D.target = player.Position;




            //AudioManager.Instance.SetBGM("A house.ogg", "floydTalk.wav");
            AudioManager.Instance.SetBGM("A house.ogg");
            
            Raylib.PlaySoundMulti(fx);
        }

        public static Player player;


        Sound fx = Raylib.LoadSound(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Resources/Audio/floydTalk.wav");

        //public Raylib_cs.Texture2D ando = Raylib.LoadTexture("C:/Users/My HP/OneDrive/Documents/Andonuts/Engine/Andonuts/Game/Game/Resources/sprite.png");
        public override void Update()
        {
            base.Update();
            player.Update();
            Engine.camera2D.target = player.Position;

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_HOME))
            {
                SceneManager.Instance.Transition = new ColorFadeTransition(0.5f, new Vector3(255, 255, 255));
                SceneManager.Instance.Push(new scene3D());

            }
           
        }


        public Vector2[] verts = {new Vector2(30,0), new Vector2(30, 100), new Vector2(0, 100), new Vector2(5, 0) };

       
        public override void Draw()
        {
            base.Draw();
            
            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawText(Convert.ToString(Engine.camera2D.target), 0, 0, 15, Color.LIGHTGRAY);
            Raylib.BeginMode2D(Engine.camera2D);
            Raylib.DrawText("fuck", 0, 0, 15, Color.LIGHTGRAY);
            player.sprite.Draw();

            //Raylib.DrawRectangle((int)playerPosition.X,(int)playerPosition.Y, 16,24, Raylib_cs.Color.WHITE);
            //player.sprite.Draw();
            //player.collisionBox.Draw();
            Raylib.EndMode2D();
        }
    }
}
