using Firstapp;
using myfirstapp;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;



namespace myfirstapp
{
    class Program()
    {

       

        static void Main(string[] args)

        {
            
            Console.Title = "BANCO DIAMANTE";
            Usuario currentuser;
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario("34501233488", "EMILIO", "ALEJANDRO", 9026, 123.5));
            usuarios.Add(new Usuario("76200034110", "Lopez", "Milagros", 3421, 402));
            usuarios.Add(new Usuario("45501763408", "Delmar", "Ortiz", 8756, 13434));


            int mitadW = Console.WindowWidth/2;
            int mitadh = Console.WindowHeight/2;
            DateTime fecha = DateTime.Now;

           
                
                Console.SetCursorPosition(mitadW - 18, 1);
                Console.Write("---BIENVENIDO AL BANCO DIAMANTE.---");
                Console.SetCursorPosition(2, 5);
                Console.Write("Ingresa el numero de tu tarjeta para continuar: ");

                do
                {
                    try
                    {
                        String? debitcard = Console.ReadLine();
                        currentuser = usuarios.FirstOrDefault(a => a.getcardnumber() == debitcard);
                        if (currentuser != null) { Console.Clear(); break; }
                        else { Console.Clear(); Console.WriteLine("Numero de tarjeta no valido, intente de nuevo."); }
                    }
                    catch
                    { Console.WriteLine("Numero de tarjeta no valido, intente de nuevo."); }

                } while (true);

                ///validacion
                ///
                Console.SetCursorPosition(mitadW - 15, mitadh - 5);
                Console.WriteLine("Ingrese el pin de su tarjeta");
                do
                {
                    try
                    {
                        Console.SetCursorPosition(mitadW - 5, mitadh - 3);
                        string userinput = ReadInputWithAsterisks();
                        int readpin = Convert.ToInt32(userinput);
                        int pin_ = currentuser.getpassword();
                        if (readpin == pin_) { break; }
                        else { Console.Clear(); Console.WriteLine("Pin no valido, intente de nuevo."); }
                    }
                    catch
                    { Console.Clear(); Console.WriteLine("Pin no valido, intente de nuevo."); }

                } while (true);
            
            void Menu()
            {


                int operacion;
                Console.Clear();
                Console.SetCursorPosition(mitadW - 19, 1);
                Console.Write($"====BIENVENIDO {currentuser.getname()}====");
                Console.SetCursorPosition(2, 3);
                Console.Write("Que operacion deseas realizar? : ");
                Console.SetCursorPosition(2, 5);
                Console.Write("1.Retiro");
                Console.SetCursorPosition(13, 5);
                Console.Write("2.Deposito");
                Console.SetCursorPosition(25, 5);
                Console.Write("3.Estado de cuenta");
                Console.SetCursorPosition(45, 5);
                Console.WriteLine("4.Transacciones");
                Console.SetCursorPosition(63,5);
                Console.Write("5.Salir");
                Console.SetCursorPosition(2,8);
                Console.Write("Opcion: ");

                  operacion = int.Parse(Console.ReadLine());
                


                switch (operacion) 
                {
                    case 1:
                        Console.Clear();
                        _retiro();
                        break;  
                    case 2:
                        Console.Clear();
                        deposito();
                        break;
                    case 3:
                        Console.Clear();
                        estado();
                        break;
                    case 4:
                        Console.Clear();
                        _transac();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }


            }


          void deposito()
            {
                Console.WriteLine("Cuanto dinero deseas depositar a tu cuenta");
                double newdeposito = double.Parse(Console.ReadLine());
                currentuser.setamount(currentuser.getamount()+newdeposito);

                Console.WriteLine($"Has depositado ${newdeposito} pesos.");
                Console.WriteLine($"Ahora cuentas con ${currentuser.getamount()} pesos.");
                currentuser.transacciones.Add($"El Usuario deposito ${newdeposito} pesos a su cuenta, el {fecha}.");
                Console.WriteLine("\t\t Presiona enter para continuar.");
                Console.ReadKey();
                Menu();
              
            }

          void _retiro()
            {
                double cantidad;
                Console.WriteLine("Que cantidad deseas retirar: ");
                Console.SetCursorPosition(40, 0);
                Console.Write($"||Cantidad disponible ${currentuser.getamount()} pesos.||");
              
                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(2, 3);
                        cantidad = double.Parse(Console.ReadLine());
                        if (currentuser.getamount()! > cantidad)
                        {
                            currentuser.setamount(currentuser.getamount() - cantidad);

                            Console.WriteLine($"Has retirado ${cantidad} pesos. ");
                            Console.WriteLine("Presione Enter para continuar.");
                            Console.ReadKey ();
                            currentuser.transacciones.Add($"El usuario retiro ${cantidad} pesos el {fecha}");
                            Menu();
                            break;
                        }
                        else { Console.Clear();Console.SetCursorPosition(1, 0); Console.WriteLine("No tienes suficiente dinero por favor intenta de nuevo");
                            Console.SetCursorPosition(65, 0);
                            Console.Write($"||Cantidad disponible ${currentuser.getamount()} pesos.||");

                        }

                    } catch { Console.Clear(); Console.SetCursorPosition(65, 0); Console.WriteLine("No tienes suficiente dinero por favor intenta de nuevo"); Console.SetCursorPosition(50, 0);
                        Console.Write($"||Cantidad disponible ${currentuser.getamount()} pesos.||");
                    }
                }
            }

            void estado ()
            {
                Console.SetCursorPosition(mitadW - 15, 5);
                Console.Write(" El saldo en tu cuenta es: ");
                Console.SetCursorPosition(mitadh+30, mitadh);
                Console.CursorVisible = false ;
                Console.WriteLine($" ${currentuser.getamount()} pesos.");
                Console.WriteLine("Presiona Enter para continuar.");
                Console.ReadKey();
                Console.CursorVisible=true;
                Console.Clear();
                Menu();
            }
            Menu();

            static string ReadInputWithAsterisks()
            {
                string input = string.Empty;
                ConsoleKeyInfo keyInfo;

                // Leer las teclas una por una
                while (true)
                {
                    // Leer la tecla presionada sin mostrarla en la consola
                    keyInfo = Console.ReadKey(intercept: true);

                    // Si la tecla es Enter, finaliza la captura
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine(); // Mueve a la siguiente línea
                        break;
                    }
                    // Si la tecla es Backspace y hay algo que borrar
                    else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        // Eliminar el último carácter del input
                        input = input.Substring(0, input.Length - 1);

                        // Mover el cursor una posición hacia atrás
                        Console.Write("\b \b");
                    }
                    // Capturar las otras teclas (no incluidas teclas de control como Alt, Ctrl, etc.)
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        // Añadir el carácter a la entrada del usuario
                        input += keyInfo.KeyChar;

                        // Mostrar un asterisco
                        Console.Write("*");
                    }
                }

                return input;
            }

            void _transac()
            {
                if (currentuser.transacciones.Count != 0)
                {
                    currentuser.gettrasaccions();
                }
                else { Console.WriteLine("No hay un historial de transacciones disponible."); Console.WriteLine("\n\n Presione Enter para continuar."); }
                Console.ReadKey ();
                Menu();     

            }


        }





    }

}

    