using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Andonuts.Collision
{
    public class CBox
    {
        public CBox(Vector2 Bposition,int w,int h)
        {
            position = Bposition;
            box.width = w;
            box.height = h;
        }

        public void Draw()
        {
            if (Engine.Debug)
            {
                Raylib.DrawRectangleLines((int)position.X, (int)position.Y, (int)box.width, (int)box.height, Color.WHITE);
            }
        }

        public void Update()
        {
            box.x = position.X;
            box.y = position.Y;
        }

        public void checkCollision(CBox box1, CBox box2)
        {
            if (Raylib.CheckCollisionRecs(box1.box, box2.box))
            {

            }
             
        }

        public Rectangle box;
        public Vector2 position;
    }
}
