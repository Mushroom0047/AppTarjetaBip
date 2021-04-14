using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Utilidades {
        //Declaracion de constantes
        private static int[] VALOR_DIA = { 500, 600, 450, 700, 300, 200, 100 };
        private static int[,] VALOR_HORA = { { 6, 9, 100 }, { 9, 18, 250 }, { 18, 22, 50 } };
        private static List<int> ids = new List<int>();
        

        public static int CalculoValorPasaje() {
            int valorPasaje = 0;
            DateTime fechaActual = DateTime.Now;

            //Calcular pasaje segun día
            valorPasaje = (VALOR_DIA[(int)fechaActual.DayOfWeek - 1]);

            //Calcular valor agregado
            int horaActual = fechaActual.Hour;
            //Console.WriteLine("hora actual: {0} - valor pasaje: {1} - valor add: {2}", horaActual, valorPasaje, VALOR_HORA[1, 2]);

            if (horaActual >= VALOR_HORA[0, 0] && horaActual < VALOR_HORA[0, 1]) {
                valorPasaje += VALOR_HORA[0, 2];

            } else if (horaActual > VALOR_HORA[1, 0] && horaActual <= VALOR_HORA[1, 1]) {
                valorPasaje += VALOR_HORA[1, 2];

            } else if (horaActual > VALOR_HORA[2, 0] && horaActual < VALOR_HORA[2, 1]) {
                valorPasaje += VALOR_HORA[2, 2];
            }

            return valorPasaje;
        }


        public static int GenerarId() {
            int idGen = 0;
            Random r = new Random();
            Boolean loop = true;
            do {                
                idGen = r.Next(10000, 99999);
                foreach (int i in ids) {
                    if (i == idGen) {
                        loop = true;
                    } else {
                        ids.Add(idGen);
                        loop = false;                        
                    }
                }
            } while(!loop);
            return idGen;
        }
    }
}
