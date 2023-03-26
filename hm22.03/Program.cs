using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hm22._03
{
    interface Herbivore
    {
        void EatGrass();
    }
    class Wildebeest : Herbivore
    {
        public int weight;
        public bool life;

        public Wildebeest() { }
        public Wildebeest(int weight, bool life)
        {
            this.weight = weight;
            this.life = life;
        }
        public void EatGrass()
        {
            Console.WriteLine("Grass has been ate");
            weight += 10;
        }
    }
    class Bison : Herbivore
    {
        public int weight;
        public bool life;

        public Bison() { }
        public Bison(int weight, bool life)
        {
            this.weight = weight;
            this.life = life;
        }
        public void EatGrass()
        {
            Console.WriteLine("Grass has been ate");
            weight += 10;
        }
    }

    interface Carnivore
    {
        void EatHerbivore();
    }
    class Lion : Carnivore
    {
        public int power;
        public Herbivore h;

        public Lion() { }
        public Lion(int power)
        {
            this.power = power;
        }
        public void EatHerbivore()
        {
            int weight = new Bison().weight;
            if (power > weight)
            {
                power += 10;
            }
            else { power -= 10; }
            Console.WriteLine("Lion ate");
        }
    }
    class Wolf : Carnivore
    {
        public int power;

        public Wolf() { }
        public Wolf(int power)
        {
            this.power = power;
        }
        public void EatHerbivore()
        {
            int weight = new Wildebeest().weight;
            if (power > weight)
            {
                power += 10;
            }
            else { power -= 10; }
            Console.WriteLine("Wolf ate");
        }
    }

    interface Continent
    {
        Herbivore CreateHerbivore();
        Carnivore CreateCarnivore();
    }
    class Africa : Continent
    {
        public Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }
    class NorthAmerika : Continent
    {
        public Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    class AnimalWord
    {
        public Herbivore h;
        public Carnivore c;

        public AnimalWord(Continent continent)
        {
            h = continent.CreateHerbivore();
            c = continent.CreateCarnivore();
        }
        public void MealsHerbivores()
        {
            h.EatGrass();
        }
        public void NutritionCarnivores()
        {
            c.EatHerbivore();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Continent africa = new Africa();
            AnimalWord aw = new AnimalWord(africa);
            aw.NutritionCarnivores();
            aw.MealsHerbivores();

            Console.WriteLine();

            Continent nortamerika = new NorthAmerika();
            AnimalWord aw2 = new AnimalWord(nortamerika);
            aw2.NutritionCarnivores();
            aw2.MealsHerbivores();
        }
    }
}