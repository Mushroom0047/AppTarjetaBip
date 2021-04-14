using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Program {
        private static List<Bip> tarjetas = new List<Bip>();


        static void Main(string[] args) {
            //Opciones para la consola
            int opcion = -1;
            int recarga = -1;
            Bip b = new Bip();

            //Console.WriteLine(Utilidades.CalculoValorPasaje());
            //Mostramos el bucle de consulta
            while (opcion != 0) {               
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Bienvenido a Bip");
                //if (tarjetas.Count == 0) {
                //    Console.WriteLine("No dispone de tarjetas \n ¿Desea crear una ahora?");
                //    Console.WriteLine("1: Si \n 2: No");
                //    opcion = int.Parse(Console.ReadLine());
                //    switch (opcion) {
                //        case 1:
                //            Bip nuevaBip = new Bip();
                //            Console.WriteLine("Tarjeta creada correctamente");
                //            break;
                //        case 2:
                //            opcion = 0;
                //            break;
                //    }
                //} else {
                //    Console.WriteLine("Por favor eliga una tarjeta para continuar");
                //    foreach (Bip i in tarjetas) {
                //        Console.WriteLine("Tarjeta: {0} - Id: {1}",i , i.Id);
                //    }
                //}
                Console.WriteLine("Que acción quiere realizar \n");
                Console.WriteLine(" 1: Cosulta saldo \n 2: Recargar \n 3: Pagar pasaje " +
                    "\n 4: Ver id de tarjeta \n 5: Listado de cargas \n 6: Listado de pagos \n 0: Salir");
                try {
                    opcion = int.Parse(Console.ReadLine());
                } catch (System.FormatException) {
                    opcion = -1;
                }
                

                switch (opcion) {
                    case 0:
                        opcion = 0;
                        break;
                    case 1:

                        Console.WriteLine("\n Su saldo es : $" + b.Saldo);                       
                        break;
                    case 2:
                        Console.Write("Ingrese el monto que desea cargar $");
                        try {
                            recarga = int.Parse(Console.ReadLine());
                        }catch (System.FormatException) {
                            recarga = -1;
                        }
                        
                        if (recarga > 0) {
                            if (b.cargar(recarga)) {
                                Console.WriteLine("\n Recarga exitosa, Su nuevo saldo es $" + b.Saldo);
                            } else {
                                Console.WriteLine("Monto ingresado no es valido");
                            }
                        } else {
                            Console.WriteLine("Monto ingresado no valido");
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
