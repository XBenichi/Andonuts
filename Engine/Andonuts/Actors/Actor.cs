using System;
using System.Numerics;

namespace Andonuts.Actors
{
	public abstract class Actor : IDisposable
	{
		public virtual Vector2 Position
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
			}
		}

		public virtual Vector2 Velocity
		{
			get
			{
				return velocity;
			}
		}

		public virtual float ZOffset
		{
			get
			{
				return zOffset;
			}
			set
			{
				zOffset = value;
			}
		}

		~Actor()
		{
			Dispose(false);
		}

		public virtual void Input()
		{
		}

		public virtual void Update()
		{
			position += velocity;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
			}
			disposed = true;
		}
		protected float speed;

		protected Vector2 position;

		protected float zOffset;

		protected Vector2 velocity;

		protected bool disposed;
	}
}
