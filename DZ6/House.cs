namespace DZ6
{
    public class House
    {
        private static int _houseNumber = 0;
        private int _buildNumber;
        private short _height;        //Самое высокое здание 828 м
        private byte _floors;       //Наибольшее количество этажей 163
        private short _flats;
        private byte _entrances;
        
        public House(short height, byte floors, short flats, byte entrances)
        {
            _buildNumber = ++_houseNumber;

            Height = height;
            Floors = floors;
            Flats = flats;
            Entrances = entrances;
        }

        public short Height
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Высота здания не может быть отрицательной");
                _height = value;
            }
        }

        public byte Floors
        {
            get { return _floors; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество этажей не может быть отрицательным");
                _floors = value;
            }
        }

        public short Flats
        {
            get { return _flats; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество квартир не может быть отрицательным");
                _flats = value;
            }
        }

        public byte Entrances
        {
            get { return _entrances; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество подъездов не может быть отрицательным");
                _entrances = value;
            }
        }

        /// <summary>
        /// Выводит информацию 
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Номер здания: {_buildNumber}, Высота здания: {_height}, Количество этажей: {_floors}, Количество квартир: {_flats}, Количество подъездов: {_entrances}" +
                $" Высота этажа: {FloorHeight()}, Количество квартир в подъезде: {FlatInEntrancesCount()}, Количество квартир на этаже: {FlatInFloorCount()}"); 
        }

        /// <summary>
        /// Вычисляет высоту одного этажа.
        /// </summary>
        public double FloorHeight()
        {
            double floorHeight = (double)_height / _floors;
            return floorHeight;
        }

        /// <summary>
        /// Вычисляет среднее количество квартир в одном подъезде.
        /// </summary>
        public double FlatInEntrancesCount()
        {
            return (double)_flats / _entrances;         
        }

        /// <summary>
        /// Вычисляет среднее количество квартир на одном этаже.
        /// </summary>
        public double FlatInFloorCount()
        {
            return (double)_flats / _entrances / _floors;
        }
    }
}