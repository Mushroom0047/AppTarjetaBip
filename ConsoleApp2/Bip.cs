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
            if (saldo >= CalcularPasaje()) {                
                saldo -= CalcularPasaje();
                AgregarPagos(CalcularPasaje());
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

        //Metodo para calcular pasaje
        private int CalcularPasaje() {
            Int32 hora_actual =  DateTime.Now.Hour;
            int pasaje = -1;

            //Horario bajo
            if (hora_actual >= 6 && hora_actual < 9 || hora_actual >= 21 && hora_actual < 23) {
                pasaje = Utilidades.VALOR_PASAJE[0];
            //Horario valle
            }else if (hora_actual > 9  && hora_actual <18) {
                pasaje = Utilidades.VALOR_PASAJE[1];
            //Horario punta
            } else if(hora_actual >= 18 && hora_actual < 21) {
                pasaje = Utilidades.VALOR_PASAJE[2];
            }          
            return pasaje;
        }
    }   
}
