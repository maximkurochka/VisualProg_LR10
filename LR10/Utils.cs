using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LR9
{
    class Utils
    {
        public static List<char> mBadSymbols = new List<char>()
        { 
            ';', ',', '.', '!', '@', '#', '$',
            '%', '^', '&', '*', '(', ')', '-', 
            '_', '/', '\\', '>', '<', ':', '?', 
            '[', ']', '{', '}'
        };

        public static string ConvertColorToString(Color color)
        {
            switch (color)
            {
                case Color.White:
                    return "Белый";

                case Color.Red:
                    return "Красный";

                case Color.Purple:
                    return "Фиолетовый";

                case Color.Green:
                    return "Зеленый";

                case Color.Grey:
                    return "Серый";

                case Color.Unknown:
                default:
                    return "Неопознанный";
            }
        }

        public static Color ConvertStringToColor(string colorStr)
        {
            if (colorStr.Equals("Белый"))
            {
                return Color.White;
            }
            else if (colorStr.Equals("Красный"))
            {
                return Color.Red;
            }
            else if (colorStr.Equals("Фиолетовый"))
            {
                return Color.Purple;
            }
            else if (colorStr.Equals("Зеленый"))
            {
                return Color.Green;
            }
            else if (colorStr.Equals("Серый"))
            {
                return Color.Grey;
            }
            return Color.Unknown;
        }

        public static bool IsNumberValid(string number)
        {
            if(number.Length == 0)
            {
                return false;
            }

            foreach(var a in mBadSymbols)
            {
                if (number.Contains(a))
                {
                    return false;
                }
            }
            return true;
        }

        public static void SerializeList<ObjectType>(List<ObjectType> list, string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                list.ForEach(elem => formatter.Serialize(fileStream, elem));
            }
        }

        public static bool DeserializeList<ObjectType>(List<ObjectType> list, string filePath)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    while (fileStream.Position < fileStream.Length)
                    {
                        list.Add((ObjectType)formatter.Deserialize(fileStream));
                    }
                }
            }
            catch (IOException ex)
            {
                return false;
            }
            return true;
        }
    }
}
