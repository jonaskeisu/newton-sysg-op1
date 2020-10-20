using System;

namespace GameLib
{
    public delegate void OnCollision(Object with);

    public class SpriteObj : Object
    {
        public Sprite Sprite { get; private set; }

        public SpriteObj(Position position, Sprite sprite, string tag = "") :
            base(position, tag)
        {
            Sprite = sprite;
        }

        public event OnCollision Collision;

        private Position Last => 
            (Position.Row + Sprite.Width - 1, Position.Column + Sprite.Height - 1);

        internal void CheckCollision(SpriteObj other)
        {
            if (Intersects(other))
            {
                if (Collision != null)
                { 
                    Collision(other);
                }
                if (other.Collision != null)
                {
                    other.Collision(this);
                }
            }
        }

        internal override void Draw()
        {
            Sprite.Draw(Position);
        }

        internal bool Intersects(SpriteObj other)
        {
            bool intersectingRows = 
                (other.Last.Row >= Position.Row && other.Last.Row <= Last.Row) ||
                (other.Position.Row >= Position.Row && other.Position.Row <= Last.Row) || 
                (other.Last.Row > Last.Row  &&  other.Position.Row < Position.Row);

            bool intersectingColumns = 
                (other.Last.Column >= Position.Column && other.Last.Column <= Last.Column) ||
                (other.Position.Column >= Position.Column && other.Position.Column <= Last.Column) || 
                (other.Last.Column > Last.Column  &&  other.Position.Column < Position.Column);

            return intersectingRows && intersectingColumns;         
        }
    }
}
