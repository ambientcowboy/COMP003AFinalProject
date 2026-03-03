using System;
using System.Collections.Generic;

namespace GameCharacterCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GameCharacter> characters = new List<GameCharacter>();
            bool running = true;
            while (running)
            {
                ShowMenu();
                int choice = ReadIntInRange("Choose an option:", 1, 5);
                switch (choice)
                {
                    case 1:AddCharacter(characters); break;
                    case 2: ViewAllCharacters(characters); break;
                    case 3: SearchCharacters(characters); break;
                    case 4: ShowSummary(characters); break;
                    case 5: running = false; Console.WriteLine("Program Ended"); break;
                }
                Console.WriteLine();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("======================");
            Console.WriteLine("CHARACTER CREATION");
            Console.WriteLine("=======================");
            Console.WriteLine("1. Add Character");
            Console.WriteLine("2. View All Characters");
            Console.WriteLine("3. Search Characters");
            Console.WriteLine("4. Show Characters");
            Console.WriteLine("5. Exit");
        }
    }
}