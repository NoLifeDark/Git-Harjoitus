using System;
using System.Collections.Generic;
using System.Data;

public abstract class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Gold { get; set; }

    public Character(string name, int health, int attack, int defense, int gold)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Gold = gold;
    }

    public void TakeDamage(int damage)
    {
        int totalDamage = Math.Max(damage - Defense, 0);
        Health -= totalDamage;
    }

    public void Heal(int healAmount)
    {
        Health += healAmount;
    }

    public abstract void AttackCharacter(Character target);
}

public class Knight : Character
{
    public Equipment Weapon { get; set; }
    public Equipment Armor { get; set; }
    public Equipment Potion { get; set; }

    public Knight(string name, int health, int attack, int defense, int gold)
        : base(name, health, attack, defense, gold)
    {
        Weapon = new Equipment("Weapon", 0, 0);
        Armor = new Equipment("Armor", 0, 0);
        Potion = new Equipment("Potion", 0, 0);
    }

    public override void AttackCharacter(Character target)
    {
        int damage = Attack - target.Defense;
        if (damage > 0)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.TakeDamage(damage);
        }
        else
        {
            Console.WriteLine($"{Name} attacks {target.Name}, but it has no effect!");
        }
    }
}

public class Monster : Character
{
    public Monster(string name, int health, int attack, int defense, int gold)
        : base(name, health, attack, defense, gold)
    {
    }

    public override void AttackCharacter(Character target)
    {
        int damage = Attack - target.Defense;
        if (damage > 0)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.TakeDamage(damage);
        }
        else
        {
            Console.WriteLine($"{Name} attacks {target.Name}, but it has no effect!");
        }
    }
}

public class Equipment
{
    public string Name { get; set; }
    public int AttackBonus { get; set; }
    public int DefenseBonus { get; set; }

    public Equipment(string name, int attackBonus, int defenseBonus)
    {
        Name = name;
        AttackBonus = attackBonus;
        DefenseBonus = defenseBonus;
    }
}

public class Shop
{
    public List<Equipment> Weapons { get; set; }
    public List<Equipment> Armors { get; set; }
    public List<Equipment> Potions { get; set; }

    public Shop()
    {
        Weapons = new List<Equipment>
        {
            new Equipment("Sword", 5, 0),
            new Equipment("Axe", 7, 0),
            new Equipment("Bow", 3, 0)
        };

        Armors = new List<Equipment>
        {
            new Equipment("Leather Armor", 0, 2),
            new Equipment("Chainmail", 0, 5),
            new Equipment("Plate Armor", 0, 8)
        };

        Potions = new List<Equipment> {
            new Equipment("Small Health Potion", 0, 0),
            new Equipment("Medium Health Potion", 0, 0),
            new Equipment("Large Health Potion", 0, 0)
        };
    }

    public Equipment BuyWeapon(int index)
    {
        if (index >= 0 && index < Weapons.Count)
        {
            Equipment selectedWeapon = Weapons[index];
            Weapons.RemoveAt(index);
            return selectedWeapon;
        }
        return null;
    }

    public Equipment BuyArmor(int index)
    {
        if (index >= 0 && index < Armors.Count)
        {
            Equipment selectedArmor = Armors[index];
            Armors.RemoveAt(index);
            return selectedArmor;
        }
        return null;
    }

    public Equipment BuyPotion(int index)
    {
        if (index >= 0 && index < Potions.Count)
        {
            Equipment selectedPotion = Potions[index];
            Potions.RemoveAt(index);
            return selectedPotion;
        }
        return null;
    }
}

