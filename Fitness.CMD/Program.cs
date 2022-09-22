using Fitness.BL.Controller;
using Fitness.BL.Model;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var bithDate = ParseDateTime();
                var weight = PardeDouble("вес");
                var height = PardeDouble("рост");

                userController.SetNewUserData(gender, bithDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - ввести приём пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();

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

        private static DateTime ParseDateTime()
        {
            DateTime bithDate;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out bithDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты");
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