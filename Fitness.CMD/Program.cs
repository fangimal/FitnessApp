using Fitness.BL.Controller;
using Fitness.BL.Model;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");

            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var bithDate = ParseDateTime("дата рождения");
                var weight = PardeDouble("вес");
                var height = PardeDouble("рост");

                userController.SetNewUserData(gender, bithDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Е - ввести приём пищи");
                Console.WriteLine("A - ввести упражнения");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }

            Console.ReadLine();

        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Ввудите название упраженения");
            var name = Console.ReadLine();

            var energy = PardeDouble("расход энергии в минуту");

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("конец упражнения");

            var actuvuty = new Activity(name, energy);
            return (begin, end, actuvuty);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = PardeDouble("калорийность");
            var prot = PardeDouble("белки");
            var fats = PardeDouble("жиры");
            var carbs = PardeDouble("углеводы");

            var weight = PardeDouble("Вес порции");
            var product = new Food(food, calories, prot, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime bithDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out bithDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }

            return bithDate;
        }

        private static double PardeDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }
    }
}