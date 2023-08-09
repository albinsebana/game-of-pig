using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GameofPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to Game of Pig!");
            int totalScore = 0;
            int turnScore = 0;
            string choice;
            int count=1;

            Console.WriteLine("TURN - " + count);
//-------------------------------------------------------------------------------------------------------------------
            while (totalScore< 20)
            {
                Console.WriteLine("Enter 'r' to Roll again and 'h' to hold.\n");
                choice=Console.ReadLine();


                if (choice == "r") 
                {
                    int roll = RollDice(0);
                    turnScore = roll;
                    Console.WriteLine(turnScore);
               
                    DiceIsOne(ref totalScore, turnScore);//ref used here to make the total score zero
                    count = TurnCount(turnScore, count);
                    turnScore = TurnScore(turnScore);
                    totalScore = totalScore + turnScore;
                    continue;
                }
                else if(choice == "h")
                {
                    count = count + 1;
                    HoldPressed(choice, totalScore, turnScore,count);
                    continue;
                }
                
            }
            Console.WriteLine("Your turn score is " + turnScore + " and your total score is " + totalScore + "\r\nYou Win! You finished in "+count+ " turns \nGame Over");

        }
//--------------------------------------------------------------------------------------------------------------------------
        static int RollDice(int roll)//to generate the random number as dice number
        { 
            Random random = new Random();
             roll= random.Next(1,7);
            //roll = 1;
            return roll;
        }

        static void DiceIsOne(ref int totalScore, int turnScore) //if dice get 1 
        {
            if (turnScore == 1)
            {
                Console.WriteLine("Turn End \n No Points Earned !");
                totalScore = 0; // Reset totalScore to 0
            }
            else
            {
                totalScore = DiceIsNotOne( totalScore, turnScore);// for all other numbers
            }
        }

        static int TurnCount(int turnScore, int count)// for count the turns when rolled number is 1
        {
            if (turnScore == 1)
            {
                count ++; // Increment the count
                Console.WriteLine("TURN - " + count);
            }
            return count;
        }

        static int  DiceIsNotOne(int totalScore, int turnScore)// for all other numbers
        {
            Console.WriteLine("Total Score = " + totalScore);
            Console.WriteLine("Now Turned Score = " + turnScore);
            return totalScore;  
        }
        static int TurnScore(int turnScore)//when dice make score 1 that time turnScore should be 0 to calculate total score
        {
            if (turnScore == 1)
            {
                turnScore = 0;  
            }
            return turnScore;
        }

        static void HoldPressed(string choice, int totalScore, int turnScore,int count)
        {
            if (choice == "h")
                
                Console.WriteLine("Hold !!\n Your Turned Score is :" + turnScore + " your Total Score is : " + totalScore);
                Console.WriteLine("TURN - " + count);
        }

    }

}
