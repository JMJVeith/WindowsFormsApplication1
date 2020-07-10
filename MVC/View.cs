using System;
using System.Collections.Generic;
using System.Text;

namespace bad
{
    public interface View<T>
    {
        void print(T msg);
    }
}
