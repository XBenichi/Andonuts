using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using fNbt;
using System.Numerics;
using System.IO;
using System.Reflection;
using System.Collections;

namespace Andonuts.Graphics
{
	public class Graphic
	{
		public Graphic(string resource, Vector2 Sposition)
		{

			animationFile.LoadFromFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Resources/" + resource + ".dat");



			position = Sposition;

			sprite = Raylib.LoadTexture(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Resources/" + animationFile.RootTag.Get<NbtString>("spritesheet").Value);

            frameRec.x = (int)animationFile.RootTag.Get<NbtCompound>("frames").Get<NbtCompound>(currentSpriteFrame.ToString()).Get<NbtInt>("x").Value;
			frameRec.y = (int)animationFile.RootTag.Get<NbtCompound>("frames").Get<NbtCompound>(currentSpriteFrame.ToString()).Get<NbtInt>("y").Value;
			frameRec.width = (int)animationFile.RootTag.Get<NbtCompound>("frames").Get<NbtCompound>(currentSpriteFrame.ToString()).Get<NbtInt>("w").Value;
			frameRec.height = (int)animationFile.RootTag.Get<NbtCompound>("frames").Get<NbtCompound>(currentSpriteFrame.ToString()).Get<NbtInt>("h").Value;

			changeAnimation("idle");

			visible = true;

			

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
			if (anim != CurrentAnimation)
			{
				CurrentAnimation = anim;

				currentFrame = 0;

				UpdateAnimation();
			}
			
		}


		public void Update()
		{
			if (visible)
			{
				framesCounter++;
				if (framesCounter > animationFile.RootTag.Get<NbtCompound>("animations").Get<NbtCompound>(CurrentAnimation).Get<NbtCompound>("sequence").Get<NbtCompound>(currentFrame.ToString()).Get<NbtInt>("time").Value)
				{
					UpdateAnimation();
				}
			}
		}

		private void UpdateAnimation()
        {
			framesCounter = 0;

			if (animationFile.RootTag.Get<NbtCompound>("animations").Get<NbtCompound>(CurrentAnimation).Get<NbtCompound>("sequence").Get<NbtCompound>((currentFrame + 1).ToString()) == null)
			{
				if (animationFile.RootTag.Get<NbtCompound>("animations").Get<NbtCompound>(CurrentAnimation).Get<NbtByte>("loop").Value == 1)
				{
					currentFrame = 0;
				}
			}
			else
			{
				currentFrame++;
			}


			currentSpriteFrame = animationFile.RootTag.Get<NbtCompound>("animations").Get<NbtCompound>(CurrentAnimation).Get<NbtCompound>("sequence").Get<NbtCompound>(currentFrame.ToString()).Get<NbtInt>("frame").Value;
			frameRec.x = (int)animationFile.RootTag.Get<NbtCompound>("frames").Get<NbtCompound>(currentSpriteFrame.ToString()).Get<NbtInt>("x").Value;
			frameRec.y = (int)animationFile.RootTag.Get<NbtCompound>("frames").Get<NbtCompound>(currentSpriteFrame.ToString()).Get<NbtInt>("y").Value;
			frameRec.width = (int)animationFile.RootTag.Get<NbtCompound>("frames").Get<NbtCompound>(currentSpriteFrame.ToString()).Get<NbtInt>("w").Value;
			frameRec.height = (int)animationFile.RootTag.Get<NbtCompound>("frames").Get<NbtCompound>(currentSpriteFrame.ToString()).Get<NbtInt>("h").Value;
		}



		private Vector2 position;

		private Texture2D sprite;

		private NbtFile animationFile = new NbtFile();
		
		private string CurrentAnimation;

		private bool visible = false;

		private int currentFrame = 0;

		private int currentSpriteFrame = 0;

		private int framesCounter = 0;

		private Rectangle frameRec = new Rectangle(0, 0, 0, 0);

	}
}
