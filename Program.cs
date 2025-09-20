
using RiwiMusic.Class;


Dictionary<int, Client>  clients = new Dictionary<int, Client>();
Dictionary<int, Concert> concerts = new Dictionary<int, Concert>();

Console.WriteLine("Bienvenido a RiwiMusic\n------------------------------------\n Que deseas hacer? \n1. Gestionar conciertos\n2. Gestionar clientes\n3. Gestionar tiquetes" +
                  "\n4. Historial de compras \n5. Hacer una consulta avanzada ");
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
        break;
    case 4:
        break;
    case 5:
        break;
}
