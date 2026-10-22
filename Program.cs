using listas_dobles_circulares_profe;

Nodo? cabeza = null;
int opcion;

do
{
	Console.WriteLine("\n--- Lista enlazada simple ---");
	Console.WriteLine("1. Agregar valor");
	Console.WriteLine("2. Mostrar lista");
	Console.WriteLine("3. Buscar valor");
	Console.WriteLine("4. Eliminar valor");
	Console.WriteLine("0. Salir");
	opcion = LeerEntero("Elige una opción: ");

	switch (opcion)
	{
		case 1:
			Agregar(LeerEntero("Valor que deseas agregar: "));
			break;
		case 2:
			Mostrar();
			break;
		case 3:
			int buscado = LeerEntero("Valor que deseas buscar: ");
			Console.WriteLine(Buscar(buscado)
				? $"El valor {buscado} está en la lista."
				: $"El valor {buscado} no está en la lista.");
			break;
		case 4:
			Eliminar(LeerEntero("Valor que deseas eliminar: "));
			break;
		case 0:
			Console.WriteLine("Programa finalizado.");
			break;
		default:
			Console.WriteLine("Opción no válida.");
			break;
	}
} while (opcion != 0);

int LeerEntero(string mensaje)
{
	while (true)
	{
		Console.Write(mensaje);
		if (int.TryParse(Console.ReadLine(), out int valor))
		{
			return valor;
		}

		Console.WriteLine("Ingresa un número entero válido.");
	}
}

void Agregar(int valor)
{
	Nodo nuevo = new(valor);
	if (cabeza is null)
	{
		cabeza = nuevo;
		return;
	}

	Nodo actual = cabeza;
	while (actual.sig is not null)
	{
		actual = actual.sig;
	}

	actual.sig = nuevo;
}

void Mostrar()
{
	if (cabeza is null)
	{
		Console.WriteLine("La lista está vacía.");
		return;
	}

	Nodo? actual = cabeza;
	Console.Write("Inicio -> ");
	while (actual is not null)
	{
		Console.Write($"{actual.valor} -> ");
		actual = actual.sig;
	}

	Console.WriteLine("null");
}

bool Buscar(int valor)
{
	Nodo? actual = cabeza;
	while (actual is not null)
	{
		if (actual.valor == valor)
		{
			return true;
		}

		actual = actual.sig;
	}

	return false;
}

void Eliminar(int valor)
{
	if (cabeza is null)
	{
		Console.WriteLine("La lista está vacía.");
		return;
	}

	if (cabeza.valor == valor)
	{
		cabeza = cabeza.sig;
		Console.WriteLine($"Se eliminó el valor {valor}.");
		return;
	}

	Nodo? anterior = cabeza;
	while (anterior.sig is not null && anterior.sig.valor != valor)
	{
		anterior = anterior.sig;
	}

	if (anterior.sig is null)
	{
		Console.WriteLine($"El valor {valor} no está en la lista.");
		return;
	}

	anterior.sig = anterior.sig.sig;
	Console.WriteLine($"Se eliminó el valor {valor}.");
}
