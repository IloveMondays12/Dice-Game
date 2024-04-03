using Making_a__die;

namespace Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your The thundering times. \nYou'll be starting with 100$ and will go from there.");

            bool diceGame = false, doubles, even;
            double balance = 100.00, bet, win = 0.00;
            string betOption, gameEnthusiasm;
            Die dieOne;
            Die dieTwo;
            dieOne = new Die();
            dieTwo = new Die();

            while (diceGame == false)
            {
                bet = 0;
                Console.WriteLine($"You have {balance}$ in your betting account go to town \nYou will be rolling two dice and putting money on the expected result.");
                Console.WriteLine("Bet Options: \nA) Doubles - X3 your bet \nB) Not Doubles - X1.5 your bet\nC) Even Roll - X2 your bet\nD) Odd Roll - X2 your bet");
                betOption = null;
                while (betOption == null)
                {
                    
                    Console.WriteLine("Which result would you like to put your money on?");
                    betOption = Console.ReadLine().ToLower();
                    if (betOption == "a")
                    {
                        Console.WriteLine("You've locked in on Doubles.");
                        win = 3.00;
                    }
                    else if (betOption == "b")
                    {
                        Console.WriteLine("You've locked in on not doubles");
                        win = 1.50;
                    }
                    else if (betOption == "c")
                    {
                        Console.WriteLine("You've locked in on an Even Result");
                        win = 2.00;
                    }
                    else if (betOption == "d")
                    {
                        Console.WriteLine("You've locked in on an Odd result");
                        win = 2.00;
                    }
                    else if (betOption != null)
                    {
                        Console.WriteLine("Seems your bet isn't in our system, we'll say your sitting out this turn");
                        win = 0.00;
                    }
                    else
                    {
                        Console.WriteLine("Your bet wasn't valid, make sure you use the letter representative and nothing else! \nTry again...");
                    }

                }

                Console.WriteLine($"Balance: {balance}$\nNow that we got your picks,\nHow much would you like to put down (remember you only have so much)?");
                if(Double.TryParse(Console.ReadLine(), out bet))
                {
                     if (bet>balance)
                    {
                        bet = balance;
                    }
                    if (bet<0)
                    {
                        bet = 0.00;
                    }
                }
                else
                {
                    bet = 0.00;
                }
                bet = Math.Round(bet, 2);
                Console.WriteLine("Alright we're ready to roll! \nPress 'ENTER' to roll.");
                Console.ReadLine();
                dieOne.RollDie();
                dieTwo.RollDie();
                dieOne.DrawRoll();
                dieTwo.DrawRoll();

                Console.WriteLine($"The result is {(dieOne.Roll + dieTwo.Roll)}");
                if (((dieOne.Roll + dieTwo.Roll) % 2.00) == 0)
                {
                    even = true;
                    Console.WriteLine("You got an even roll");
                }
                else 
                {
                    even = false;
                    Console.WriteLine("You got an odd roll");
                }
                if(dieOne.Roll == dieTwo.Roll )
                {
                    doubles = true;
                    Console.WriteLine("Huzzah! you got doubles.");
                }
                else
                {
                    doubles = false;
                    Console.WriteLine("No doubles.");
                }
                if (betOption == "a")
                {
                    if (doubles == true)
                    {
                        balance = (bet * win) + balance;
                        Console.WriteLine("\nWinner, winner, chicken dinner!");
                    }
                    else
                    {
                        balance = balance - bet;
                        Console.WriteLine("\nBetter luck next time!");
                    }
                }
                if (betOption=="b") 
                {
                    if (doubles == true)
                    {
                        balance = balance - bet;
                        Console.WriteLine("\nBetter luck next time!");
                    }
                    else
                    {
                        balance = (bet * win) + balance;
                        Console.WriteLine("\nWinner, winner, chicken dinner!");
                    }
                }
                if (betOption=="c") 
                {
                    if (even == true)
                    {
                        balance = (bet * win) + balance;
                        Console.WriteLine("\nWinner, winner, chicken dinner!");
                    }
                    else
                    {
                        balance = balance - bet;
                        Console.WriteLine("\nBetter luck next time!");
                    }
                }
                if (betOption=="d") 
                {
                    if (even == true)
                    {
                        balance = balance - bet;
                        Console.WriteLine("\nBetter luck next time!");
                    }
                    else
                    {
                        balance = (bet * win) + balance;
                        Console.WriteLine("\nWinner, winner, chicken dinner!");
                    }
                }
                balance = Math.Round(balance,2);
                Console.WriteLine($"You have {balance}$ left in your account\nWould you like to continue playing. Y or N");
                gameEnthusiasm = Console.ReadLine().Trim().ToLower();
                if (gameEnthusiasm == "y" )
                {
                    diceGame = false;
                }
                else if (gameEnthusiasm == "n")
                {
                    diceGame = true;
                    Console.WriteLine("Thanks for stopping by!");
                }
                else 
                {
                    Console.WriteLine("Looks like your having troubles navigating, looks like your stuck with us forever\nMWAHAHAHA!");
                }

            }
        }
    }
}