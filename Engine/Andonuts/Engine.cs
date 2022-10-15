using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Raylib_cs;
using Andonuts.Scenes;
using System.Numerics;

namespace Andonuts
{
    public class Engine
    {

        public static void Initialize(string[] args, int screenWidth, int screenHeight, string title)
        {
            screenSize = new Vector2(screenWidth, screenHeight);

            Raylib.InitWindow(screenWidth, screenHeight, title);

            Raylib.SetWindowSize(screenWidth * ScreenScale, screenHeight * ScreenScale);

            Raylib.SetWindowPosition((Raylib.GetMonitorWidth(0) / 2) - (screenWidth * ScreenScale) / 2, (Raylib.GetMonitorHeight(0) / 2) - (screenHeight * ScreenScale) / 2);

            Raylib.SetTargetFPS(60);

            Running = true;

            camera.offset = new Vector2((int)Raylib.GetScreenWidth() / 2, (int)Raylib.GetScreenHeight() / 2);

            camera.zoom = 1;

            Console.Clear();

            Console.WriteLine(" ___  _ _  ___  ___  _ _  _ _  ___  ___" +
                "\n| . || \\ || . \\| . || \\ || | ||_ _|/ __>" +
                "\n|   ||   || | || | ||   || | | | | \\__ \\" +
                "\n|_|_||_\\_||___/|___||_\\_||___| |_| <___/ v0.0.2");
            Console.WriteLine("--------------------------------------------------------------------------------");

            target = Raylib.LoadRenderTexture((int)screenSize.X, (int)screenSize.Y);

            targetflipped = Raylib.LoadRenderTexture((int)screenSize.X, (int)screenSize.Y);

        }

        public static void Update()
        {
            while (!Raylib.WindowShouldClose() && Running)
            {

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_F5))
                {
                    if ((int)screenSize.X * ScreenScale < Raylib.GetMonitorWidth(0) && (int)screenSize.Y * ScreenScale < Raylib.GetMonitorHeight(0))
                    {
                        ScreenScale += 1;
                    }
                    else
                    {
                        ScreenScale = 1;
                    }
                    Raylib.SetWindowSize((int)screenSize.X * ScreenScale, (int)screenSize.Y * ScreenScale);
                }

                try
                {
                    Raylib.BeginTextureMode(target);
                    //Draw();
                    SceneManager.Instance.Update();
                    SceneManager.Instance.Draw();
                    Raylib.EndTextureMode();

                    Raylib.BeginTextureMode(targetflipped);
                    Raylib.DrawTexturePro(target.texture, new Raylib_cs.Rectangle(0, 0, target.texture.width, target.texture.height), new Raylib_cs.Rectangle(0, 0, target.texture.width, target.texture.height), new Vector2(0, 0), 0, Raylib_cs.Color.WHITE);
                    Raylib.EndTextureMode();

                    Raylib.BeginDrawing();
                    Raylib.DrawTextureEx(targetflipped.texture, new Vector2(0, 0), 0, ScreenScale, Raylib_cs.Color.WHITE);
                    Raylib.EndDrawing();
                }
                catch (EmptySceneStackException)
                {
                    Quit = true;
                }

                if (Quit)
                {
                    Running = false;
                }



            }
            Raylib.CloseWindow();
        }

        public static void Draw()
        {

        }

        private static bool Quit;

        public static bool Running { get; private set; }

        public static int ScreenScale = 2;

        private static RenderTexture2D target;

        private static RenderTexture2D targetflipped;

        public static Camera2D camera = new Camera2D();

        public static Vector2 screenSize = new Vector2();
    }
}
