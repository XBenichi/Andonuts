using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using Andonuts;
using Andonuts.Scenes;
using Andonuts.Audio;
using Andonuts.Scenes.Transitions;
using Andonuts.Graphics;
using Andonuts.Collision;
using Raylib_cs;
using System.Collections.Generic;


namespace Game.Scenes
{
    internal class scene5 : StandardScene
    {
        public scene5()
        {
            player = new Player();
            Engine.camera.offset = new Vector2((int)Engine.screenSize.X/2, (int)Engine.screenSize.Y/ 2);
            Engine.camera.target = player.playerPosition;




            //AudioManager.Instance.SetBGM("A house.ogg", "floydTalk.wav");
            AudioManager.Instance.SetBGM("A house.ogg");
            
            Raylib.PlaySoundMulti(fx);
        }

        public class Player
        {

           
            
            public Vector2 playerPosition = new Vector2(0, 0);
            public Vector2 potPosition = new Vector2(0, 0);
            public enum states { idle, walk };
            public states playerState = states.idle;
            public Vector2 inputVector = new Vector2(0, 0);
            public Graphic sprite = new Graphic("animation", new Vector2(0, 0));
            public CBox collisionBox = new CBox(new Vector2(0,0),16,8);
        }


        public static Player player;

       

        Sound fx = Raylib.LoadSound(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Resources/Audio/floydTalk.wav");

        //public Raylib_cs.Texture2D ando = Raylib.LoadTexture("C:/Users/My HP/OneDrive/Documents/Andonuts/Engine/Andonuts/Game/Game/Resources/sprite.png");

        public static CBox collisionBox2 = new CBox(new Vector2(10,50), 36, 28);

        int dx;
        int dy;

        Vector2 vNearestPoint;
        Vector2 vRayToNearest;

        float fOverlap;
        public override void Update()
        {
            base.Update();


            player.inputVector = Vector2.Normalize(player.inputVector);

            player.sprite.Update();
            player.collisionBox.Update();
            collisionBox2.Update();
            


            player.inputVector.X = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT));
            player.inputVector.Y = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP));



            //Engine.camera.target.X += (int)Math.Round(player.inputVector.X * Raylib.GetFrameTime() * 32);
            //Engine.camera.target.Y += (int)Math.Round(player.inputVector.Y * Raylib.GetFrameTime() * 32);




            //vNearestPoint.X = Math.Max(collisionBox2.box.x, Math.Min(player.potPosition.X, collisionBox2.box.x + collisionBox2.box.width));
            //vNearestPoint.Y = Math.Max(collisionBox2.box.y, Math.Min(player.potPosition.Y, collisionBox2.box.y + collisionBox2.box.height));

            //vRayToNearest = new Vector2(dx,dy) - player.potPosition;

            //vRayToNearest = vNearestPoint - player.potPosition;

            /*if (Raylib.CheckCollisionRecs(player.collisionBox.box, collisionBox2.box))
            {
                fOverlap = (player.collisionBox.box.x + player.collisionBox.box.width / 2 + player.collisionBox.box.height / 2) - vRayToNearest.Length();
                player.potPosition = player.potPosition - Vector2.Normalize(vNearestPoint) * fOverlap;
            }*/






            player.potPosition = player.playerPosition;

            player.potPosition.X += (int)Math.Round(player.inputVector.X * Raylib.GetFrameTime() * 32);
            player.potPosition.Y += (int)Math.Round(player.inputVector.Y * Raylib.GetFrameTime() * 32);


            dx = (int)((collisionBox2.box.x + collisionBox2.box.width / 2) - (player.collisionBox.box.x + player.collisionBox.box.width / 2));
            dy = (int)((collisionBox2.box.y + collisionBox2.box.height / 2) - (player.collisionBox.box.y + player.collisionBox.box.height / 2));

            if (Raylib.CheckCollisionRecs(player.collisionBox.box, collisionBox2.box))
                {
                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    if (dx > 1)
                    {
                        player.potPosition.X += -1;
                        player.inputVector.X = -1;
                    }
                    else
                    {
                        player.potPosition.X += 1;
                        player.inputVector.X = 1;
                    }
                }
                else
                {
                    if (dy > 1)
                    {
                        player.potPosition.Y += -1;
                        player.inputVector.Y = -1;
                    }
                    else
                    {
                        player.potPosition.Y += 1;
                        player.inputVector.Y = 1;
                    }
                }


            }

            if (player.potPosition != player.playerPosition)
            {
                player.playerPosition = new Vector2((int)player.potPosition.X, (int)player.potPosition.Y);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_HOME))
            {
                SceneManager.Instance.Transition = new ColorFadeTransition(0.5f, new Vector3(255, 255, 255));
                SceneManager.Instance.Push(new scene3());

            }
            Engine.camera.target = player.playerPosition;

            player.sprite.position = player.playerPosition;
            player.collisionBox.position = new Vector2(player.potPosition.X - 9, player.potPosition.Y + 3);

            if (player.inputVector == Vector2.Zero)
            {
                player.sprite.changeAnimation("idle");
            }
            else
            {
                player.sprite.changeAnimation("walk");
            }

        }


        public Vector2[] verts = {new Vector2(30,0), new Vector2(30, 100), new Vector2(0, 100), new Vector2(5, 0) };

       
        public override void Draw()
        {
            base.Draw();
            
            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawText(Convert.ToString(Engine.camera.target), 0, 0, 15, Color.LIGHTGRAY);
            Raylib.BeginMode2D(Engine.camera);
            Raylib.DrawText("fuck", 0, 0, 15, Color.LIGHTGRAY);

            
            //Raylib.DrawRectangle((int)playerPosition.X,(int)playerPosition.Y, 16,24, Raylib_cs.Color.WHITE);
            player.sprite.Draw();
            collisionBox2.Draw();
            player.collisionBox.Draw();
            Raylib.EndMode2D();
        }
    }
}
