using Fitness.BL.Model;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>

        public UserController(string userName, string genderName, DateTime birtdthDay, double weigt, double height)
        {
            //Todo: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birtdthDay, weigt, height);

        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // Todo: что делать если пользователя не прочитали?
            }
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>

        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

    }
}
