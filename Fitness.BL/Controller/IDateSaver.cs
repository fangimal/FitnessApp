using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public interface IDateSaver
    {
        void Save(string fileName, object item);

        T Load<T>(string fileName);
    }
}
