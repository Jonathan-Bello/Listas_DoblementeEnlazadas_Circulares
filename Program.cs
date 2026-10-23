using System;
using System.Collections.Generic;

var lista = new ListaEnlazada();
bool continuar = true;

var acciones = new Dictionary<int, Action>
{
    [1] = () => lista.Agregar(Pedir("Valor que deseas agregar: ")),
    [2] = () => Console.WriteLine(lista.ComoTexto()),
    [3] = () =>
    {
        int v = Pedir("Valor que deseas buscar: ");
        Console.WriteLine(lista.Contiene(v)
            ? $"Sí, el {v} se encuentra en la lista."
            : $"No, el {v} no se encuentra en la lista.");
    },
    [4] = () =>
    {
        int v = Pedir("Valor que deseas eliminar: ");
        Console.WriteLine(lista.Quitar(v)
            ? $"Se quitó el {v} de la lista."
            : lista.EstaVacia
                ? "La lista está vacía."
                : $"El {v} no existe en la lista.");
    },
    [0] = () =>
    {
        Console.WriteLine("Hasta luego.");
        continuar = false;
    }
};

while (continuar)
{
    Console.WriteLine("""

        === MENÚ: Lista enlazada simple ===
        1) Agregar valor
        2) Mostrar lista
        3) Buscar valor
        4) Eliminar valor
        0) Salir
        """);

    int eleccion = Pedir("Opción: ");

    if (acciones.TryGetValue(eleccion, out Action? accion))
        accion();
    else
        Console.WriteLine("Esa opción no existe.");
}

static int Pedir(string texto)
{
    int numero;
    Console.Write(texto);
    while (!int.TryParse(Console.ReadLine(), out numero))
    {
        Console.Write("Entrada inválida, escribe un entero: ");
    }
    return numero;
}

class Elemento
{
    public int Dato;
    public Elemento? Siguiente;

    public Elemento(int dato) => Dato = dato;
}

class ListaEnlazada
{
    private Elemento? _primero;
    private Elemento? _ultimo;

    public bool EstaVacia => _primero == null;

    public void Agregar(int dato)
    {
        var nuevo = new Elemento(dato);

        if (_ultimo == null)
        {
            _primero = _ultimo = nuevo;
        }
        else
        {
            _ultimo.Siguiente = nuevo;
            _ultimo = nuevo;
        }
    }

    private IEnumerable<int> Recorrer()
    {
        for (var e = _primero; e != null; e = e.Siguiente)
            yield return e.Dato;
    }

    public string ComoTexto()
    {
        if (EstaVacia) return "La lista está vacía.";
        return "Inicio -> " + string.Join(" -> ", Recorrer()) + " -> null";
    }

    public bool Contiene(int dato)
    {
        foreach (int d in Recorrer())
            if (d == dato) return true;
        return false;
    }

    public bool Quitar(int dato)
    {
        Elemento? previo = null;
        Elemento? actual = _primero;

        while (actual != null && actual.Dato != dato)
        {
            previo = actual;
            actual = actual.Siguiente;
        }

        if (actual == null) return false;

        if (previo == null)
            _primero = actual.Siguiente;
        else
            previo.Siguiente = actual.Siguiente;

        if (actual == _ultimo)
            _ultimo = previo;

        return true;
    }
}