using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crash_TestFile
{
    //Pseudo-Code
    //Intro: You're making your first game. YESS!!!!!!!!!!!!
    //I have no idea what i'm doing but this is to lay out the steps of what I need done (and adjust as I realize I need more
    //1. Need a player movement system that makes the player move forward continuously and allowing them to jump
    //and maneuver in the air.
    //2. Need obstacles that come at the player from the direction they are running
    //3. Need powerups to influence the game
    //4. Need multiple gameObjects for sound effects etc
    //5. A level system and a scoring system
    //6. A start screen and an end screen allowing you to restart the game. No checkpoint system because I have no idea how the fuck to do that.
    //7. An infinitely repeating stage. Gonna definetly need to do some research for this one because I have no idea how I would even do that.
    //8. The camera would need to follow the player at all points in time so I'd need to create a focal point.
    //9. Generally things that involve the movement of things in the game space should not be in the dll file.
    //10. Can handle procedural map generation here

    //A class dedicated to keeping score, and incrementing the score using a method call ScoreUp 
    //that can be called in other scripts. Can potentially also make a decrementer if I get far
    //enough in my design
    public class EnemyGenerator
    {
        object enemy1;
        object enemy2;
        object enemy3;
        public int randomNum;
        Random rand = new Random();
        public EnemyGenerator()
        {
            randomNum = rand.Next(0, 2);

            if(randomNum == 0)
            {
                SpawnEnemy(enemy1);
            }
            if (randomNum == 1)
            {
                SpawnEnemy(enemy2);
            }
            if (randomNum == 2)
            {
                SpawnEnemy(enemy3);
            }
        }

        public void SpawnEnemy(object enemy)
        {
            //I don't know how I would represent the unity logic to spawn an enemy so this will be empty
        }

    }
    //public class PlayerMovement
    //{
    //    //speed that increments based on whether the player is holding down the right arrow key/ d key
    //    public int speed;
    //    //if no key is being pressed have the player move slowly to the right
    //    //if the right arrow or the d key is pressed have the player move faster to the right.
    //}
    public class ScoreController
    {
        //start the score at 0
        public int score = 0;

        //in case I need to manually set the score at some point in time
        public void SetScore(int newScore)
        {
            score = newScore;
        }
        public int GetScore()
        {
            return score;
        }
        public void ScoreUp()
        {
            //can potentially add logic to increase the score by different amounts if it's called for
            //score increases by 100
            score += 100;
        }

    }
    public class LevelController : ScoreController
    {
        ScoreController scoreController = new ScoreController();
        //start at level 1
        public int currentLevel = 1;

        public void NextLevel()
        {
            //I know this method can go without the if statement but I'm keeping it here so I know what to do later on
            if(scoreController.GetScore() == 1000)
            {
                currentLevel++;
            }
        }

    }
    public class Class1
    {
    }
}
