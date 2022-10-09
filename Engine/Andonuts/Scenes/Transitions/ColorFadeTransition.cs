using System;
using System.Numerics;
using Raylib_cs;

namespace Andonuts.Scenes.Transitions
{
	public class ColorFadeTransition : ITransition
	{
		public bool IsComplete
		{
			get
			{
				return this.isComplete;
			}
		}

		public float Progress
		{
			get
			{
				return this.progress;
			}
		}

		public bool ShowNewScene
		{
			get
			{
				return this.progress > 0.5f;
			}
		}

		public bool Blocking { get; set; }

		public ColorFadeTransition(float duration, Vector3 color)
		{
			fadeColor.X = color.X;
			fadeColor.Y = color.Y;
			fadeColor.Z = color.Z;
			float num = 60f * duration;
			this.speed = 1f / num;
			this.isComplete = false;
			this.progress = 0f;
			
		}

		public void Update()
		{
			this.progress += this.speed;
			this.isComplete = (this.progress > 1f);
			byte b = (byte)(255.0 * (Math.Cos((double)(this.progress * 2f) * 3.141592653589793 + 3.141592653589793) / 2.0 + 0.5));
			b /= 25;
			b *= 25;
			fadeColor.W = b;
			
		}

		public void Draw()
		{
			Raylib.DrawRectangle(0, 0, 320, 180, new Color((int)fadeColor.X, (int)fadeColor.Y, (int)fadeColor.Z, (int)fadeColor.W));
		}

		public void Reset()
		{
			this.isComplete = false;
			this.progress = 0f;
		}

		private Vector4 fadeColor = new Vector4(0,0,0,0);

		private float speed;

		private bool isComplete;

		private float progress;
	}
}
