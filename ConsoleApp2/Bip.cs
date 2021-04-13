using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Bip {
        private List<String> pagos = new List<String>();

        private List<String> cargas = new List<String>();
            public List<String> Cargas { get { return cargas; } }

        private DateTime creacion;
            public DateTime Creacion { get { return creacion; } }

        private static int idd = 0;
            public int Id { get { return idd; } }

        private int saldo;
        public int Saldo { get { return saldo; } }


        public Boolean cargar(int monto) {
            DateTime fecha = DateTime.Now;
            if (monto > 0) {
                saldo += monto;
                String agregar = "Fecha:"+fecha.ToShortDateString()+" - Monto: $"+monto.ToString();
                cargas.Add(agregar);           
                return true;
            } else {
                return false;
            }            
        }
        public Boolean pagar() {
            if (saldo >= Utilidades.CalculoValorPasaje()) {
                saldo -= Utilidades.CalculoValorPasaje();
                AgregarPagos(Utilidades.CalculoValorPasaje());
                return true;
            } else {
                return false;
            }
        }

        public Bip() {
            idd++;
            creacion = DateTime.Now;
        }

        //Metodo para agregar pagos
        private void AgregarPagos(int pago) {
            DateTime fechaHoy = DateTime.Now;
            String strPago;
            if (pagos.Capacity < 10) {
                strPago = $"Fecha: {fechaHoy.ToShortDateString()}- Hora: {fechaHoy.ToShortTimeString()} - Pago: ${pago}";
                pagos.Add(strPago);
            } else {
                strPago = $"Fecha: {fechaHoy.ToShortDateString()}- Hora: {fechaHoy.ToShortTimeString()} - Pago: ${pago}";
                pagos.RemoveAt(0);
                pagos.Add(strPago);
            }     
        }

        public void MostrarPagos() {
            foreach (String pago in pagos) {
                Console.WriteLine(pago);
                Console.WriteLine(pagos.Capacity);
            }
        }


    }   
}
