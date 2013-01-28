using Library.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platform
{

    public interface IEntity
    {
        World World { get; }
        Vector Position { get; }

        float Mass { get; }
        float Height { get; }
        float Width { get; }
        float Scale { get; }

        float Top { get; }
        float Bottom { get; }
        float Left { get; }
        float Right { get; }
    }

    /// <summary>
    /// Entities are any object in the game that has a position
    /// Separated from Actor based on the fact that an Actor can move itself.
    /// An entity can move, but it must be acted on externally, it cannot move itself
    /// </summary>
    public abstract class Entity : IEntity
    {
        public float Mass { get; private set; }
        public float Height { get { return Texture.Height; } }
        public float Width { get { return Texture.Width; } }
        public float Scale { get; private set; }
        public World World { get; internal set; }
        public Vector Position { get; internal set; }
        public Texture2D Texture;

        public Vector Origin
        {
            get
            {
                return new Vector(Texture.Width / 2f, Texture.Height / 2f);
            }
        }

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
    /// Data used to determine different statuses of an entity
    /// </summary>
    public class QueryData<T> where T : IEntity
    {
        public World World;

        public bool IsActive(T ent)
        {
            return !(ent.Equals(null));
        }

        public bool InView(T ent)
        {
            return (ent.Position >= new Vector(0) && ent.Position <= World.Size);
        }
    }
}
