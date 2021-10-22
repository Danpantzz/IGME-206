using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_2___Question_4_7
{
    //Class: Program
    //Purpose: Makes use of other classes
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Author: Daniel McErlean
        //Purpose: create objects and pass them to UsePhone method
        //Restrictions: None
        static void Main(string[] args)
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            UsePhone(tardis);
            UsePhone(phoneBooth);

        }

        //Method: UsePhone
        //Purpose: Call objects methods from the interface and based off of whether it is a tardis or phonebooth
        //Restrictions: None
        static void UsePhone(object obj)
        {
            PhoneInterface phoneInterface = null;
            phoneInterface = (PhoneInterface)obj;

            phoneInterface.MakeCall();
            phoneInterface.HangUp();

            if (obj.GetType() == typeof(Tardis))
            {
                Tardis tardis = null;
                tardis = (Tardis)obj;
                tardis.TimeTravel();
            }
            else if (obj.GetType() == typeof(PhoneBooth))
            {
                PhoneBooth phoneBooth = null;
                phoneBooth = (PhoneBooth)obj;
                phoneBooth.OpenDoor();
            }

        }
    }

    //Abstract Class: Phone
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }

        public abstract void Connect();
        public abstract void Disconnect();
    }

    //Interface: PhoneInterface
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    //Class: RotoryPhone
    public class RotoryPhone : Phone, PhoneInterface
    {
        public void Answer() { }
        public void MakeCall() { }
        public void HangUp() { }
        public override void Connect() { }
        public override void Disconnect() { }
    }

    //Class: PushButtonPhone
    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer() { }
        public void MakeCall() { }
        public void HangUp() { }
        public override void Connect() { }
        public override void Disconnect() { }
    }

    //Class: Tardis
    public class Tardis : RotoryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        public byte WhichDrWho
        {
            get
            {
                if (this.whichDrWho == 10)
                {
                    return this.whichDrWho;
                }
                else if (this.whichDrWho > WhichDrWho)
                {
                    return this.whichDrWho;
                }
                else
                {
                    return WhichDrWho;
                }
            }
        }

        public string FemaleSideKick
        {
            get
            {
                return this.femaleSideKick;
            }
        }

        public void TimeTravel() { }
    }

    //Class: PhoneBooth
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor() { }
        public void CloseDoor() { }
    }
}