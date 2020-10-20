using System;
using System.Threading;

namespace GameLib
{
    public class Game
    {
        private int tick; 
        private Scene scene; 
        private bool quit;

        public Game(Scene startScene)
        {
            tick = 0;
            scene = startScene;
        }

        public void TransitionTo(Scene scene)
        {
            tick = 0; 
            this.scene = scene;
        }

        public void Quit()
        {
            quit = true;
        }

        public void Run()
        {
            Console.CursorVisible = false;
            while (!quit)
            {
                for (int i = 0; i < 10; i++)
                {
                    scene.Update(tick++);
                }
                
                while (Console.KeyAvailable) 
                {
                    scene.RegisterKey(Console.ReadKey(true).Key);
                }
                Console.Clear();
                scene.Draw();
                Thread.Sleep(40);
            }
            Console.CursorVisible = true;
        }
    }
}