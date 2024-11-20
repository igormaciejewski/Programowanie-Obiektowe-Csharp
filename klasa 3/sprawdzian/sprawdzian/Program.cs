using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprawdzian
{
    internal class Program
    {
        public interface IAnimal
        {
            void MakeSound();
            void Eat();
        }

        public abstract class Animal : IAnimal
        {
            public string Name { get; set; }
            public string Species { get; set; }
            public int Age { get; set; }
            public string Owner { get; set; }
            protected Animal(string name, string species, int age, string owner)
            {
                Name = name;
                Species = species;
                Age = age;
                Owner = owner;
            }
            public void Eat()
            {
                Console.WriteLine($"{Name} je.");
            }
            public abstract void MakeSound();
        }

        public class Dog : Animal
        {
            public Dog(string name, int age, string owner) : base(name, "Dog", age, owner)
            {

            }
            public override void MakeSound()
            {
                Console.WriteLine("Hau!");
            }
        }

        public class Cat : Animal
        {
            public Cat(string name, int age, string owner) : base(name, "Cat", age, owner)
            {

            }

            public override void MakeSound()
            {
                Console.WriteLine("Miau!");
            }
        }
        static void Main(string[] args)
        {
            Dog dog1 = new Dog("Azor", 5, "Jan Kowalski");
            Dog dog2 = new Dog("Topi", 7, "Igor Maciejewski");
            Cat cat1 = new Cat("Filemon", 3, "Anna Nowak");
            Cat cat2 = new Cat("Mruczek", 1, "Katarzyna Zielińska");

            dog2.MakeSound();
            dog2.Eat();
            cat1.MakeSound();
            cat1.Eat();

            List<Animal> animals = new List<Animal>();
            animals.Add(dog1);
            animals.Add(dog2);
            animals.Add(cat1);
            animals.Add(cat2);

            foreach (var animal in animals)
            {
                Console.WriteLine($"Imie: {animal.Name} Gatunek: {animal.Species} Wiek: {animal.Age} Lata Właściciel: {animal.Owner}");
                animal.MakeSound();
                animal.Eat();
            }

            bool koniec = true;
            while (koniec!= false)
            {
                Console.WriteLine("1. Sortowanie według właściciela");
                Console.WriteLine("2. Sortowanie według gatunku");
                Console.WriteLine("3. Sortowanie według wieku");
                Console.WriteLine("4. Sortowanie według imienia");
                Console.WriteLine("5. Wyjście");
                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Posortowane Według Właściciela");
                            Console.WriteLine();
                            var Orderbyowner = animals.OrderBy(a => a.Owner);
                            foreach (var animal in Orderbyowner)
                            {
                                Console.WriteLine($"Imie: {animal.Name} Gatunek: {animal.Species} Wiek: {animal.Age} Lata Właściciel: {animal.Owner}");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Posortowane Według Gatunku");
                            Console.WriteLine();
                            var Orderbyspecies = animals.OrderBy(a => a.Species);
                            foreach (var animal in Orderbyspecies)
                            {
                                Console.WriteLine($"Imie: {animal.Name} Gatunek: {animal.Species} Wiek: {animal.Age} Lata Właściciel: {animal.Owner}");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Posortowane Według Wieku");
                            Console.WriteLine();
                            var OrderbyAge = animals.OrderBy(a => a.Age);
                            foreach (var animal in OrderbyAge)
                            {
                                Console.WriteLine($"Imie: {animal.Name} Gatunek: {animal.Species} Wiek: {animal.Age} Lata Właściciel: {animal.Owner}");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Posortowane Według Imienia");
                            Console.WriteLine();
                            var OrderbyName = animals.OrderBy(a => a.Name);
                            foreach (var animal in OrderbyName)
                            {
                                Console.WriteLine($"Imie: {animal.Name} Gatunek: {animal.Species} Wiek: {animal.Age} Lata Właściciel: {animal.Owner}");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Dziękuje za użycie programu");
                            koniec = false;
                            break;
                        }
                }

            }
            
        }
    }
}
