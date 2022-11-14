using System;
using System.Numerics;
using Raylib_cs;

namespace Andonuts.Actors
{
	public abstract class SolidActor : Actor
	{
		public Vector2 LastPosition
		{
			get
			{
				return lastPosition;
			}
		}

		public bool Solid
		{
			get
			{
				return isSolid;
			}
			set
			{
				isSolid = value;
			}
		}

		public virtual bool MovementLocked
		{
			get
			{
				return isMovementLocked;
			}
			set
			{
				isMovementLocked = value;
			}
		}

		public SolidActor()
		{
			isSolid = true;
		}

		public override void Update()
		{

			lastPosition = position;

			//position += velocity;
			if (velocity.X != 0f && !isMovementLocked)
			{
				moveTemp = new Vector2(position.X + velocity.X, position.Y);
				bool flag = true; //collision crap to add later
				if (flag)
				{
					position = moveTemp;
				}
				else
				{
					velocity.X = 0f;
					//HandleCollision(collisionResults);
				}
			}
			if (Velocity.Y != 0f && !isMovementLocked)
			{
				moveTemp = new Vector2(position.X, position.Y + velocity.Y);
				bool flag = true;
				if (flag)
				{
					position = moveTemp;
				}
				else
				{
					velocity.Y = 0f;

				}
			}
		}

		protected bool isMovementLocked;

		protected bool isSolid;

		private Vector2 moveTemp;

		public enum States { idle, walk };

		protected Vector2 lastPosition;
	}
}
