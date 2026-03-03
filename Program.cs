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
                Console.WriteLine("No Characters Found");
                return;
            }

            foreach (GameCharacter character in characters)
            {
                character.DisplayInfo();
            }
        }
        static void SearchCharacters(List<GameCharacter> characters)
        {
            Console.WriteLine();
            Console.WriteLine("SEARCH CHARACTERS");
            if (characters.Count == 0)
            {
                Console.WriteLine("No Characters Found");
                return;
            }
            string keyword = ReadText("Enter Search Keyword: ").ToLower();
            bool found = false;
            foreach (GameCharacter character in characters)
            {
                if (character.MatchesSearch(keyword))
                {
                    character.DisplayInfo();
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No Matching Characters Found");
            }
        }

        static void ShowSummary(List<GameCharacter> characters)
        {
            Console.WriteLine();
            Console.WriteLine("SHOW CHARACTER SUMMARY");
            if (characters.Count == 0)
            {
                Console.WriteLine("No Characters Available");
                return;
            }

            int totalLevel = 0;
            int totalGold = 0;
            int totalPower = 0;
            int activeCount = 0;
            int rareItemCount = 0;
            int highestPower = characters[0].PowerScore;
            string highestName = characters[0].Name;

            foreach (GameCharacter character in characters)
            {
                totalLevel += character.level;
                totalGold += character.Gold;
                totalPower += character.PowerScore;
                if (character.IsActive)
                {
                    activeCount++;
                }
                if (character.HasRareItem)
                {
                    rareItemCount++;
                }

                if (character.PowerScore > highestPower)
                {
                    highestPower = character.PowerScore;
                    highestName = character.Name;
                }
            }
            double averageLevel = (double)totalLevel / characters.Count;
            double averagePower = (double)totalPower / characters.Count;
            Console.WriteLine($"Total Characters: {characters.Count}");
            Console.WriteLine($"Average Level: {averageLevel:F2}");
            Console.WriteLine($"Total Gold: {totalGold}");
            Console.WriteLine($"Average Power Score: {averagePower:F2}");
            Console.WriteLine($"Total Active Characters: {activeCount}");
            Console.WriteLine($"Total Rare Items: {rareItemCount}");
            Console.WriteLine($"Highest Power: {highestPower} ({highestName})");
        }

        static int ReadIntInRange(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    int value = int.Parse(input);
                    if (value < min || value > max)
                    {
                        Console.WriteLine($"Enter a number between {min} and {max}.");
                    }
                    else
                    {
                        return value;
                    }
                }
                catch
                {
                    Console.WriteLine($"Invalid Input. Please enter a whole number.");
                }
            }
        }

        static string ReadText(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                    
                }
                Console.WriteLine("Input cannot be blank");
            }
        }

        static bool ReadYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.Trim().ToLower();
                    if (input == "y" || input == "yes")
                    {
                        return true;
                    }
                    else if (input == "n" || input == "no")
                    {
                        return false;
                    }
                }
                Console.WriteLine("Please enter yes or no.");
            }
        }

        static string GetRace(int choice)
        {
            switch (choice)
            {
                case 1: return "Human";
                case 2: return "Elf";
                case 3: return "Orc";
                case 4: return "Dwarf";
                default: return "Unknown";
            }
        }

        static string GetClass(int choice)
        {
            switch (choice)
            {
                case 1: return "Warrior";
                case 2: return "Mage";
                case 3: return "Rogue";
                case 4: return "Archer";
                default: return "Unknown";
            }
        }

        static string GetDifficulty(int choice)
        {
            switch (choice)
            {
                case 1: return "Easy";
                case 2: return "Medium";
                case 3: return "Hard";
                default: return "Unknown";
            }
        }
    }
}
class GameCharacter
{
    public string Name;
    public string Race;
    public string CharacterClass;
    public string Weapon;
    public string Region;
    public string GuildName;
    public string Difficulty;
    public string RankTitle;
    public int Id;
    public int Age;
    public int Level;
    public int Health;
    public int Mana;
    public int Strength;
    public int Speed;
    public int Defense;
    public int Gold;
    public int SkillPoints;
    public int PetCount;
    public int PowerScore;
    public bool IsMagic;
    public bool HasPet;
    public bool IsGuildMember;
    public bool HasRareItem;
    public bool IsActive;

    public GameCharacter(
        int id,
        string name,
        string race,
        string characterClass,
        string weapon,
        string region,
        string guildName,
        string difficulty,
        int age,
        int level,
        int health,
        int mana,
        int strength,
        int speed,
        int defense,
        int gold,
        int skillPoints,
        int petCount,
        bool isMagic,
        bool hasPet,
        bool isGuildMember,
        bool hasRareItem,
        bool isActive)
    {
        Id = id;
        Name = name;
        Race = race;
        CharacterClass = characterClass;
        Weapon = weapon;
        Region = region;
        GuildName = guildName;
        Difficulty = difficulty;
        
        Age = age;
        Level = level;
        Health = health;
        Mana = mana;
        Strength = strength;
        Speed = speed;
        Defense = defense;
        Gold = gold;
        SkillPoints = skillPoints;
        PetCount = petCount;
        IsMagic = isMagic;
        HasPet = hasPet;
        IsGuildMember = isGuildMember;
        HasRareItem = hasRareItem;
        IsActive = isActive;
        CalculateRank();
    }

    public void CalculateRank()
    {
        PowerScore = Level + Health + Mana + Strength + Speed + Defense + SkillPoints + PetCount;
        if (HasRareItem)
        {
            PowerScore += 20;
        }
        if (IsMagic)
        {
            PowerScore += 10;
        }
        if (IsActive)
        {
            PowerScore += 5;
        }

        if ((Level >= 40 && (Strength >= 60 || Mana >= 60)) || (HasRareItem && IsMagic))
        {
            if (Defense >= 50 && IsActive)
            {
                RankTitle = "Elite";
            }
            else
            {
                RankTitle = "Advanced";
            }
        }
        else if ((Level >= 20 && Health >= 40) || (IsGuildMember && SkillPoints >= 10))
        {
            RankTitle = "Skilled";
        }
        else
        {
            RankTitle = "Beginner";
        }
    }
    public void DisplayInfo()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Race: {Race}");
        Console.WriteLine($"Character Class: {CharacterClass}");
        Console.WriteLine($"Weapon: {Weapon}");
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Guild Name: {GuildName}");
        Console.WriteLine($"Difficulty: {Difficulty}");
        Console.WriteLine($"Rank Title: {RankTitle}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Mana: {Mana}");
        Console.WriteLine($"Strength: {Strength}");
        Console.WriteLine($"Speed: {Speed}");
        Console.WriteLine($"Defense: {Defense}");
        Console.WriteLine($"Gold: {Gold}");
        Console.WriteLine($"Skill Points: {SkillPoints}");
        Console.WriteLine($"Pet Count: {PetCount}");
        Console.WriteLine($"IsMagic: {IsMagic}");
        Console.WriteLine($"HasPet: {HasPet}");
        Console.WriteLine($"IsGuildMember: {IsGuildMember}");
        Console.WriteLine($"HasRareItem: {HasRareItem}");
        Console.WriteLine($"IsActive: {IsActive}");
        Console.WriteLine("------------------------");
    }

    public bool MatchesSearch(string keyword)
    {
        keyword = keyword.ToLower();
        return 
    }
}