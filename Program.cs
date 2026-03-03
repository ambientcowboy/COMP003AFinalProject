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

        static void AddCharacter(List<GameCharacter> characters)
        {
            Console.WriteLine();
            Console.WriteLine("ADD NEW CHARACTER");
            int id = ReadIntInRange("ID (1-9999): ", 1, 9999);
            string name = ReadText("Name: ");
            
            Console.WriteLine("Select Race: ");
            Console.WriteLine("1. Human");
            Console.WriteLine("2. Elf");
            Console.WriteLine("3. Orc");
            Console.WriteLine("4. Dwarf");
            int raceChoice = ReadIntInRange("Race choice: ", 1, 4);
            string race = GetRace(raceChoice);
            
            Console.WriteLine("Select Class: ");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Rogue");
            Console.WriteLine("4. Archer");
            int classChoice = ReadIntInRange("Class choice: ", 1, 4);
            string characterClass = GetClass(classChoice);

            string weapon = ReadText("Weapon: ");
            Console.WriteLine("Select Region: ");
            Console.WriteLine("1. North");
            Console.WriteLine("2. Desert");
            Console.WriteLine("3. Forest");
            Console.WriteLine("4. Coast");
            int regionChoice = ReadIntInRange("Region choice: ", 1, 4);
            string region = GetRegion(regionChoice);
            
            Console.WriteLine("Select Difficulty: ");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            int difficultyChoice = ReadIntInRange("Difficulty choice: ", 1, 4);
            string difficulty = GetDifficulty(difficultyChoice);

            bool isGuildMember = ReadYesNo("Is in a guild? (y/n): ");
            string guildName;
            if (isGuildMember)
            {
                guildName = ReadText("Guild Name: ");
            }
            else
            {
                guildName = "None";
            }

            int age = ReadIntInRange("Age (18-500): ", 10, 500);
            int level = ReadIntInRange("Level (0-100): ", 0, 100);
            int health = ReadIntInRange("Health (1-100): ", 1, 100);
            int mana = ReadIntInRange("Mana (1-100): ", 1, 100);
            int strength = ReadIntInRange("Strength (1-100): ", 1, 100);
            int speed = ReadIntInRange("Speed (1-100): ", 1, 100);
            int defense = ReadIntInRange("Defense (1-100): ", 1, 100);
            int gold = ReadIntInRange("Gold (0-10000): ", 0, 10000);
            int skillPoints = ReadIntInRange("Skill Points (0-50): ", 0, 50);
            int petCount = ReadIntInRange("Pet Count (0-2): ", 0, 2);
            
            bool isMagic = ReadYesNo("Is Magic User? (y/n): ");
            bool hasPet = ReadYesNo("Has a Pet? (y/n): ");
            bool hasRareItem = ReadYesNo("Has Rare Item? (y/n): ");
            bool isActive = ReadYesNo("Is Active Character? (y/n): ");
            
            GameCharacter character = new GameCharacter(
                id,
                name,
                race,
                characterClass,
                weapon,
                region,
                guildName,
                difficulty,
                age,
                level,
                health,
                mana,
                strength,
                speed,
                defense,
                gold,
                skillPoints,
                petCount,
                isMagic,
                hasPet,
                isGuildMember,
                hasRareItem,
                isActive
                );
            characters.Add(character);
            Console.WriteLine("Character Added");
        }

        static void ViewAllCharacters(List<GameCharacter> characters)
        {
            Console.WriteLine();
            Console.WriteLine("VIEW ALL CHARACTERS");
            if (characters.Count == 0)
            {
                Console.WriteLine("No Characters Found");}
        }
    }
}