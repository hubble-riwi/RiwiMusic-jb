namespace RiwiMusic.Class;

public class Ticket
{
    public int idTicket { get; set; }
    public int idConcertTicket { get; set; }
    public string nameConcertTicket {get; set;}
    public DateTime dateConcertTicket { get; set; }
    public int idClientTicket {get; set;}
    public string nameClientTicket {get; set;}
    public DateTime dateBuyTicket {get; set;}
    public double priceTicket {get; set;}

    public Ticket()
    {
        
    }

    public void menuTicket(Dictionary<int, Ticket> tickets, Dictionary<int, Concert> concerts, Dictionary<int, Client> clients)
    {
        bool returnMenuTicket = true;
        while (returnMenuTicket)
        {
            
        Console.WriteLine("     1. Registrar compra de tiquete \n C    2. Listar tiquetes vendidos\n     3. Editar compra\n     4. Eliminar compra\n     5. Salir");
        int optionMenuClient =  Convert.ToInt32(Console.ReadLine());
        switch (optionMenuClient)
        {
            case 1:
                registerTicket(tickets, concerts, clients);
                break;
            case 2:
                viewTicket(tickets);
                break;
            case 3:
                updateTicket(tickets);
                break;
            case 4: 
                deleteTicket(tickets);
                break;
            case 5:
                returnMenuTicket = false;
                break;
        }
        }
        
    }


    public void registerTicket(Dictionary<int, Ticket> tickets, Dictionary<int, Concert> concerts, Dictionary<int, Client> clients)
    {
        Console.WriteLine("Ingrese el id del concierto: ");
        int idConcert = Convert.ToInt32(Console.ReadLine());
        if (!concerts.ContainsKey(idConcert))
        {
            Console.WriteLine("El concierto con ese ID no existe.");
            return;
        }
        
        Console.WriteLine("Ingrese el numero de identificacion del cliente: ");
        int idClient = Convert.ToInt32(Console.ReadLine());
        if (!clients.ContainsKey(idClient))
        {
            Console.WriteLine("El cliente con ese ID no existe.");
            return;
        }
        
        Concert concert = concerts[idConcert];
        Client client = clients[idClient];
        Ticket newTicket = new Ticket
        {
            idTicket = tickets.Count + 1,
            idConcertTicket = concert.idConcert,
            nameConcertTicket = concert.nameConcert,
            dateConcertTicket = concert.dateConcert,
            idClientTicket = client.idClient,
            nameClientTicket = client.nameClient,
            dateBuyTicket = DateTime.Now,
            priceTicket = concert.priceConcert
        };
        
        tickets.Add(newTicket.idTicket, newTicket);

        Console.WriteLine("¡Ticket registrado exitosamente!");
    }


    public void viewTicket(Dictionary<int, Ticket>  tickets)
    {   Console.WriteLine("DATOS  DEL BOLETO");
        Console.WriteLine("------------------------------");
        foreach (KeyValuePair<int, Ticket> ticketEntry in tickets)
        {
            Ticket ticket = ticketEntry.Value;
            Console.WriteLine($"ID del Ticket: {ticket.idTicket}");
            Console.WriteLine($"Concierto: {ticket.nameConcertTicket} + Id: {ticket.idConcertTicket}");
            Console.WriteLine($"Fecha del concierto: {ticket.dateConcertTicket}");
            Console.WriteLine($"Cliente: {ticket.nameClientTicket} +  Id: {ticket.idClientTicket}");
            Console.WriteLine($"Fecha de compra: {ticket.dateBuyTicket}");
            Console.WriteLine($"Precio del boleto: {ticket.priceTicket}");
            Console.WriteLine("------------------------------");

        }
    }

    public void updateTicket(Dictionary<int, Ticket>  tickets)
    {
        Console.WriteLine("Ingrese el ID del ticket que desea editar: ");
        int idTicket = Convert.ToInt32(Console.ReadLine());

        if (!tickets.ContainsKey(idTicket))
        {
            Console.WriteLine("El ticket con ese ID no existe.");
            return;
        }

        Ticket ticketToEdit = tickets[idTicket];

        Console.WriteLine("¿Qué desea editar?");
        Console.WriteLine("1. Fecha de compra");
        Console.WriteLine("2. Precio del boleto");
        Console.WriteLine("Seleccione una opción (1-2): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Ingrese la nueva fecha de compra (yyyy-MM-dd): ");
                ticketToEdit.dateBuyTicket = Convert.ToDateTime(Console.ReadLine());
                break;

            case 2:
                Console.WriteLine("Ingrese el nuevo precio del boleto: ");
                ticketToEdit.priceTicket = Convert.ToDouble(Console.ReadLine());
                break;

            default:
                Console.WriteLine("Opción no válida.");
                return;
        }
        
        tickets[idTicket] = ticketToEdit;
        Console.WriteLine("Ticket actualizado correctamente.");
    }

    public void deleteTicket(Dictionary<int, Ticket>  tickets)
    {
        Console.WriteLine("Ingrese el ID del boleto que desea eliminar: ");
        int idTicket = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Seguro que quiere eliminar a: " + tickets[idTicket].idTicket + " si/no");
        string secureDeleteTicket = Console.ReadLine();
        if (secureDeleteTicket == "si")
        {
            tickets.Remove(idTicket);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Boleto eliminado con exito ");
            Console.WriteLine("----------------------------------------");
            
        }
    }
}