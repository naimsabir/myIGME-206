using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();

    }

    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GoToVet();
    }

    public abstract class Pet
    {
        private string sName;
        public int nAge;

        public Pet()
        {

        }
        public Pet(string sName, int nAge)
        {
            this.sName = sName;
            this.nAge = nAge;
        }

        public string Name
        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
            }
        }


        public abstract void Eat();

        public abstract void Play();

        public abstract void GoToVet();

    }

    public class Pets
    {
        List<Pet> petList = new List<Pet>();

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public int Count
        {
            get
            {
                return petList.Count;
            }
        }

        public void Add(Pet pet)
        {
            petList.Add(pet);
        }

        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }
        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }

    }

    public class Cat : Pet, ICat
    {
        //Pet.Name can't work because an object reference is required and the only solution I can think of is
        //making a cat object because you can't instatiate an abstract class (meaning there is no pet object I can make)
        //or using this because I think it will use whatever dog is passed into the constructor

        public Cat()
        {

        }
        public override void Eat()
        {
            Console.WriteLine($"{this.Name} is chowing down");
        }

        public override void Play()
        {
            Console.WriteLine($"{this.Name} is chasing that yarn");
        }

        public void Purr()
        {
            Console.WriteLine($"{this.Name} is purring their heart out");
        }

        public void Scratch()
        {
            Console.WriteLine($"{this.Name} is causing some major damage");
        }

        public override void GoToVet()
        {
            Console.WriteLine($"{this.Name} is chilling at the vet");
        }

    }

    public class Dog : Pet, IDog
    {
        public string sLicense;
        //Pet.Name can't work because an object reference is required and the only solution I can think of is
        //making a dog object because you can't instatiate an abstract class (meaning there is no pet object I can make)
        //or using this because I think it will use whatever dog is passed into the constructor


        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            sLicense = szLicense;

        }
        public override void Eat()
        {
            Console.WriteLine($"{this.Name} is chowing down on some dog food");
        }

        public override void Play()
        {
            Console.WriteLine($"{this.Name} is playing fetch");
        }

        public void Bark()
        {
            Console.WriteLine($"{this.Name} is scaring the mail carrier");
        }
        public void NeedWalk()
        {
            Console.WriteLine($"{this.Name} is whimpering for a walk");
        }

        public override void GoToVet()
        {
            Console.WriteLine($"{this.Name} is being a brat at the vets");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //creating reference variable for all the pets and interfaces
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            //creating variables to hold names, license, and age
            string sLicense, sName;
            int nAge = 0;
            int listCall, randomPhrase;

            //creating the list of pets
            Pets pets = new Pets();

            //creating the random number generator
            Random rand = new Random();

            //creating a petList in main. I am really confused as to how this works exactly
            //chapters 8 - 11 are throwing me for a loop and I barely understand them.
            //wait I dont need this I forgot that I have a list of pets
            //List<Pet> petList = new List<Pet>();

            for (int i = 0; i <= 49; i++)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You bought a dog!");

                        //prompt for license number, name, and age
                        Console.WriteLine("Enter the license number: ");
                        sLicense = Console.ReadLine();
                        Console.WriteLine("Enter the dog's name");
                        sName = Console.ReadLine();
                        Console.WriteLine("Enter the dog's age");
                        try
                        {
                            //nAge = Convert.ToInt32(Console.ReadLine());
                            int.TryParse(Console.ReadLine(), out nAge);
                        }
                        catch
                        {
                            Console.WriteLine("Please enter an integer for the dog's age");
                        }

                        // add a dog to the petslist
                        dog = new Dog(sLicense, sName, nAge);
                        thisPet = dog;
                        //petList.Add(thisPet);
                        pets.Add(thisPet);
                        Console.WriteLine($"Dog's name => {sName}\n Age => {nAge}\n License => {sLicense}");

                    }
                    else
                    {
                        Console.WriteLine("You bought a cat!");

                        //prompt for name and age
                        Console.WriteLine("Enter the cat's name");
                        sName = Console.ReadLine();
                        Console.WriteLine("Enter the cat's age");
                        try
                        {
                            //nAge = Convert.ToInt32(Console.ReadLine());
                            int.TryParse(Console.ReadLine(), out nAge);
                        }
                        catch
                        {
                            Console.WriteLine("Please enter an integer for the cat's age");
                        }

                        // else add a cat to the pets list
                        // needs name and age
                        // I don't understand how we are supposed to know the cats name and age if it only has a base constructor
                        cat = new Cat();
                        cat.Name = sName;
                        cat.nAge = nAge;
                        thisPet = cat;
                        //petList.Add(thisPet);
                        pets.Add(thisPet);

                        Console.WriteLine($"Cat's name => {sName}\n Age => {nAge}");

                    }
                }
                else
                {
                    // choose a random pet from pets and choose a random activity for the pet to do
                    //set thispet equal to a random pet from the petlist
                    listCall = rand.Next(0, pets.Count);
                    try
                    {
                        thisPet = pets[listCall];
                        if (thisPet == null)
                        {
                            continue;
                        }
                        else if (thisPet is Dog)
                        {
                            iDog = (IDog)thisPet;
                            randomPhrase = rand.Next(0, 4);

                            switch (randomPhrase)
                            {
                                case 0:
                                    iDog.Eat();
                                    break;
                                case 1:
                                    iDog.Play();
                                    break;
                                case 2:
                                    iDog.Bark();
                                    break;
                                case 3:
                                    iDog.NeedWalk();
                                    break;
                                case 4:
                                    iDog.GoToVet();
                                    break;
                            }

                        }
                        else if (thisPet is Cat)
                        {
                            iCat = (ICat)thisPet;
                            randomPhrase = rand.Next(0, 3);

                            switch (randomPhrase)
                            {
                                case 0:
                                    iCat.Eat();
                                    break;
                                case 1:
                                    iCat.Play();
                                    break;
                                case 2:
                                    iCat.Purr();
                                    break;
                                case 3:
                                    iCat.Scratch();
                                    break;

                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Something went horribly wrong and it is probably my fault");
                    }



                }
            }

        }
    }
}