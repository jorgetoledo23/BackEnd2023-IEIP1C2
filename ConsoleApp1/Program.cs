using ConsoleApp1;

bool continuar = true;
List<Persona> list = new List<Persona>();

do
{
    Console.Clear();
    Console.WriteLine("[1] Ingresar Persona");
    Console.WriteLine("[2] Ver Personas Ingresadas");
    Console.WriteLine("[0] Salir");

    Console.Write("Selecciona tu Opcion: ");

    string OpcionSeleccionada = Console.ReadLine();

    switch (OpcionSeleccionada)
    {
        case "1":

            Persona p = new Persona();

            Console.Write("Ingresa DNI: ");
            p.DNI = Console.ReadLine();

            Console.Write("Ingresa Name: ");
            p.Name = Console.ReadLine();

            Console.Write("Ingresa LastName: ");
            p.LastName = Console.ReadLine();

            list.Add(p);

            Console.WriteLine("Persona Agregada");
            Console.Read();

            break;


        case "2":

            foreach (var P in list)
            {
                Console.WriteLine(P.getInfo());
            }
            Console.WriteLine("Personas Listadas");
            Console.Read();

            break;

        case "0":
            continuar = false;
            break;



        default:
            Console.WriteLine("Esa Opcion NO existe!");
            Console.ReadLine();
            break;
    }


} while (continuar);

Console.WriteLine("Gracias por Utilizar nuestra APP!");
