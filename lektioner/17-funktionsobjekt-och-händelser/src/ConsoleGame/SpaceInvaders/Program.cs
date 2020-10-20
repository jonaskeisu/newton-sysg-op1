using System;
using GameLib;

namespace SpaceInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            Scene start = new Scene();
            Game game = new Game(start);

            var spaceSprite = new Sprite(
                "    XX    XX     XX      XX   XXXX",
                "   X      X X   X  X    X     X   ",
                "    XX    XX    XXXX    X     XXX ",
                "      X   X     X  X    X     X   ",
                "    XX    X     X  X     XX   XXXX"
            );


            start.Add(new SpriteObj((3, 3), spaceSprite));
            start.Add(new Text((10, 3 + spaceSprite.Height + 2), "Press any key to start"));

            Scene play = new Scene();

            var heroSprite = new Sprite(
                " X ",
                "XXX"
            );

            var bulletSprite = new Sprite("X");

            var hero = new SpriteObj((20, 10), heroSprite, "hero");

            play.Add(hero);

            play.Key += key => 
            {
                switch(key)
                {
                    case ConsoleKey.LeftArrow: hero.Position += (0, -1); break;
                    case ConsoleKey.RightArrow: hero.Position += (0, 1); break;
                    case ConsoleKey.Spacebar: 
                        var bullet = new SpriteObj(
                            hero.Position + (-2, 1), bulletSprite, "bullet");
                        bullet.Tick += t => 
                        {
                            if (t % 5 == 0)
                            {
                                bullet.Position += (-1, 0);
                            }
                            if (bullet.Position.Row == -1)
                            {
                                play.Remove(bullet);
                            }
                        };
                        play.Add(bullet);
                        break;
                    default:
                        break;
                }
            };

            int alienDir = 1; 

            var alienSprite = new Sprite(
                "XXX",
                "XXX"
            );

            for (int i = 0; i < 5; i++)
            {
                var alien = new SpriteObj((0, i * 5), alienSprite, "alien");
                alien.Tick += t =>
                {
                    if (t % 10 == 0)
                    {
                        alien.Position += (0, alienDir);
                    }
                };
                alien.Collision += obj =>
                {
                    if (obj.Tag == "bullet")
                    {
                        play.Remove(alien);
                    }
                };
                play.Add(alien);
            }

            hero.Tick += t =>
            {
                if ((t + 1) % 200 == 0)
                {
                    alienDir = alienDir == 1 ? -1 : 1;
                    foreach (GameLib.Object obj in play)
                    {
                        if (obj.Tag == "alien")
                        {
                            obj.Position += (1, 0);
                        }
                    }

                }
            };

            start.Key += _ => game.TransitionTo(play);

            game.Run();

        }
    }
}
