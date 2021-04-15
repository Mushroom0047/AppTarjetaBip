using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Program {

        static void Main(string[] args) {
            //Opciones para la consola
            int opcion = -1;
            int recarga = -1;
            int opcTarjeta = -1;
            int eleccionTarjeta = -1;

            //Tarjeta por defecto
            Bip b = Utilidades.CrearTarjeta();

            //Elegir o crear tarjeta
            while (opcTarjeta != 0) {
                opcion = -1;
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Bienvenido a Bip");
                Console.WriteLine(" 1: Crear tarjeta \n 2: Elegir tarjeta  \n 0:Salir");
                try {
                    opcTarjeta = int.Parse(Console.ReadLine());
                } catch (System.FormatException) {
                    opcTarjeta = -1;
                }

                switch (opcTarjeta) {
                    case 0:
                        opcTarjeta = 0;
                        opcion = 0;
                        break;
                    case 1:
                        b = Utilidades.CrearTarjeta();
                        Console.WriteLine("Tarjeta creada exitosamente");
                        Console.WriteLine("Tarjeta: {0} - Saldo:$ {1}", b.Id, b.Saldo);
                        break;
                    case 2:
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Elija la tarjeta que va a usar \n");
                        Console.WriteLine(Utilidades.ConsultaTarjetas());
                        try {
                            eleccionTarjeta = int.Parse(Console.ReadLine());
                        } catch (System.FormatException) {
                            eleccionTarjeta = -1;
                        }
                        if (eleccionTarjeta > -1 && eleccionTarjeta < Utilidades.ContadorTarjetas) {
                            b = Utilidades.ElegirTarjeta(eleccionTarjeta);
                            opcTarjeta = 0;
                        } else {
                            Console.WriteLine("Valor ingresado no es valido");
                        }
                        break;
                }


                    //Mostramos el bucle de consulta por tarjeta
                    while (opcion != 0) {
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Bienvenido a Bip");

                        Console.WriteLine("Que acción quiere realizar \n");
                        Console.WriteLine(" 1: Cosulta saldo \n 2: Recargar \n 3: Pagar pasaje " +
                            "\n 4: Ver id de tarjeta \n 5: Listado de cargas \n 6: Listado de pagos \n 7: Cambiar tarjeta \n 0: Salir");
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
                                } catch (System.FormatException) {
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
                                    Console.WriteLine("\n Pago realizado correctamente \n Pasaje: ${0}", Utilidades.CalculoValorPasaje());
                                } else {
                                    Console.WriteLine("\n No tiene saldo suficiente \n Saldo: ${0}", b.Saldo);
                                }
                                break;
                            case 4:
                                Console.WriteLine("\n Su ID es :" + b.Id);
                                break;
                            case 5:
                                Console.WriteLine("Cargas realizadas");
                                Console.WriteLine(".......................................");
                                Console.WriteLine("Total: {0}", b.Cargas.Count());
                                foreach (String element in b.Cargas) {
                                    Console.WriteLine(element);
                                }
                                break;
                            case 6:
                                Console.WriteLine("Pagos realizados");
                                Console.WriteLine(".......................................");
                                Console.WriteLine(b.MostrarPagos());
                                break;
                            case 7:
                                opcTarjeta = -1;
                                opcion = 0;
                                break;
                            default:
                                Console.WriteLine("\n Ingrese una opción valida");
                                break;
                        }
                    }
                }
        }//llave del while
    }
}
