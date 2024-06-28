using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace myfirstapp
{

    public class Usuario
    {

        string CardNumber;
        string firstname;
        string lastname;
        int Password;
        double amount;
        public List<string> transacciones = new List<string>();

        public Usuario(string CardNumber, string firstname, string lastname, int Password, double amount)
        {
            this.CardNumber = CardNumber;
            this.firstname = firstname;
            this.lastname = lastname;
            this.amount = amount;
            this.Password = Password;
        }

        public string getcardnumber()
        {
            return CardNumber;
        }

        public int getpassword()
        {
            return Password;
        }

        public double getamount()
        {
            return amount;
        }

        public void setamount(double value)
        {
            this.amount = value;
            
        }

        public int getpin() { return Password; }
        public string getname() { return firstname + " " + lastname; }


        public void gettrasaccions()
        {
            foreach(string accion in transacciones)
            {
             
                Console.WriteLine(accion);
            }
            Console.WriteLine("Presione Enter para continuar.");
        }
    }


}




