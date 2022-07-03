using System;
using System.Collections.Generic;
using System.Text;

namespace Progra3.TPO
{
    public class GrafoDirigido<T> : Grafo<T>
    {
        List<int> vertices;
        List<Arco<T>> arcos;

        public GrafoDirigido()
        {
            this.vertices = new List<int>();
            this.arcos = new List<Arco<T>>();
        }

        public virtual void agregarArco(int verticeId1, int verticeId2, T etiqueta)
        {
            arcos.Add(new Arco<T>(verticeId1, verticeId2, etiqueta));
        }

        public void agregarVertice(int verticeId)
        {
            vertices.Add(verticeId);
        }

        public virtual void borrarArco(int verticeId1, int verticeId2)
        {
            //buscar el arco que tengo que borrar
            var etiqueta = arcos.Find(c => (c.getVerticeOrigen() == verticeId1) && (c.getVerticeDestino() == verticeId2)).getEtiqueta();

            //borrar
            if (etiqueta != null) {
                arcos.Remove(new Arco<T>(verticeId1, verticeId1, etiqueta));
            }
            //no lo encontro
        }

        // Aca puedo forzar que primero borre los arcos o los puedo borrar si el vertice se quiere borrar
        public void borrarVertice(int verticeId)
        {
            //buscar el arcos que tengo que borrar
            var arcosAux = arcos.FindAll(a => a.getVerticeOrigen() == verticeId ||
                                              a.getVerticeDestino() == verticeId).ToArray();

            //borro los arcos que estan asociados a ese vertice
            foreach (var arco in arcosAux)
                arcos.Remove(arco);

            //borro el vertice
            vertices.Remove(verticeId);
        }

        public int cantidadArcos()
        {
            return arcos.Count;
        }

        public int cantidadVertices()
        {
            return vertices.Count;
        }

        public bool contieneVertice(int verticeId)
        {
            return vertices.Contains(verticeId);
        }

        public bool existeArco(int verticeId1, int verticeId2)
        {
            //buscar el arcos que tengo que borrar
            var arco = obtenerArco(verticeId1, verticeId2);

            if (arco != null)
                return true;
            return false;
        }

        public List<int> obtenerAdyacentes(int verticeId)
        {
            var arcosAux = arcos.FindAll(a => a.getVerticeOrigen() == verticeId ||
                                          a.getVerticeDestino() == verticeId).ToArray();


            List<int> adyacentes = new List<int>();
            foreach (var arco in arcosAux)
            {
                // es origen, pero no destino
                if (arco.getVerticeOrigen() == verticeId && arco.getVerticeDestino() != verticeId)
                    adyacentes.Add(arco.getVerticeDestino());
                // es destino, pero no origen
                else if (arco.getVerticeDestino() == verticeId && arco.getVerticeOrigen() != verticeId)
                    adyacentes.Add(arco.getVerticeOrigen());
                // si el arco es un loop(origen y destino)
                else
                    adyacentes.Add(verticeId);
            }
            return adyacentes;
        }

        public Arco<T> obtenerArco(int verticeId1, int verticeId2)
        {
            return arcos.Find(a => a.getVerticeOrigen() == verticeId1 &&
                                       a.getVerticeDestino() == verticeId2);       
        }

        public List<Arco<T>> obtenerArcos()
        {
            return arcos;
        }

        // Obtiene un iterador que me permite recorrer todos los arcos que parten desde verticeId
        public List<Arco<T>> obtenerArcos(int verticeId)
        {
            var arcosAux = arcos.FindAll(a => a.getVerticeOrigen() == verticeId).ToArray();

            var aux = new List<Arco<T>>();
            foreach (var arco in arcosAux)
                aux.Add(arco);

            return aux;
        }

        // Obtiene un iterador que me permite recorrer todos los vertices almacenados en el grafo 
        public List<int> obtenerVertices()
        {
            return vertices;
        }
    }
}
