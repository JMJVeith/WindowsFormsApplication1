using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealmWarsModel;

namespace RealmWarsModel
{
    public interface View<T>
    {
        void print(T msg);
    }
}
