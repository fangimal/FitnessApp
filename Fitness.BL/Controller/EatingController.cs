﻿using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));

            Foods = GetAllFoods();

            Eating = GetEating();
        }

        public void Add(Food food, double waight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, waight);
                Save();
            }
            else
            {
                Eating.Add(product, waight);
                Save();
            }
        }
        private Eating? GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        private List<Food>? GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() { Eating });
        }
    }
}
