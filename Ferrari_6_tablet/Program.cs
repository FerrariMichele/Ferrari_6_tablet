using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferrari_6_tablet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tablet[] tablets = new Tablet[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine("Inserisci marca del tablet {0}", i + 1);
                string marca = Console.ReadLine();
                Console.WriteLine("Inserisci velocità del tablet {0} (in GHz)", i + 1);
                float velocita = float.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci dimensione dello schermo del tablet {0} (in pollici)", i + 1);
                float dimensioneSchermo = float.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci dimensione della batteria del tablet {0} (in mAh)", i + 1);
                int dimensioneBatteria = int.Parse(Console.ReadLine());
                tablets[i] = new Tablet(marca, velocita, dimensioneSchermo, dimensioneBatteria);
            }
            StampaDati(tablets);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Punteggio medio: {0}", PunteggioMedio(tablets));
            Console.WriteLine();
            StampaTabletMigliorePeggiore(tablets);

        }
        public static void StampaDati(Tablet[] tabletas) 
        {
            Console.Clear();
            for (int i = 0; i < tabletas.Length; i++)
            {
                Console.WriteLine("Tablet {0}", i + 1);
                tabletas[i].StampaDati();
                Console.WriteLine();
            }
        }
        public static int PunteggioMedio(Tablet[] tabletas)
        {
            int punteggioMedio = 0;
            for (int i = 0; i < tabletas.Length; i++)
            {
                punteggioMedio += tabletas[i].CalcolaPunteggio();
            }
            return punteggioMedio / tabletas.Length;
        }
        public static void StampaTabletMigliorePeggiore(Tablet[] tabletas) 
        {
            Tuple<int, int> punteggioMigliore = new Tuple<int, int>(0, 0);
            Tuple<int, int> punteggioPeggiore = new Tuple<int, int>(0, 0);
            int franco;
            for (int i = 0; i < tabletas.Length; i++)
            {
                franco = tabletas[i].CalcolaPunteggio();
                if (franco > punteggioMigliore.Item2)
                {
                    punteggioMigliore = new Tuple<int, int>(i, franco);
                }
                if (franco < punteggioPeggiore.Item2)
                {
                    punteggioPeggiore = new Tuple<int, int>(i, franco);
                }
            }
            Console.WriteLine("Il tablet migliore è il tablet {0}", punteggioMigliore.Item1);
            tabletas[punteggioMigliore.Item1].StampaDati();
            Console.WriteLine();
            Console.WriteLine("Il tablet peggiore è il tablet {0}", punteggioPeggiore.Item1);
            tabletas[punteggioPeggiore.Item1].StampaDati();
        }
    }
    public class Tablet
    {
        private string _manufacturer;
        private float _speed;
        private float _screenSize;
        private int _batterySize;

        public Tablet()
        {
            _manufacturer = String.Empty;
            _speed = 0.0f;
            _screenSize = 0.0f;
            _batterySize = 0;
        }
        public Tablet(string manufacturer, float speed, float screenSize, int batterySize)
        {
            _manufacturer = manufacturer;
            _speed = speed;
            _screenSize = screenSize;
            _batterySize = batterySize;
        }
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public float ScreenSize
        {
            get { return _screenSize; }
            set { _screenSize = value; }
        }
        public int BatterySize
        {
            get { return _batterySize; }
            set { _batterySize = value; }
        }
        public void StampaDati()
        {
            Console.WriteLine("Manufacturer: {0}", _manufacturer);
            Console.WriteLine("Speed: {0}", _speed);
            Console.WriteLine("ScreenSize: {0}", _screenSize);
            Console.WriteLine("BatterySize: {0}", _batterySize);
            Console.WriteLine("Punteggio: {0}", CalcolaPunteggio());
        }
        public int CalcolaPunteggio()
        {        
            return (int)Speed * 10 + (int)ScreenSize + (int)(BatterySize/1000);
        }
    }
}