public class Game
{
    static void Main()
    {
        Console.Clear();

        Knight player = new Knight("Knight", 100, 10, 5, 10);
        Shop shop = new Shop();

        while (true)
        {
            Console.WriteLine("1. Fight an enemy");
            Console.WriteLine("2. Visit the shop");
            Console.WriteLine("3. Quit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    FightEnemy(player);
                    break;
                case 2:
                    VisitShop(player, shop);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    static void FightEnemy(Knight player)
    {
        // Randomly select an enemy
        Monster enemy = GetRandomEnemy();

        Console.WriteLine($"You encounter a {enemy.Name}!");

        while (player.Health > 0 && enemy.Health > 0)
        {
            PlayerTurn(player, enemy);

            if (enemy.Health > 0)
                EnemyTurn(player, enemy);
        }

        if (player.Health > 0)
        {
            Console.WriteLine($"You defeated the {enemy.Name} and earned {enemy.Gold} gold!");
            player.Gold += enemy.Gold;
        }
        else
        {
            Console.WriteLine($"You were defeated by the {enemy.Name}. Game over!");
            Environment.Exit(0);
        }
    }

    static void PlayerTurn(Knight player, Monster enemy)
    {
        Console.WriteLine("Your turn:");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Use Potion");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                player.AttackCharacter(enemy);
                break;
            case 2:
                Console.WriteLine("Choose a potion: ");
                Console.WriteLine("1. Small Health Potion (+1 HP)");
                Console.WriteLine("2. Medium Health Potion (+3 HP)");
                Console.WriteLine("3. Large Health Potion (+5 HP)");

                int potionChoice = Convert.ToInt32(Console.ReadLine());

                switch (potionChoice)
                {
                    case 1:
                        UseSmallHealthPotion(player);
                        break;
                    case 2:
                        UseMediumHealthPotion(player);
                        break;
                    case 3:
                        UseLargeHealthPotion(player);
                        break;
                    default:
                        Console.WriteLine("Invalid potion choice. Attack is chosen by default.");
                        player.AttackCharacter(enemy);
                        break;
                }
                break;
            default:
                Console.WriteLine("Invalid choice. Attack is chosen by default.");
                player.AttackCharacter(enemy);
                break;
        }
    }

    static void UseSmallHealthPotion(Knight player)
    {
        int smallHealAmount = 1;
        player.Heal(smallHealAmount);
        Console.WriteLine($"{player.Name} used a small health potion and healed {smallHealAmount} health");
    }

    static void UseMediumHealthPotion(Knight player)
    {
        int mediumHealAmount = 3;
        player.Heal(mediumHealAmount);
        Console.WriteLine($"{player.Name} used a medium health potion and healed {mediumHealAmount} health");
    }

    static void UseLargeHealthPotion(Knight player)
    {
        int largeHealAmount = 5;
        player.Heal(largeHealAmount);
        Console.WriteLine($"{player.Name} used a large health potion and healed {largeHealAmount} health");
    }

    static void EnemyTurn(Knight player, Monster enemy)
    {
        Console.WriteLine($"{enemy.Name}'s turn:");
        enemy.AttackCharacter(player);
    }

    static void UsePotion(Knight player)
    {
        int healAmount = 20; // You can adjust this value based on your game's balancing
        player.Heal(healAmount);
        Console.WriteLine($"{player.Name} used a potion and healed {healAmount} health!");
    }

    public class Goblin : Monster
    {
        public Goblin()
            : base("Goblin", 30, 5, 2, 5)
        {

        }
    }

    public class Ogre : Monster
    {
        public Ogre()
            : base("Ogre", 50, 8, 4, 10)
        {

        }
    }

    public class Dragon : Monster
    {
        public Dragon()
            : base("Dragon", 80, 12, 6, 20)
        {

        }
    }

    static Monster GetRandomEnemy()
    {
        Random rand = new Random();
        int enemyType = rand.Next(1, 4); // Random number between 1 and 3

        switch (enemyType)
        {
            case 1:
                return new Goblin();
            case 2:
                return new Ogre();
            case 3:
                return new Dragon();
            default:
                return new Goblin(); // Default to Goblin if something goes wrong
        }
    }

    static void VisitShop(Knight player, Shop shop)
    {
        Console.WriteLine("Welcome to the shop!");
        Console.WriteLine("1. Buy a weapon");
        Console.WriteLine("2. Buy armor");
        Console.WriteLine("3. Buy a potion");
        Console.WriteLine("4. Exit shop");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                BuyWeapon(player, shop);
                break;
            case 2:
                BuyArmor(player, shop);
                break;
            case 3:
                BuyPotion(player, shop);
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose again.");
                break;
        }
    }

    // Ase valikoima
    static void BuyWeapon(Knight player, Shop shop)
    {
        Console.WriteLine("Available weapons: ");
        DisplayEquipmentList(shop.Weapons);

        int index = Convert.ToInt32(Console.ReadLine());
        Equipment selectedWeapon = shop.BuyWeapon(index);

        if (selectedWeapon != null)
        {
            Console.WriteLine($"You bought a {selectedWeapon.Name}!");
            player.Weapon = selectedWeapon;
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    // Suoja valikoima
    static void BuyArmor(Knight player, Shop shop)
    {
        Console.WriteLine("Available Armors: ");
        DisplayEquipmentList(shop.Armors);

        int index = Convert.ToInt32(Console.ReadLine());
        Equipment selectedArmor = shop.BuyArmor(index);

        if (selectedArmor != null)
        {
            Console.WriteLine($"You bought a {selectedArmor.Name}!");
            player.Armor = selectedArmor;
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    // Juoma valikoima
    static void BuyPotion(Knight player, Shop shop)
    {
        Console.WriteLine("Available Potions: ");
        DisplayEquipmentList(shop.Potions);

        int index = Convert.ToInt32(Console.ReadLine());
        Equipment selectedPotion = shop.BuyPotion(index);

        if (selectedPotion != null)
        {
            Console.WriteLine($"You bought a {selectedPotion.Name}!");
            player.Potion = selectedPotion;
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    static void DisplayEquipmentList(List<Equipment> equipmentList)
    {
        for (int i = 0; i < equipmentList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {equipmentList[i].Name}");
        }
    }
}
