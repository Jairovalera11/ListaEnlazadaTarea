using System;

namespace ListaEnlazadaTarea
{
    // Clase que representa un nodo individual de la lista
    class nodo
    {
        public int dato;         
        public nodo siguiente;    
    }

    // Clase que gestiona la lista simplemente enlazada
    class lista
    {
        public nodo inicio; 

       
        public lista()
        {
            inicio = null;
        }

        // Método para insertar al final de la lista 
        public void InsertarF(int item)
        {
            nodo auxiliar = new nodo();
            auxiliar.dato = item;
            auxiliar.siguiente = null;

            if (inicio == null)
            {
                inicio = auxiliar;
            }
            else
            {
                nodo puntero = inicio;
                while (puntero.siguiente != null)
                {
                    puntero = puntero.siguiente;
                }
                puntero.siguiente = auxiliar;
            }
        }

        // Método para insertar al inicio de la lista 
        public void InsertarI(int item)
        {
            nodo auxiliar = new nodo();
            auxiliar.dato = item;
            auxiliar.siguiente = null;

            if (inicio == null)
            {
                inicio = auxiliar;
            }
            else
            {
                nodo puntero = inicio;
                inicio = auxiliar;
                auxiliar.siguiente = puntero;
            }
        }

        // Método para eliminar el nodo a la cabeza de la lista
        public void EliminarI()
        {
            if (inicio == null)
            {
                Console.WriteLine("¡Lista vacía, no se puede eliminar elemento!");
            }
            else
            {
                inicio = inicio.siguiente;
                Console.WriteLine("Elemento al frente eliminado con éxito.");
            }
        }

        // Método para eliminar el nodo al final de la lista 
        public void EliminarF()
        {
            if (inicio == null)
            {
                Console.WriteLine("¡Lista vacía, no se puede eliminar elemento!");
            }
            else if (inicio.siguiente == null)
            {
                inicio = null; 
                Console.WriteLine("Único elemento eliminado. La lista ahora está vacía.");
            }
            else
            {
                nodo punteroant = inicio;
                nodo punteropost = inicio;

                while (punteropost.siguiente != null)
                {
                    punteroant = punteropost;
                    punteropost = punteropost.siguiente;
                }
                punteroant.siguiente = null;
                Console.WriteLine("Elemento al final eliminado con éxito.");
            }
        }

        // Ejercicio 2: Método para insertar por posición con validación de límites
        public void InsertarP(int item, int pos)
        {
            nodo auxiliar = new nodo();
            auxiliar.dato = item;
            auxiliar.siguiente = null;

            if (inicio == null || pos <= 1)
            {
                auxiliar.siguiente = inicio;
                inicio = auxiliar;
                return;
            }

            nodo puntero = inicio;
            int contador = 1;

            
            while (contador < pos - 1 && puntero.siguiente != null)
            {
                puntero = puntero.siguiente;
                contador++;
            }

            
            if (contador < pos - 1)
            {
                Console.WriteLine($"[Alerta]: La posición {pos} no existe. El elemento será insertado al final.");
                InsertarF(item);
            }
            else
            {
                nodo punteronext = puntero.siguiente;
                puntero.siguiente = auxiliar;
                auxiliar.siguiente = punteronext;
                Console.WriteLine($"Elemento insertado en la posición {pos} con éxito.");
            }
        }

        // Ejercicio 3: Método para insertar elementos de forma ascendente
        public void InsertarAscendente(int item)
        {
            nodo auxiliar = new nodo();
            auxiliar.dato = item;
            auxiliar.siguiente = null;

            
            if (inicio == null || item < inicio.dato)
            {
                auxiliar.siguiente = inicio;
                inicio = auxiliar;
                Console.WriteLine("Elemento insertado al inicio (orden ascendente).");
                return;
            }

            nodo puntero = inicio;
            while (puntero.siguiente != null && puntero.siguiente.dato < item)
            {
                puntero = puntero.siguiente;
            }

            auxiliar.siguiente = puntero.siguiente;
            puntero.siguiente = auxiliar;
            Console.WriteLine("Elemento insertado ordenadamente.");
        }

        // Método que muestra el contenido de la lista en pantalla
        public void Mostrar()
        {
            if (inicio == null)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else
            {
                nodo puntero = inicio;
                Console.Write("Contenido de la lista: ");
                while (puntero != null)
                {
                    Console.Write($"{puntero.dato} -> ");
                    puntero = puntero.siguiente;
                }
                Console.WriteLine("null");
            }
        }
    }

    // Ejercicio 1: Clase Program con menú 
    class Program
    {
        static void Main(string[] args)
        {
            lista listanueva = new lista();
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("   MENÚ DE OPERACIONES - LISTAS ENLAZADAS");
                Console.WriteLine("=========================================");
                Console.WriteLine("a. Insertar al Frente (Cabeza)");
                Console.WriteLine("b. Insertar al Final (Cola)");
                Console.WriteLine("c. Insertar en una posición específica");
                Console.WriteLine("d. Insertar en orden ascendente (Ejercicio 3)");
                Console.WriteLine("e. Eliminar al Frente");
                Console.WriteLine("f. Eliminar al Final");
                Console.WriteLine("g. Mostrar lista");
                Console.WriteLine("h. Salir");
                Console.WriteLine("=========================================");
                Console.Write("Seleccione una opción: ");

                string entrada = Console.ReadLine()?.ToLower();
                char opcionChar = string.IsNullOrEmpty(entrada) ? ' ' : entrada[0];

                switch (opcionChar)
                {
                    case 'a':
                        Console.Write("Ingrese el valor entero a insertar al frente: ");
                        if (int.TryParse(Console.ReadLine(), out int valI))
                        {
                            listanueva.InsertarI(valI);
                        }
                        break;

                    case 'b':
                        Console.Write("Ingrese el valor entero a insertar al final: ");
                        if (int.TryParse(Console.ReadLine(), out int valF))
                        {
                            listanueva.InsertarF(valF);
                        }
                        break;

                    case 'c':
                        Console.Write("Ingrese el valor entero: ");
                        int valP = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Ingrese la posición deseada: ");
                        int pos = int.Parse(Console.ReadLine() ?? "0");
                        listanueva.InsertarP(valP, pos);
                        break;

                    case 'd':
                        Console.Write("Ingrese el valor entero para inserción ascendente: ");
                        if (int.TryParse(Console.ReadLine(), out int valAsc))
                        {
                            listanueva.InsertarAscendente(valAsc);
                        }
                        break;

                    case 'e':
                        listanueva.EliminarI();
                        break;

                    case 'f':
                        listanueva.EliminarF();
                        break;

                    case 'g':
                        Console.WriteLine();
                        listanueva.Mostrar();
                        break;

                    case 'h':
                        Console.WriteLine("Saliendo de la aplicación...");
                        opcion = 1; 
                        break;

                    default:
                        Console.WritaeLine("Opción no válida. Intente de nuevo.");
                        break;
                }

                if (opcionChar != 'h')
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion == 0);
        }
    }
}