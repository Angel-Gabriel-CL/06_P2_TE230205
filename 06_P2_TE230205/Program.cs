// Clase para administrar la inspeccion del lote
class InspeccionLote
{
    // Propiedades para contar las piezas
    public int PiezasCorrectas { get; private set; }
    public int PiezasDefectuosas { get; private set; }

    // Metodo para registrar el resultado de una pieza
    public void RegistrarPieza(int valor)
    {
        if (valor == 1)
        {
            PiezasCorrectas++;
        }
        else if (valor == 0)
        {
            PiezasDefectuosas++;
        }
    }

    // Metodo para calcular el porcentaje de piezas correctas
    public double CalcularPorcentaje()
    {
        return (PiezasCorrectas / 10.0) * 100;
    }

    // Metodo para determinar si el lote se acepta
    public string ObtenerEstado()
    {
        if (CalcularPorcentaje() >= 90)
        {
            return "LOTE ACEPTADO";
        }
        else
        {
            return "LOTE RECHAZADO";
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("================================");
        Console.WriteLine(" INSPECCION DE LOTE DE 10 PIEZAS");
        Console.WriteLine("================================");
        Console.WriteLine("1 = Pieza correcta");
        Console.WriteLine("0 = Pieza defectuosa");
        Console.WriteLine();

        // Crear el objeto de inspeccion
        InspeccionLote lote1 = new InspeccionLote();

        // Ciclo para inspeccionar las diez piezas
        for (int i = 1; i <= 10; i++)
        {
            int valor;

            // Validar la entrada de cada pieza
            while (true)
            {
                Console.Write($"Resultado de la pieza {i} (0 o 1): ");

                if (int.TryParse(Console.ReadLine(), out valor)
                    && (valor == 0 || valor == 1))
                {
                    break;
                }

                Console.WriteLine(
                    "Entrada invalida. Introduzca solamente 0 o 1.");
            }

            // Registrar el resultado valido
            lote1.RegistrarPieza(valor);
        }

        // Mostrar el resumen de la inspeccion
        Console.WriteLine();
        Console.WriteLine("========= RESULTADOS =========");
        Console.WriteLine(
            $"Piezas correctas: {lote1.PiezasCorrectas}");
        Console.WriteLine(
            $"Piezas defectuosas: {lote1.PiezasDefectuosas}");
        Console.WriteLine(
            $"Porcentaje de piezas correctas: " +
            $"{lote1.CalcularPorcentaje():F2}%");
        Console.WriteLine(
            $"Estado del lote: {lote1.ObtenerEstado()}");
        Console.WriteLine("==============================");

        Console.WriteLine("Presione una tecla para finalizar.");
        Console.ReadKey();
    }
}