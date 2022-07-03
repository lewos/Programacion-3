using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Progra3.TPO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //var prueba = new GrafoDirigido<string>();
            //prueba.agregarVertice(0);
            //prueba.agregarVertice(1);
            //prueba.agregarArco(0, 1, "a");

            //Console.WriteLine(prueba.contieneVertice(0));
            //Console.WriteLine(prueba.contieneVertice(1));
            //Console.WriteLine(prueba.contieneVertice(2));

            //Console.WriteLine(prueba.existeArco(0, 1));
            //Console.WriteLine(prueba.existeArco(0, 2));



            /////hasta aca dsp ver si esta implementado correctamente
            //prueba.borrarVertice(1);
            //prueba.borrarVertice(2);

            //prueba.borrarArco(0, 1);
            //prueba.borrarArco(0, 2);


            //Console.WriteLine(prueba.cantidadVertices());
            //Console.WriteLine(prueba.cantidadArcos());


            //prueba.obtenerArco(0, 1);
            //prueba.obtenerArco(0, 2);
            //prueba.obtenerArco(1, 2);

            //prueba.obtenerAdyacentes(0);

            //prueba.obtenerArcos(0);

            //prueba.obtenerArcos();

            //prueba.obtenerVertices();



            GrafoNoDirigido<string> grafoNoDirigido = new GrafoNoDirigido<string>();

            grafoNoDirigido.agregarVertice(1);
            grafoNoDirigido.agregarVertice(2);
            grafoNoDirigido.agregarVertice(3);
            grafoNoDirigido.agregarVertice(4);
            grafoNoDirigido.agregarVertice(5);
            grafoNoDirigido.agregarVertice(6);
            grafoNoDirigido.agregarVertice(7);
            grafoNoDirigido.agregarVertice(8);
            grafoNoDirigido.agregarArco(1, 2,"a");
            grafoNoDirigido.agregarArco(1, 5,"b");
            grafoNoDirigido.agregarArco(2, 3,"c");
            grafoNoDirigido.agregarArco(2, 6,"d");
            grafoNoDirigido.agregarArco(3, 4,"e");
            grafoNoDirigido.agregarArco(3, 7,"f");
            grafoNoDirigido.agregarArco(4, 5,"g");
            grafoNoDirigido.agregarArco(4, 7,"h");
            grafoNoDirigido.agregarArco(4, 8,"i");
            grafoNoDirigido.agregarArco(5, 8,"j");
            grafoNoDirigido.agregarArco(6, 7,"k");
            grafoNoDirigido.agregarArco(7, 8,"l");


            DFS(grafoNoDirigido, 4);
            BFS(grafoNoDirigido, 4);


        }


        public static void DFS(GrafoNoDirigido<string> grafo, int nodoInicial) 
        {
            // LIFO : Last in, first out
            Stack<int> pila = new Stack<int>();
            HashSet<int> nodosVisitados = new HashSet<int>();

            // Agrego el inicio a la pila
            pila.Push(nodoInicial);

            // mientras la pila no este vacia
            while (pila.Count != 0) 
            {
                // saco un nodo de la pila
                int verticeActual = pila.Pop();

                // Para ver los elementos actuales de la pila
                ImprimirPila(pila);                

                // pregunto si no fue visitado y lo imprimo por consola
                if (!nodosVisitados.Contains(verticeActual)) 
                {
                    nodosVisitados.Add(verticeActual);
                    Console.WriteLine($"Visitando los vecinos de {verticeActual}");
                }

                // remuevo los vertices adjacentes repetidos
                var verticesAdjacentes = grafo.obtenerAdyacentes(verticeActual).Distinct().ToList(); ;

                foreach (var verticeAdjacente in verticesAdjacentes) 
                {
                    // Si no contiene al vertice adjacente, lo agrego a la pila
                    if (!nodosVisitados.Contains(verticeAdjacente)) 
                    {
                        pila.Push(verticeAdjacente);
                        Console.WriteLine($"Se agrega el vertice {verticeAdjacente} a la pila");
                    }
                }
            }

        }

        private static void ImprimirPila(Stack<int> pila)
        {
            if(pila.ToList().Count == 0)
                Console.WriteLine("Pila vacia");
            else
            {
                Console.WriteLine($"Elementos de la pila");
                foreach (var ele in pila.ToList()) 
                {
                    Console.WriteLine(ele);
                }
            }
        }

        public static void BFS(GrafoNoDirigido<string> grafo, int nodoInicial)
        {
            // FIFO : First in, first out
            Queue<int> cola = new Queue<int>();
            HashSet<int> nodosVisitados = new HashSet<int>();

            // Agrego el inicio a la cola
            cola.Enqueue(nodoInicial);

            // mientras la cola no este vacia
            while (cola.Count != 0)
            {
                // saco un nodo de la pila
                int verticeActual = cola.Dequeue();

                // Para ver los elementos actuales de la cola
                ImprimirCola(cola);

                // pregunto si no fue visitado y lo imprimo por consola
                if (!nodosVisitados.Contains(verticeActual))
                {
                    nodosVisitados.Add(verticeActual);
                    Console.WriteLine($"Visitando los vecinos de {verticeActual}");
                }

                // remuevo los vertices adjacentes repetidos
                var verticesAdjacentes = grafo.obtenerAdyacentes(verticeActual).Distinct().ToList(); ;

                foreach (var verticeAdjacente in verticesAdjacentes)
                {
                    // Si no contiene al vertice adjacente, lo agrego a la pila
                    if (!nodosVisitados.Contains(verticeAdjacente))
                    {
                        cola.Enqueue(verticeAdjacente);
                        Console.WriteLine($"Se agrega el vertice {verticeAdjacente} a la cola");
                    }
                }
            }

        }

        private static void ImprimirCola(Queue<int> cola)
        {
            if (cola.Count == 0)
                Console.WriteLine("Cola vacia");
            else
            {
                Console.WriteLine($"Elementos de la Cola");
                foreach (var ele in cola)
                {
                    Console.WriteLine(ele);
                }
            }
        }
    }
}
