using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest2_3
{
   public abstract class VideoGame
    {
        private string title;
        private string developer;

        public string GameInfo
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public abstract void Install();
        public abstract void Delete();
        public virtual void Rage()
        {
            Console.WriteLine("Dang it! I hate this game!");
        }
    }

    public interface ISinglePlayer
    {
        void Start();
        void Play();
        void Finish();
    }

    public interface IMultiPlayer
    {
        void Start();
        void Play();
        void Grind();
        void PlayCompetitive();
        void GiveUp();
    }

    public class SinglePlayerRpg : VideoGame, ISinglePlayer
    {
        public void Start()
        {
            Console.WriteLine("I can't wait to start this adventure!");
        }
        public void Play()
        {
            Console.WriteLine("Ok time to complete this quest");
        }
        public void Finish()
        {
            Console.WriteLine("Wow! I'm finished already!");
        }
        public override void Install()
        {
            Console.WriteLine("Come on hurry up and install!");
        }
        public override void Delete()
        {
            Console.WriteLine("I'm gonna miss this RPG!");
        }
        public override void Rage()
        {
            Console.WriteLine("Ugh! Who designed this RPG!?");
        }

    }
    public class MultiplayerShooter : VideoGame, IMultiPlayer
    {
        public void Start()
        {
            Console.WriteLine("Ok it's time to raise this k/d");
        }
        public void Play()
        {
            int phrasePicker;

            Random rand = new Random();

            phrasePicker = rand.Next(0, 2);

            switch(phrasePicker)
            {
                case 0:
                    Console.WriteLine("Let's play some Team Deathmatch");
                    break;
                case 1:
                    Console.WriteLine("I'm gonna win this Free For All");
                    break;
                case 2:
                    Console.WriteLine("Alright I'm gonna 1v1 this fool");
                    break;
            }

        }
        public void Grind()
        {
            Console.WriteLine("I need to grind for this new item");
        }
        public void PlayCompetitive()
        {
            Console.WriteLine("I need that shiny medal next to my name!");
        }
        public void GiveUp()
        {
            Console.WriteLine("Looks like I've exhausted all of the content. Time to play something else!");
        }
        public override void Install()
        {
            Console.WriteLine("100 GB!!! This is taking my whole console memory");
        }
        public override void Delete()
        {
            Console.WriteLine("My console memory is thanking me for this!");
        }
        public override void Rage()
        {
            Console.WriteLine("This is exactly why I don't play multiplayer games!");
        }
    }

    public class QuestionClass
    {
        public static ISinglePlayer singlePlayer;
        public static IMultiPlayer multiPlayer;

        public static MultiplayerShooter shooter;
        public static SinglePlayerRpg rpg;
        public static void Main()
        {
            MultiplayerShooter callOfDuty = new MultiplayerShooter();
            SinglePlayerRpg baldursGate3 = new SinglePlayerRpg();

            PlayGame(callOfDuty);
            PlayGame(baldursGate3);
        }

        static void PlayGame(object obj)
        {
            if (obj is MultiplayerShooter)
            {
                shooter = (MultiplayerShooter)obj;
                multiPlayer = (IMultiPlayer)obj;

                shooter.Install();
                multiPlayer.Start();
                multiPlayer.Play();
                multiPlayer.Grind();
                multiPlayer.PlayCompetitive();
                multiPlayer.GiveUp();
                shooter.Delete();
            }
            if (obj is SinglePlayerRpg)
            {
                rpg = (SinglePlayerRpg)obj;
                singlePlayer = (ISinglePlayer)obj;

                rpg.Install();
                singlePlayer.Start();
                singlePlayer.Play();
                singlePlayer.Finish();
                rpg.Delete();
            }
        }
    }

}
