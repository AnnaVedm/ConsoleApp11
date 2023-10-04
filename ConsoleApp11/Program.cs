using System;
using System.ComponentModel.Design;

namespace Классы_Анютка
{
    class Program
    {
        static void Main(string[] args)
        {
            Avto[] cars = new Avto[5];
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Avto();
                cars[i].Info();
                Console.Clear();
                cars[i].output();
                cars[i].ezda();
                cars[i].Avaria();
            }

            for (int i = 0; i < cars.Length; i++) //Вывод каждой машинки
            {
                Console.WriteLine($"Машина {i + 1}");
                cars[i].output();

                Console.WriteLine();
            }

            //Avto car = new Avto();
            //car.Info();
            //car.output();
            //car.ezda();

        }
    }
    class Avto
    {
        private string car_number;
        private float benzin_bak;
        private float rashod;
        private float s;
        private float v;
        private float probeg;
        private float probeg1;

        public void Info() //заполнение информации о машине
        {
            Console.Write("Введите номер машины: ");
            car_number = Console.ReadLine();

            Console.Write("Введите объем бака: ");
            benzin_bak = Convert.ToSingle(Console.ReadLine());

            Console.Write("Введите расход бака: ");
            rashod = Convert.ToSingle(Console.ReadLine());

            Console.Write("Введите пробег: ");
            probeg = Convert.ToSingle(Console.ReadLine());  

            Random rnd = new Random();
            s = rnd.Next(1, 3000);
            v = rnd.Next(10, 300);
        }
        public void output() //вывод информации о машине
        {
            Console.WriteLine("ИНФОРМАЦИЯ О МАШИНЕ: ");
            Console.WriteLine($"Номер машины: {car_number}\nОбъем бака: {benzin_bak}\nРасход бака: {rashod}");
            Console.WriteLine($"Ваше расстояние : {s} км");
            Console.WriteLine($"Ваша скорость : {v} км/ч");
            Console.WriteLine($"Ваш пробег :{probeg}");
            probeg_s();
            Console.ReadKey();
        }
        public void ezda()
        {
            float kilometers_quantity = ((benzin_bak / rashod)) * 100; //Кол-во км, которое можно проехать
            float necessary_add_in_a_bak = (s * rashod) / 100 - benzin_bak;
            float ostatok = (s * rashod) / 100; //сколько останется после поездки

            if (kilometers_quantity > s) //Формула проверки хватит ли бензина на поездку
            {
                Console.WriteLine($"\nПри объеме бака в {benzin_bak} литров, вы сможете проехать {kilometers_quantity} км");
                Console.WriteLine($"\nПо окончании поездки в баке останется {benzin_bak - ostatok}");

                Console.WriteLine("\nВы можете ускориться или притормозить. Сделайте свой выбор");
                Console.WriteLine("1. Разогнаться \n2. Притормозить");

                int user_choise = Convert.ToInt32(Console.ReadLine());
                if (user_choise == 1)
                {
                    gaz();

                }
                else
                {
                    tormoz();
                }
                Console.ReadKey();
            }
            else
            {
                zapravka_car(kilometers_quantity, necessary_add_in_a_bak);
            }

        }

        public void tormoz()
        {
            Random rnd = new Random();
            v -= rnd.Next(5, 20); //рандомная скорость

            Console.WriteLine($"\nВаша скорость уменьшилась, теперь она = {v} км/ч. Вы медленнее!");
        }

        public void gaz()
        {
            Random rnd = new Random();
            v += rnd.Next(5, 20); //рандомная скорость

            Console.WriteLine($"\nВаша скорость увеличилась, теперь она = {v} км/ч. Вы едете быстрее ветра!");
        }

        public void zapravka_car(float proehat_mozhno, float zalivka)
        {
            Console.WriteLine($"\nПри объеме бака в {benzin_bak} литров, вы сможете проехать {proehat_mozhno} км");
            Console.WriteLine($"\nЧтобы проехать {s} км, вам нужно дополнительно залить в бак {zalivka} литров");

            zapravka();

            Console.WriteLine($"В вашем баке теперь {benzin_bak}");

            ezda();
        }
        public void zapravka()
        {
            Console.WriteLine("\nВведите количество бензина, которое нужно залить:");
            float zalit_benzin = Convert.ToInt32(Console.ReadLine());
            benzin_bak += zalit_benzin;
        }
        private void koordinat()
        {

        }
        public void probeg_s()
        {
            probeg1 = probeg + s; // Расчёт общего пробега с учётом пройденного расстояния
            Console.WriteLine($"Ваш общий пробег после поездки :{probeg1}");
        }
        public void Avaria()
        {
            Random rand = new Random();
            float i = rand.Next(1, 5);
            float j = rand.Next(1, 5);
            if (i != j)
            {
                Console.WriteLine($"\nМашины {i},{j} попали в аварию!");
            }
        }
    }
}
