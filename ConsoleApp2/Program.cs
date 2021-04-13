using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Program {
        static void Main(string[] args) {
            //Creamos un par de tarjetas          
            Bip b = new Bip();

            //Opciones para la consola
            int opcion = -1;
            int recarga = -1;
            
            //Console.WriteLine(Utilidades.CalculoValorPasaje());
            //Mostramos el bucle de consulta
            while (opcion != 0) {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Bienvenido a Bip");
                Console.WriteLine("Que acción quiere realizar \n");
                Console.WriteLine(" 1: Cosulta saldo \n 2: Recargar \n 3: Pagar pasaje " +
                    "\n 4: Ver id de tarjeta \n 5: Listado de cargas \n 6: Listado de pagos \n 0: Salir");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion) {
                    case 0:
                        opcion = 0;
                        break;
                    case 1:

                        Console.WriteLine("\n Su saldo es : $" + b.Saldo);                       
                        break;
                    case 2:
                        Console.Write("Ingrese el monto que desea cargar $");
                        recarga = int.Parse(Console.ReadLine());

                        if (recarga != -1) {
                            if (b.cargar(recarga)) {
                                Console.WriteLine("\n Recarga exitosa, Su nuevo saldo es $" + b.Saldo);
                            } else {
                                Console.WriteLine("Monto ingresado no es valido");
                            }
                        }
                        break;
                    case 3:
                        if (b.pagar()) {
                            Console.WriteLine("\n Pago realizado correctamente");
                        } else {
                            Console.WriteLine("\n No tiene saldo suficiente");
                        }
                        break;
                    case 4:
                        Console.WriteLine("\n Su ID es :" + b.Id);                       
                        break;
                    case 5:
                        Console.WriteLine("Cargas realizadas");
                        Console.WriteLine(".......................................");
                        foreach (String element in b.Cargas) {                            
                            Console.WriteLine(element);
                        }                        
                        break;
                    case 6:
                        Console.WriteLine("Pagos realizados");
                        Console.WriteLine(".......................................");
                        b.MostrarPagos();
                        break;
                    default:
                        Console.WriteLine("\n Ingrese una opción valida");
                        break;
                }
            }
        }
    }
}
