using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SummerCampDz1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            float health = 20;
            float DMG = 7;
            float arrmor = 30;

            float DefeatProcentDamage(float dmg)
            {
                float firstSum = DMG / arrmor;
                float newDMG = DMG - firstSum;
                dmg = newDMG;
                return dmg;
            }

            float BuffDamage(float buff)
            {
                buff = (DefeatProcentDamage(DMG) / 2) + DefeatProcentDamage(DMG);
                return buff;

            }

            void BerserkGutsMode()
            {
                Random range = new Random();
                int indexRan = range.Next(0, 6);
                float newArrmor = arrmor;
                if (indexRan == 3)
                {
                    Console.WriteLine("BerserkMode - активен");
                    arrmor = arrmor * 0.2f;
                    DMG = DefeatProcentDamage(DMG) * 2;
                }

            }

            Console.WriteLine("Выберите класс: \n1 - Evil; \n2 - Blessed;\n3 - Netral");
            string tryChosenClass = Console.ReadLine();
            int chosenClass;
            if (int.TryParse(tryChosenClass, out int result) == false || result <= 0 || result >= 4)
            {
                Console.WriteLine("Теперь вы Netral");
                result = 3;
                chosenClass = result;
            }
            else
            {
                chosenClass = Convert.ToInt32(tryChosenClass);
            }

            Console.WriteLine("Выберете кого бить: \n1 - Evil; \n2 - Blessed;\n3 - Netral");
            string tryChosenEnemy = Console.ReadLine();
            int chosenEnemy;
            if (int.TryParse(tryChosenClass, out int test) == false || test <= 0 || test >= 4)
            {
                Console.WriteLine("Теперь бьёшь Netral");
                test = 3;
                chosenEnemy = test;
            }
            else
            {
                chosenEnemy = Convert.ToInt32(tryChosenEnemy);
            }

            do
            {
                if (chosenClass == chosenEnemy && chosenClass != 3)
                {
                    
                    Blessed();
                }
                else if (chosenClass == 1 && chosenEnemy == 2)
                {
                    
                    Evil();
                }
                else if (chosenClass == 2 && chosenEnemy == 1)
                {
                    
                    Evil();
                }
                else if (chosenEnemy == 3 || chosenEnemy == 2 || chosenEnemy == 1)
                {
                    
                    Netral();
                }
                else
                {
                    Console.WriteLine("нет");
                }
                
            } while (health >= 0f);

            Console.WriteLine("у тебя здоровье " + health);

            void Evil()
            {
                BerserkGutsMode();
                health -= BuffDamage(DMG);
                Console.WriteLine($"Вы нанесли {BuffDamage(DMG).ToString("00.00", CultureInfo.InvariantCulture)} урона," +
                    $" здоровье врага {health.ToString("00.00", CultureInfo.InvariantCulture)}");
            }

            void Blessed()
            {
                BerserkGutsMode();
                float temporarily = DefeatProcentDamage(DMG) / 2;
                health -= temporarily;
                Console.WriteLine($"Вы нанесли {temporarily.ToString("00.00", CultureInfo.InvariantCulture)} урона," +
                    $" здоровье врага {health.ToString("00.00", CultureInfo.InvariantCulture)}");
            }

            void Netral()
            {
                BerserkGutsMode();
                health -= DefeatProcentDamage(DMG);
                Console.WriteLine($"Вы нанесли {DefeatProcentDamage(DMG).ToString("00.00", CultureInfo.InvariantCulture)} урона," +
                    $" здоровье врага {health.ToString("00.00", CultureInfo.InvariantCulture)}");
            }

        }

    }
}
