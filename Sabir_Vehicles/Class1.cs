using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_Vehicles
{
    public abstract class Vehicle
    {
        public virtual void LoadPassenger()
        {

        }
    }

    public abstract class Car : Vehicle
    {
        public void Compact()
        {

        }
        public void SUV()
        {

        }
        public void Pickup()
        {

        }
    }

    public abstract class Train : Vehicle
    {
        public void PassengerTrain()
        {

        }
        public void FreightTrain()
        {

        }
        public void _424DoubleBogey()
        {

        }
    }
    public interface IPassengerCarrier
    {
        void LoadPassenger();
        
    }
    public interface IHeavyLoadCarrier
    {

    }

    public class Compact : IPassengerCarrier
    {
        public void LoadPassenger()
        {

        }
    }
    public class SUV : IPassengerCarrier
    {
        public void LoadPassenger()
        {

        }
    }
    public class Pickup : IPassengerCarrier, IHeavyLoadCarrier 
    {
        public void LoadPassenger()
        {

        }
    }
    public class PassengerTrain : IPassengerCarrier
    {
        public void LoadPassenger()
        {

        }
    }
    public class FreightTrain : IHeavyLoadCarrier
    {
       
    }
    public class _424DoubleBogey : IHeavyLoadCarrier
    {

    }


    public class Class1
    {
    }
}
