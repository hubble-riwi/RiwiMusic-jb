using RiwiMusic.Class;
Dictionary<int, Client>  clients = new Dictionary<int, Client>();
Dictionary<int, Concert> concerts = new Dictionary<int, Concert>();
Dictionary<int, Ticket> tickets = new Dictionary<int, Ticket>();

bool exitMenu = false;
while (!exitMenu)
{
    Console.WriteLine("Bienvenido a RiwiMusic\n------------------------------------\n Que deseas hacer? \n1. Gestionar conciertos\n2. Gestionar clientes\n3. Gestionar tiquetes" +
                      "\n4. Historial de compras \n5. Hacer una consulta avanzada \n6. Salir");
    int optionsMenu = Convert.ToInt32(Console.ReadLine());

    switch (optionsMenu)
    {
        case 1:
            Concert newConcert = new Concert();
            newConcert.menuConcert(concerts);
            break;

        case 2: 
            Client newClient = new Client();
            newClient.menuClient(clients);
            break;

        case 3:
            Ticket newTicket = new Ticket();
            newTicket.menuTicket(tickets, concerts, clients);
            break;

        case 4:
            buyHistory(tickets);
            break;

        case 5:
            advancedQ(tickets, concerts);
            break;

        case 6:
            Console.WriteLine("¡Hasta pronto! Gracias por usar RiwiMusic.");
            exitMenu = true;
            break;

        default:
            Console.WriteLine("Opción no válida, por favor ingresa un número válido.");
            break;
    }

    if (!exitMenu)
    {
        Console.WriteLine("\nPresiona cualquier tecla para volver al menú principal...");
        Console.ReadKey();
        Console.Clear();
    }
}

void buyHistory(Dictionary<int, Ticket> tickets)
{
    Console.WriteLine("Ingrese el id del cliente del cual quiere ver el historial: ");
    int idToSearch = Convert.ToInt32(Console.ReadLine());
    var clientTickets = tickets.Values
        .Where(ticket => ticket.idClientTicket == idToSearch)
        .ToList();
        
    if (clientTickets.Count > 0)
    {
        Console.WriteLine($"Historial de compras del cliente con ID {idToSearch}:");
        foreach (var ticket in clientTickets)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Ticket ID: {ticket.idTicket}, Concierto: {ticket.nameConcertTicket}, Fecha Compra: {ticket.dateBuyTicket}, Precio: {ticket.priceTicket}");
            Console.WriteLine("------------------------------");
        }
    }
    else
    {
        Console.WriteLine($"No se encontraron tickets para el cliente con ID {idToSearch}.");
    }
}

void advancedQ(Dictionary<int, Ticket> tickets, Dictionary<int, Concert> concerts)
{
    bool exitAdvancedMenu = false;

    while (!exitAdvancedMenu)
    {
        Console.WriteLine("\nQue deseas consultar? \n1. Consultar conciertos por ciudad\n2. Consultar conciertos por rango de fechas\n3. Consultar el concierto con más tiquetes vendidos" +
                          "\n4. Consultar ingresos totales de un concierto\n5. Consultar el cliente con más compras realizadas\n6. Volver al menú principal");
        int consultaMenu = Convert.ToInt32(Console.ReadLine());

        switch (consultaMenu)
        {
            case 1:
                CheckoutByCity(concerts);
                break;

            case 2:
                CheckoutByDate(concerts);
                break;

            case 3:
                CheckoutByTickets(tickets, concerts);
                break;

            case 4:
                CheckEarnings(tickets, concerts);
                break;

            case 5:
                CustomerMostPurch(tickets);
                break;

            case 6:
                Console.WriteLine("Regresando al menú principal...");
                exitAdvancedMenu = true;
                break;

            default:
                Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
                break;
        }

        if (!exitAdvancedMenu)
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

void CheckoutByCity(Dictionary<int, Concert> concerts)
{
    Console.WriteLine("Ingrese la ciudad por la que desea consultar: ");
    string city = Console.ReadLine();
    
    var concertsByCity = concerts.Values
        .Where(concert => concert.cityConcert.Equals(city, StringComparison.OrdinalIgnoreCase))
        .ToList();

    if (concertsByCity.Any())
    {
        Console.WriteLine($"Conciertos disponibles en {city}:");
        foreach (var concert in concertsByCity)
        {
            Console.WriteLine($"{concert.nameConcert} - Fecha: {concert.dateConcert} - Precio: {concert.priceConcert}");
        }
    }
    else
    {
        Console.WriteLine($"No se encontraron conciertos en {city}.");
    }
}

void CheckoutByDate(Dictionary<int, Concert> concerts)
{
    Console.WriteLine("Ingrese la fecha de inicio (formato: dd/MM/yyyy): ");
    DateTime dateStart = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
    
    Console.WriteLine("Ingrese la fecha de fin (formato: dd/MM/yyyy): ");
    DateTime dateEnd = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
    
    var concertsByDates = concerts.Values
        .Where(concert => concert.dateConcert >= dateStart && concert.dateConcert <= dateEnd)
        .ToList();

    if (concertsByDates.Any())
    {
        Console.WriteLine($"Conciertos entre {dateStart.ToShortDateString()} y {dateEnd.ToShortDateString()}:");
        foreach (var concert in concertsByDates)
        {
            Console.WriteLine($"{concert.nameConcert} - Fecha: {concert.dateConcert} - Precio: {concert.priceConcert}");
        }
    }
    else
    {
        Console.WriteLine($"No se encontraron conciertos en ese rango de fechas.");
    }
}

void CheckoutByTickets(Dictionary<int, Ticket> tickets, Dictionary<int, Concert> concerts)
{
    var concertMostPurch = tickets.Values
        .GroupBy(ticket => ticket.idConcertTicket)
        .OrderByDescending(group => group.Count())
        .FirstOrDefault();

    if (concertMostPurch != null)
    {
        var concert = concerts[concertMostPurch.Key];
        Console.WriteLine($"El concierto con más tiquetes vendidos es: {concert.nameConcert}");
        Console.WriteLine($"Tickets vendidos: {concertMostPurch.Count()}");
        Console.WriteLine($"Fecha: {concert.dateConcert}, Precio: {concert.priceConcert}");
    }
    else
    {
        Console.WriteLine("No se han registrado tickets.");
    }
}

void CheckEarnings(Dictionary<int, Ticket> tickets, Dictionary<int, Concert> concerts)
{
    Console.WriteLine("Ingrese el ID del concierto para consultar los ingresos: ");
    int idCon = Convert.ToInt32(Console.ReadLine());

    var ticketsConcert = tickets.Values
        .Where(ticket => ticket.idConcertTicket == idCon)
        .ToList();
    
    if (ticketsConcert.Any())
    {
        var concert = concerts[idCon];
        double totalEarnings = ticketsConcert.Count * concert.priceConcert;
        Console.WriteLine($"Ingresos totales del concierto {concert.nameConcert}: {totalEarnings}.");
    }
    else
    {
        Console.WriteLine($"No se han vendido tickets para el concierto con ID {idCon}.");
    }
}

void CustomerMostPurch(Dictionary<int, Ticket> tickets)
{
    var customerPurch = tickets.Values
        .GroupBy(ticket => ticket.idClientTicket)
        .OrderByDescending(group => group.Count())
        .FirstOrDefault();

    if (customerPurch != null)
    {
        Console.WriteLine($"El cliente con más compras realizadas es el cliente con ID {customerPurch.Key}");
        Console.WriteLine($"Cantidad de compras: {customerPurch.Count()}");
    }
    else
    {
        Console.WriteLine("No se han registrado compras.");
    }
}