using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest2_2
{
    //Unit Test 2: Questions 4 - 7
    //Author: Naim Sabir
    public abstract class Phone
    {
        //Fields:
        private string phoneNumber;
        public string address;

        //Properties:
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {

            }
        }

        //Methods:
        public abstract void Connect();

        public abstract void Disconnect();

    }

    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    public class RotaryPhone : Phone, PhoneInterface
    {
        //Methods:
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }
        public override void Connect()
        {

        }
        public override void Disconnect()
        {

        }
    }
    
    public class PushButtonPhone: Phone, PhoneInterface
    {
        //Methods:
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }
        public override void Connect()
        {

        }
        public override void Disconnect()
        {

        }
    }

    public class Tardis : RotaryPhone
    {
        //Fields:
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;

        public double exteriorSurfaceArea;
        public double interiorVolume;

        //Properties:
        public byte WhichDrWho
        {
            get
            {
                return whichDrWho;
            }
        }
        public string FemaleSideKick
        {
            get
            {
                return femaleSideKick;
            }
        }

        //Methods:
        public void TimeTravel()
        {

        }

        //Operator Overloads:

        public static bool operator < (Tardis t1, Tardis t2)
        {
            if(t1.whichDrWho != 10 && t2.whichDrWho != 10)
            {
                return (t1.whichDrWho < t2.whichDrWho);
            }
            else if(t1.whichDrWho == 10 && t2.whichDrWho != 10)
            {
                return (false);
            }
            else if(t1.whichDrWho != 10 && t2.whichDrWho ==10)
            {
                return (true);
            }
            else if (t1.whichDrWho == 10 && t2.whichDrWho == 10)
            {
                return (false);
            }

            return (t1.whichDrWho < t2.whichDrWho);
        }
        public static bool operator > (Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho != 10 && t2.whichDrWho != 10)
            {
                return (t1.whichDrWho > t2.whichDrWho);
            }
            else if (t1.whichDrWho == 10 && t2.whichDrWho != 10)
            {
                return (true);
            }
            else if (t1.whichDrWho != 10 && t2.whichDrWho == 10)
            {
                return (false);
            }
            else if (t1.whichDrWho == 10 && t2.whichDrWho == 10)
            {
                return (false);
            }

            return (t1.whichDrWho > t2.whichDrWho);

        }
        public static bool operator == (Tardis t1, Tardis t2)
        {
            return (t1.whichDrWho == t2.whichDrWho);

        }
        public static bool operator != (Tardis t1, Tardis t2)
        {
            return (t1.whichDrWho != t2.whichDrWho);

        }
        public static bool operator <= (Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho != 10 && t2.whichDrWho != 10)
            {
                return (t1.whichDrWho <= t2.whichDrWho);
            }
            else if (t1.whichDrWho == 10 && t2.whichDrWho != 10)
            {
                return (false);
            }
            else if (t1.whichDrWho != 10 && t2.whichDrWho == 10)
            {
                return (true);
            }
            else if (t1.whichDrWho == 10 && t2.whichDrWho == 10)
            {
                return (true);
            }
            return (t1.whichDrWho <= t2.whichDrWho);
        }
        public static bool operator >= (Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho != 10 && t2.whichDrWho != 10)
            {
                return (t1.whichDrWho >= t2.whichDrWho);
            }
            else if (t1.whichDrWho == 10 && t2.whichDrWho != 10)
            {
                return (true);
            }
            else if (t1.whichDrWho != 10 && t2.whichDrWho == 10)
            {
                return (false);
            }
            else if (t1.whichDrWho == 10 && t2.whichDrWho ==10)
            {
                return (true);
            }
            return (t1.whichDrWho >= t2.whichDrWho);
        }

    }

    public class PhoneBooth : PushButtonPhone
    {
        //Fields:
        private bool superMan;

        public double costPerCall;
        public bool phoneBook;

        //Methods:
        public void OpenDoor()
        {

        }
        
        public void CloseDoor()
        {

        }
    }

    public class UsePhoneClass
    {
        static void UsePhone(object obj)
        {
            PhoneInterface phoneInterface;
            phoneInterface = (PhoneInterface)obj;

            phoneInterface.MakeCall();

            phoneInterface.HangUp();

            if(obj is Tardis)
            {
                Tardis tardisObj;
                tardisObj = (Tardis)obj;

                tardisObj.TimeTravel();
            }
            if (obj is PhoneBooth)
            {
                PhoneBooth phoneBoothObj;
                phoneBoothObj = (PhoneBooth)obj;

                phoneBoothObj.OpenDoor();
            }
        }

        static void Main()
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            UsePhone(tardis);
            UsePhone(phoneBooth);
        }
    }
}
