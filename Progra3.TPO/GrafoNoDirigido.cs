using System;
using System.Collections.Generic;
using System.Text;

namespace Progra3.TPO
{
    public class GrafoNoDirigido<T> : GrafoDirigido<T>
    {
		public override void agregarArco(int verticeId1, int verticeId2, T etiqueta) {
			base.agregarArco(verticeId1, verticeId2, etiqueta);
			base.agregarArco(verticeId2, verticeId1, etiqueta);
		}

		public override void borrarArco(int verticeId1, int verticeId2)
		{
			base.borrarArco(verticeId1, verticeId2);
			base.borrarArco(verticeId2, verticeId1);
		}
	}
}
