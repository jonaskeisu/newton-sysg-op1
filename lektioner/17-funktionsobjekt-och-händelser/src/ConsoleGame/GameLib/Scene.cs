using System;
using System.Collections;
using System.Collections.Generic;

namespace GameLib
{
    public delegate void OnKey(ConsoleKey key);

    public class Scene : IEnumerable
    {
        private List<Object> objects = new List<Object>();

        public void Add(Object obj)
        {
            objects.Add(obj);
        }

        public void Remove(Object obj)
        {
            objects.Remove(obj);
        }

        public event OnKey Key;

        internal void Update(int tick)
        {
            foreach (var obj in objects.ToArray())
            {
                obj.Update(tick);
            }
            var objsCopy = objects.ToArray();
            for (int i = 0; i < objsCopy.Length; i++)
            {
                for (int j = i + 1; j < objsCopy.Length; j++)
                {
                    if (objsCopy[i] is SpriteObj obj1 && objsCopy[j] is SpriteObj obj2)
                    {
                        obj1.CheckCollision(obj2);
                    }

                }
            }
        }

        internal void Draw()
        {
            foreach (var obj in objects)
            {
                obj.Draw();
            }
        }

        internal void RegisterKey(ConsoleKey key)
        {
            if (Key != null)
            {
                Key(key);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return objects.GetEnumerator();
        }
    }
}