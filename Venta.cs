using System.Globalization;

public class Venta
{
    public double[] ventas = new double[7];
    string[] dias = new[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
    double total = 0;
    double promedio = 0;
    int indiceMax = 0;


    public int GetCantidadDias()
    {
        return dias.Length;
    }

    public void RegistrarVentaDia(int i)
    {
        while (true)
        {
            Console.Write($"Ingrese la venta para {dias[i]}: ");
            string? line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine("Entrada vacía. Intente nuevamente.");
                continue;
            }

            if (double.TryParse(line, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out double val))
            {
                if (val < 0)
                {
                    Console.WriteLine("La venta no puede ser negativa. Intente nuevamente.");
                    continue;
                }
                ventas[i] = val;
                break;
            }

            Console.WriteLine("Valor inválido. Ingrese un número (p. ej. 1234.56 o 1,234.56).");
        }
    }

    public void Calcular()
    {
        total = 0;
        for (int i = 0; i < ventas.Length; i++) total += ventas[i];

        promedio = total / ventas.Length;

        indiceMax = 0;
        for (int i = 1; i < ventas.Length; i++)
        {
            if (ventas[i] > ventas[indiceMax]) indiceMax = i;
        }
    }

    public void MostrarResumen()
    {
        for (int i = 0; i < GetCantidadDias(); i++)
        {
            Console.WriteLine($"- {dias[i]}: {ventas[i]:F2}$");
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Total vendido en la semana: {total:F2}$");
        Console.WriteLine($"Promedio diario: {promedio:F2}$");
        Console.WriteLine($"Día con la venta máxima: {dias[indiceMax]} ({ventas[indiceMax]:F2}$)");
    }

}