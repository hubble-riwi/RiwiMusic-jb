namespace RiwiMusic.Class;

public class Ticket
{
    public int idTicket { get; set; }
    public string nameConcertTicket {get; set;}
    public DateTime dateConcertTicket { get; set; }
    public int idClientTicket {get; set;}
    public string nameClientTicket {get; set;}
    public DateTime dateBuyTicket {get; set;}
    public double priceTicket {get; set;}

    public Ticket()
    {
        
    }

    public void menuTicket(Dictionary<int, Ticket>  tickets)
    {
        bool returnMenuTicket = true;
        while (returnMenuTicket)
        {
            
        Console.WriteLine("     1. Registrar compra de tiquete \n C    2. Listar tiquetes vendidos\n     3. Editar compra\n     4. Eliminar compra\n     5. Salir");
        int optionMenuClient =  Convert.ToInt32(Console.ReadLine());
        switch (optionMenuClient)
        {
            case 1:
                registerTicket(tickets);
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


    public void registerTicket(Dictionary<int, Ticket>  tickets)
    {
        Console.WriteLine("Ingrese el nombre del cliente: ");
        string nameClient = Console.ReadLine();
        Console.WriteLine("Ingrese el numero de identidficacion del cliente: ");
        int idClient = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese la edad del cliente: ");
        int ageClient =  Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el numero de telefono del cliente: ");
        int cellPhoneClient = Convert.ToInt32(Console.ReadLine());

        Client newUserClient = new Client
        {
            nameClient = nameClient,
            idClient = idClient,
            ageClient = ageClient,
            cellPhoneClient = cellPhoneClient
        };
        clients.Add(idClient, newUserClient);
    }

    public void viewTicket(Dictionary<int, Ticket>  tickets)
    {   Console.WriteLine("DATOS  DEL CLIENTE");
        Console.WriteLine("------------------------------");
        foreach (KeyValuePair<int, Client> client in clients)
        {
            Console.WriteLine($" Nombre: {client.Value.nameClient} \n Documento: {client.Value.idClient} \n Edad: {client.Value.ageClient} \n numero: {client.Value.cellPhoneClient} ");
            Console.WriteLine("------------------------------");

        }
    }

    public void updateTicket(Dictionary<int, Ticket>  tickets)
    {
        Console.WriteLine("Ingrese el id del cliente que quiere editar: ");
        int idToUpdate = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese que desea editar: \n 1. Nombre \n 2. id\n 3. edad \n 4. numero de telefono");
        int updateData = Convert.ToInt32(Console.ReadLine());
        switch (updateData) 
        {
            case 1:
                Console.WriteLine("Ingrese el nuevo nombre del cliente: ");
                string newName = Console.ReadLine();
                clients[idToUpdate].nameClient = newName;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Cliente actualizado con exito ");
                Console.WriteLine("----------------------------------------");

                break;
            case 2:
                Console.WriteLine("Ingrese el nuevo id del cliente: ");
                int newId = Convert.ToInt32(Console.ReadLine());
                clients[idToUpdate].idClient = newId;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Cliente actualizado con exito ");
                Console.WriteLine("----------------------------------------");

                break;
            case 3:
                Console.WriteLine("Ingrese la nueva edad del cliente: ");
                int newAge = Convert.ToInt32(Console.ReadLine());
                clients[idToUpdate].ageClient = newAge;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Cliente actualizado con exito ");
                Console.WriteLine("----------------------------------------");

                break;
            case 4:
                Console.WriteLine("Ingrese el nuevo numero del cliente: ");
                int newNumber = Convert.ToInt32(Console.ReadLine());
                clients[idToUpdate].cellPhoneClient = newNumber;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Cliente actualizado con exito ");
                Console.WriteLine("----------------------------------------");

                break;
        }
    }

    public void deleteTicket(Dictionary<int, Ticket>  tickets)
    {
        Console.WriteLine("Ingrese el id del cliente que desea eliminar: ");
        int idToDelete = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Seguro que quiere eliminar a: " + clients[idToDelete].nameClient + " si/no");
        string secureDeleteClient = Console.ReadLine();
        if (secureDeleteClient == "si")
        {
            clients.Remove(idToDelete);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Cliente eliminado con exito ");
            Console.WriteLine("----------------------------------------");
            
        }
    }
}