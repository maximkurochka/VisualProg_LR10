using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9
{
    public enum Color
    {
        Unknown,
        Red,
        White,
        Purple,
        Green,
        Grey
    }

    public class Car
    {
        public string mNumber { get; set; }
        public string mModel { get; set; }
        public Color mColor { get; set; }
        public string mFio { get; set; }

        public Car()
        {
            mNumber = "";
            mModel = "";
            mColor = Color.Unknown;
            mFio = "";
        }

        public Car(string number)
        {
            mNumber = number;
            mModel = "";
            mColor = Color.Unknown;
            mFio = "";
        }
    }
}
