using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using Newtonsoft.Json;
using System.Numerics;
using System.IO;
using System.Reflection;

namespace Andonuts.Graphics
{
	public class Graphic
	{
		public Graphic(string resource, Vector2 position)
		{
			using (StreamReader r = new StreamReader(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Resources/" + resource))
			{
				string json = r.ReadToEnd();

				animationFile = JsonConvert.DeserializeObject(json);



				position = position;

				sprite = Raylib.LoadTexture(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Resources/" + animationFile.spritesheet);

				frameRec.x = (int)animationFile.frames[0].x;
				frameRec.y = (int)animationFile.frames[0].y;
				frameRec.width = (int)animationFile.frames[0].w;
				frameRec.height = (int)animationFile.frames[0].h;

				visible = true;

				changeAnimation("walk");


			}
		}

		protected Graphic()
		{
		}

		public void Draw()
		{
			if (visible)
			{
				Raylib.DrawTextureRec(sprite, frameRec, position, Raylib_cs.Color.WHITE);
			}
		}



		public void changeAnimation(string anim)
		{
			object animArray = animationFile.animations;
			CurrentAnimation = animArray.GetType();
			foreach (object prop in animArray.GetType().GetProperties())
            {
				Console.WriteLine(prop);
			}
			
		}


		public void Update()
		{
			/*if (visible)
			{
				framesCounter++;
				if (framesCounter >= (60 / (int)animation.FindIndex()))
				{
					framesCounter = 0;
					currentFrame++;

					if (currentFrame > animation.animations.walk.sequence.Length())
					{
						currentFrame = 0;
					}

					frameRec.x = (int)animation.frames[(int)animation.animations.walk.sequence[currentFrame].frame].x;
					frameRec.y = (int)animation.frames[(int)animation.animations.walk.sequence[currentFrame].frame].y;
					frameRec.width = (int)animation.frames[(int)animation.animations.walk.sequence[currentFrame].frame].w;
					frameRec.height = (int)animation.frames[(int)animation.animations.walk.sequence[currentFrame].frame].h;
				}
			}*/
		}

		


	private Vector2 position;

		private Texture2D sprite;

		private dynamic animationFile;
		
		private object CurrentAnimation;

		private bool visible = false;

		private int currentFrame = 0;

		private int framesCounter = 0;

		private Rectangle frameRec = new Rectangle(0, 0, 0, 0);

	}
}
