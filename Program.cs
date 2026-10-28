using System;
using System.Collections.Generic;

var lista = new ListaDoble();

bool continuar = true;

var acciones = new Dictionary<int, Action>
{
    [1] = () => lista.Agregar(Pedir("Valor que deseas agregar: ")),

    [2] = () => Console.WriteLine(lista.ComoTexto()),

    [3] = () => Console.WriteLine(lista.ComoTextoInverso()),

    [4] = () =>
    {
        int v = Pedir("Valor que deseas buscar: ");

        Console.WriteLine(lista.Contiene(v)
            ? $"Sí, el {v} se encuentra en la lista."
            : $"No, el {v} no se encuentra en la lista.");
    },

    [5] = () =>
    {
        int v = Pedir("Valor que deseas eliminar: ");

        Console.WriteLine(lista.Quitar(v)
            ? $"Se quitó el {v} de la lista."
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
        === MENÚ: Lista doblemente enlazada ===
        1) Agregar valor
        2) Mostrar de inicio a fin
        3) Mostrar de fin a inicio
        4) Buscar valor
        5) Eliminar valor
        0) Salir
        """);

    int opcion = Pedir("Opción: ");

    if (acciones.TryGetValue(opcion, out Action? accion))
        accion();
    else
        Console.WriteLine("Opción inválida.");
}

static int Pedir(string mensaje)
{
    int numero;

    Console.Write(mensaje);

    while (!int.TryParse(Console.ReadLine(), out numero))
    {
        Console.Write("Entrada inválida. Escribe un entero: ");
    }

    return numero;
}

class Nodo
{
    public int Dato;
    public Nodo? Siguiente;
    public Nodo? Anterior;

    public Nodo(int dato)
    {
        Dato = dato;
    }
}

class ListaDoble
{
    private Nodo? _primero;
    private Nodo? _ultimo;

    public bool EstaVacia => _primero == null;

    public void Agregar(int dato)
    {
        Nodo nuevo = new Nodo(dato);

        if (_primero == null)
        {
            _primero = nuevo;
            _ultimo = nuevo;
        }
        else
        {
            nuevo.Anterior = _ultimo;
            _ultimo!.Siguiente = nuevo;
            _ultimo = nuevo;
        }
    }

    public bool Contiene(int dato)
    {
        Nodo? actual = _primero;

        while (actual != null)
        {
            if (actual.Dato == dato)
                return true;

            actual = actual.Siguiente;
        }

        return false;
    }

    public bool Quitar(int dato)
    {
        Nodo? actual = _primero;

        while (actual != null && actual.Dato != dato)
        {
            actual = actual.Siguiente;
        }

        if (actual == null)
            return false;

        if (actual.Anterior != null)
            actual.Anterior.Siguiente = actual.Siguiente;
        else
            _primero = actual.Siguiente;

        if (actual.Siguiente != null)
            actual.Siguiente.Anterior = actual.Anterior;
        else
            _ultimo = actual.Anterior;

        return true;
    }

    public string ComoTexto()
    {
        if (EstaVacia)
            return "La lista está vacía.";

        List<int> elementos = new();

        Nodo? actual = _primero;

        while (actual != null)
        {
            elementos.Add(actual.Dato);
            actual = actual.Siguiente;
        }

        return "null <- " +
               string.Join(" <-> ", elementos) +
               " -> null";
    }

    public string ComoTextoInverso()
    {
        if (EstaVacia)
            return "La lista está vacía.";

        List<int> elementos = new();

        Nodo? actual = _ultimo;

        while (actual != null)
        {
            elementos.Add(actual.Dato);
            actual = actual.Anterior;
        }

        return "null <- " +
               string.Join(" <-> ", elementos) +
               " -> null";
    }
}