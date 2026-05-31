Console.WriteLine("Registro de ventas - 7 días");

Venta venta = new Venta();

for (int i = 0; i < venta.GetCantidadDias(); i++)
{
	venta.RegistrarVentaDia(i);
}

venta.Calcular();
Console.WriteLine("------------------------------");
Console.WriteLine("Resumen de ventas:");
venta.MostrarResumen();
