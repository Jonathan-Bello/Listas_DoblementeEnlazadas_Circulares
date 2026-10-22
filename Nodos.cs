namespace listas_dobles_circulares_profe {

   // Nodo simple: Listas enlazadas
    class Nodo {
        public int valor;
        public Nodo sig;

        public Nodo(int valor) {
            this.valor = valor;
            this.sig = null;
        }
    }

    class NodoDoble {
        public int valor;
        public NodoDoble sig;
        public NodoDoble ant;

        public NodoDoble(int valor) {
            this.valor = valor;
            this.sig = null;
            this.ant = null;
        }
    }
}