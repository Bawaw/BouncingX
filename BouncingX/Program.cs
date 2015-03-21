using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace BouncingX
{
    class Program
    {
        static List<Box> boxes;
        static Random random;

        static void Main(string[] args)
        {
            boxes = new List<Box>();
            random = new Random();
            
            Box newBox;
            newBox = new Box();
            newBox.Initialize();
            newBox.Velocity = new Point(1, 1);
            newBox.Character = newBox.Health;
            
            boxes.Add(newBox);

            while(true)
            {
                Console.Clear();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        AddRandomBox(ConsoleColor.Blue);
                    }
                }
                

                for (int i = boxes.Count -1 ; i >= 0; i--)
                {
                    boxes[i].update();
                    if (boxes[i].Health > 0)
                    {            
                           boxes[i].draw();
                    }

                    else
                    {
                           boxes.RemoveAt(i);
                           continue;
                    }

                                      
                }

                System.Threading.Thread.Sleep(33);
            }
        }

        static void AddRandomBox(ConsoleColor color)
        {
            Box box = new Box();
            box.Initialize();
            box.Velocity = new Point(random.Next(1, 4), random.Next(1, 4));
            box.Position = new Point(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
            box.Character = box.Health;
            boxes.Add(box);
        }
    }
}
