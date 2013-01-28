
using Library.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Platform
{

    public class World
    {
        public float Width;

        public float Height;
    }
    public class Level
    {
        
    }
    /// <summary>
    /// Entities are any object in the game that has a position
    /// Separated from Actor based on the fact that an Actor can move itself.
    /// An entity can move, but it must be acted on externally, it cannot move itself
    /// </summary>
    public abstract class Entity : IEntity
    {
        public Vector2 Position { get; internal set; }

        public Texture2D Texture;

        public Vector2 Origin
        {
            get
            {
                return new Vector2(Texture.Width / 2f, Texture.Height / 2f);                
            }
        }


        public float Mass { get; private set; }

        public float Height { get { return Texture.Height; } }
        public float Width { get { return Texture.Width;  } }

        public float Scale { get; private set; }

        public float Top
        {
            get
            {
                return Position.Y;
            }
        }
        public float Bottom
        {
            get
            {
                return Position.Y + Height;
            }
        }
        public float Left
        {
            get
            {
                return Position.X;
            }
        }
        public float Right
        {
            get
            {
                return Position.X + Width;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

    }
    /// <summary>
    /// A more advanced type of game object.  Like an entity, it has a position.
    /// Unlike an entity an Actor can change it's position in the world
    /// </summary>
    public abstract class Actor : Entity
    {
        public Vector2 Direction;        

        public Vector2 Velocity;

        public Vector2 MaxVelocity;

        public Vector2 Power;

        public Vector2 Acceleration
        {
            get { return Force/Mass; }
        }
        public Vector2 Force
        {
            get { return Direction*Power; }
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
