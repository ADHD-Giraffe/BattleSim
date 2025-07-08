int monsterHp = 50;
int heroHp = 50;
int heroStamina = 10;
int monsterStamina = 10;
Random attack = new Random();
int perLevelStaminaGain = 3;

Console.WriteLine("Welcome to Battle sim!");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Enter Player 1 Name:");
string player1 = Console.ReadLine();
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Enter Player 2 Name:");
string player2 = Console.ReadLine();
Console.WriteLine();
Console.ResetColor();

if (player1 == "Daddy" || player2 == "Daddy")
    Console.WriteLine("Game Over, Daddy always Wins!!");
else
{


    while (heroHp >= 0 && monsterHp >= 0)
    {
        int heroAttack = attack.Next(1, 11);
        Console.WriteLine($"{player1}, You have {heroStamina} stamina, Would you like to use a weak attack (2 stamina) or a strong attack (5 stamina)");
        string heroAttackType = Console.ReadLine();
        while (heroAttackType.ToLower() != "weak" && heroAttackType.ToLower() != "strong")
        {
            Console.WriteLine("Could not identify the attack type plaease enter \"weak\" or \"strong\"");
            Console.WriteLine($"{player1}, You have {heroStamina} stamina, Would you like to use a weak attack (2 stamina) or a strong attack (5 stamina)");
            heroAttackType = Console.ReadLine();
        }
        if (heroAttackType.ToLower() == "weak" && heroStamina >= 2)
        {
            heroAttack = attack.Next(1, 5);
            heroStamina -= 2;
        }
        if (heroAttackType.ToLower() == "strong" && heroStamina >= 5)
        {
            heroAttack = attack.Next(3, 10);
            heroStamina -= 5;
        }
        else if (heroAttackType.ToLower() == "strong" && heroStamina < 5)
        {
            Console.WriteLine($"Sorry, you stamina is {heroStamina} You do not have enough stamina to perfrom that move \n Performing Weak attack");
            heroAttack = attack.Next(1, 5);
            heroStamina -= 2;
        }
        monsterHp -= heroAttack;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{player2} was damaged and lost {heroAttack} health and now has {monsterHp} health.");
        Console.ResetColor();
        Console.WriteLine("");
        heroStamina += perLevelStaminaGain;

        if (monsterHp <= 0)
        {
            Console.WriteLine($"{player1} Wins!");
            break;
        }


        int monsterAttck = attack.Next(1, 11);
        Console.WriteLine($"{player2}, You have {monsterStamina} stamina, Would you like to use a weak attack (2 stamina) or a strong attack (5 stamina)");
        string monsterAttackType = Console.ReadLine();
        while (monsterAttackType.ToLower() != "weak" && monsterAttackType.ToLower() != "strong")
        {
            Console.WriteLine("Could not identify the attack type plaease enter \"weak\" or \"strong\"");
            Console.WriteLine($"{player2}, You have {monsterStamina} stamina, Would you like to use a weak attack (2 stamina) or a strong attack (5 stamina)");
            monsterAttackType = Console.ReadLine();
        }
        if (monsterAttackType.ToLower() == "weak" && monsterStamina >= 2)
        {
            monsterAttck = attack.Next(1, 5);
            monsterStamina -= 2;
        }
        if (monsterAttackType.ToLower() == "strong" && monsterStamina >= 5)
        {
            monsterAttck = attack.Next(3, 10);
            monsterStamina -= 5;
        }
        else if (monsterAttackType.ToLower() == "strong" && monsterStamina < 5)
        {
            Console.WriteLine($"Sorry, you stamina is {monsterStamina} You do not have enough stamina to perfrom that move \n Performing Weak attack");
            monsterAttck = attack.Next(1, 5);
            monsterStamina -= 2;
        }

        heroHp -= monsterAttck;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{player1} was damaged and lost {monsterAttck} health and now has {heroHp} health");
        Console.ResetColor();
        Console.WriteLine("");
        monsterStamina += perLevelStaminaGain;

        if (heroHp <= 0)
        {
            Console.WriteLine($"{player2} Wins!");
            break;
        }
    }
}
Console.WriteLine("Game Over! Any key to exit");
Console.ReadLine();
