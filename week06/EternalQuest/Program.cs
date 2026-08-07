/*
  EXCEEDING REQUIREMENTS REPORT:
  1. Added a dynamic Level and Rank RPG gamification system inside GoalManager 
     calculated dynamically based on total score (Leveling up every 500 points with titles).
  2. Implemented active completion status tracking and custom status badges on player info displays.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}