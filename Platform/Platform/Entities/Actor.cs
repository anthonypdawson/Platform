using System.Collections.Generic;
using Library.Physics;
using Library.Physics.Controllers;

namespace Platform
{
    public interface IActor
    {
        Vector Velocity { get; }
        Vector Acceleration { get; }

    }
    /// <summary>
    /// A more advanced type of game object.  Like an entity, it has a position.
    /// Unlike an entity an Actor can change it's position in the world
    /// </summary>
    public abstract class Actor : Entity, IActor
    {
        public List<IPhysicsController> Controllers;

        public Vector Direction;
        
        public Vector MaxVelocity;

        public Vector Power;

        public Vector Velocity { get; private set; }

        public Vector Acceleration
        {
            //get { return Force/Mass; }
            get;
            internal set;
        }
        public Vector Force
        {
            get { return Direction * Power; }
        }

        public double Rotation;


        internal void UpdateVelocity()
        {
            //Velocity += Acceleration * new Vector2((float)GameState.GameTime.ElapsedGameTime.TotalMilliseconds);
            Velocity += Acceleration;
        }

        internal void UpdatePosition()
        {
            Position += Velocity;
        }

        public virtual void Update()
        {
            UpdateVelocity();
            UpdatePosition();
        }
    }
}
