using System;

namespace GameLib
{
    public class Text : Object
    {
        public string String { get; set; }

        public Text(Position position, string text, string tag = "") : 
            base(position, tag)
        {
            String = text;
        }

        internal override void Draw()
        {
            Console.SetCursorPosition(Position.Column, Position.Row);
            Console.Write(String);
        }
    }
}