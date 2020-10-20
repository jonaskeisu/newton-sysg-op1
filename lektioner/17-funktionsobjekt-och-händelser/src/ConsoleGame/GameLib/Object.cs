using System;

namespace GameLib
{
    public delegate void OnTick(int tick);

    abstract public class Object
    {
        public string Tag { get; private set; }

        public Object(Position position, string tag = "")
        {
            Position = position;
            Tag = tag;
        }

        public Position Position { get; set; }

        public event OnTick Tick;

        internal void Update(int tick)
        {
            if (Tick != null)
            {
                Tick(tick);
            }
        }

        abstract internal void Draw();
    }
}
