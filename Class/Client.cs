namespace RiwiMusic.Class;

public class Client
{
    public string nameClient {get; set;}
    public int idClient {get; set;}
    public int ageClient {get; set;}
    public int cellPhoneClient {get; set;}

    public Client()
    {
        
    }

    public void menuClient(Dictionary<int, Client>  clients)
    {
        bool returnMenuClient = true;
        while (returnMenuClient)
        {
            
        Console.WriteLine("     1. Registrar Cliente \n     2. Listar clientes\n     3. Editar clientes\n     4. Eliminar cliente\n     5. Salir");
        int optionMenuClient =  Convert.ToInt32(Console.ReadLine());
        switch (optionMenuClient)
        {
            case 1:
                registerClient(clients);
                break;
            case 2:
                viewClients(clients);
                break;
            case 3:
                updateClient(clients);
                break;
            case 4: 
                deleteClient(clients);
                break;
            case 5:
                returnMenuClient = false;
                break;
        }
        }
        
    }


    public void registerClient(Dictionary<int, Client>  clients)
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

    public void viewClients(Dictionary<int, Client> clients)
    {   Console.WriteLine("DATOS  DEL CLIENTE");
        Console.WriteLine("------------------------------");
        foreach (KeyValuePair<int, Client> client in clients)
        {
            Console.WriteLine($" Nombre: {client.Value.nameClient} \n Documento: {client.Value.idClient} \n Edad: {client.Value.ageClient} \n numero: {client.Value.cellPhoneClient} ");
            Console.WriteLine("------------------------------");

        }
    }

    public void updateClient(Dictionary<int, Client> clients)
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

    public void deleteClient(Dictionary<int, Client> clients)
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