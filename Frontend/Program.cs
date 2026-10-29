

using Backend;

var list = new DoublyLinkedList<string>();
var option = -1;

while (option != 0)
{
    Console.WriteLine();
    Console.WriteLine("Menú:");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar la(s) moda(s)");
    Console.WriteLine("6. Mostrar gráfico");
    Console.WriteLine("7. Existe");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out option))
    {
        Console.WriteLine("Opción no válida. Ingrese un número.");
        option = -1;
        continue;
    }

    switch (option)
    {
        case 1:
            Console.Write("Ingrese el elemento que desea adicionar: ");
            var value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
            {
                list.Insert(value.Trim());
                Console.WriteLine("Elemento agregado correctamente.");
            }
            else
            {
                Console.WriteLine("El elemento no puede estar vacío.");
            }

            break;

        case 2:
            Console.WriteLine("Lista hacia adelante: " + list);
            break;

        case 3:
            Console.WriteLine("Lista hacia atrás: " + list.ToStringReverse());
            break;

        case 4:
            list.SortDescending();
            Console.WriteLine("Lista ordenada descendentemente.");
            Console.WriteLine(list);
            break;

        case 5:
            var modes = list.GetModes();

            if (modes.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else
            {
                Console.WriteLine("La(s) moda(s): "
                    + string.Join(", ", modes));
            }

            break;

        case 6:
            Console.WriteLine("Gráfico de ocurrencias:");

            var graph = list.GetOccurrenceGraph();

            if (graph == string.Empty)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else
            {
                Console.Write(graph);
            }

            break;

        case 7:
            Console.Write("Ingrese el elemento que desea buscar: ");
            var searchValue = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                Console.WriteLine(list.Contains(searchValue.Trim())
                    ? "El elemento existe en la lista."
                    : "El elemento no existe en la lista.");
            }
            else
            {
                Console.WriteLine("El elemento no puede estar vacío.");
            }

            break;

        case 8:
            Console.Write("Ingrese el elemento que desea eliminar: ");
            var removeValue = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(removeValue))
            {
                Console.WriteLine(list.Remove(removeValue.Trim())
                    ? "Se eliminó una ocurrencia del elemento."
                    : "El elemento no existe en la lista.");
            }
            else
            {
                Console.WriteLine("El elemento no puede estar vacío.");
            }

            break;

        case 9:
            Console.Write("Ingrese el elemento que desea eliminar por completo: ");
            var removeAllValue = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(removeAllValue))
            {
                var removed = list.RemoveAll(removeAllValue.Trim());
                Console.WriteLine(
                    $"Cantidad de ocurrencias eliminadas: {removed}");
            }
            else
            {
                Console.WriteLine("El elemento no puede estar vacío.");
            }

            break;

        case 0:
            Console.WriteLine("Hasta luego.");
            break;

        default:
            Console.WriteLine(
                "Opción no válida. Seleccione un número del 0 al 9.");
            break;
    }
}
