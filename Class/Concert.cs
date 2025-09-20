namespace RiwiMusic.Class;

public class Concert
{
    public int idConcert {get; set; }
    public string nameConcert {get; set; }
    public string infoConcert {get; set; }
    public string cityConcert {get; set; }
    public int abalityConcert {get; set; }
    public DateTime dateConcert {get; set; }
    public double priceConcert {get; set; }

    public Concert()
    {
        
    }

    public void menuConcert( Dictionary<int, Concert> concerts)
    {
        bool returnMenuConcert = true;
        while (returnMenuConcert)
        {
            
            Console.WriteLine("Ingrese que desea hacer: \n 1.        Registar concierto \n 2.        listar conciertos \n 3.        Editar conciertos \n 4.        Eliminar conciertos \n 5.        salir");
            int optionMenuConcert = Convert.ToInt32(Console.ReadLine());
            switch (optionMenuConcert)
            {
                case 1:
                    registerConcert(concerts);
                    break;
                case 2:
                    viewConcerts(concerts);
                    break;
                case 3: 
                    editConcert(concerts);
                    break;
                case 4:
                    deleteConcert(concerts);
                    break;
                case 5:
                    returnMenuConcert = false;
                    break;
            }
        }
        
    }

    public void registerConcert( Dictionary<int, Concert> concerts)
    {
        bool returnRegisterConcert = true;
        while (returnRegisterConcert)
        {
            
            
            Console.WriteLine("Ingrese el nombre del concierto: ");
            string nameConcert = Console.ReadLine();
            Console.WriteLine("Ingrese la informacion del concierto: ");
            string infoConcert = Console.ReadLine();
            Console.WriteLine("Ingrese la ciudad del concierto: ");
            string cityConcert =  Console.ReadLine();
            Console.WriteLine("Ingrese el aforo del concierto: ");
            int abalityConcert =  Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha del concierto (ej: 2025-09-19):");
            string dateConcertStr = Console.ReadLine();

            if (!DateTime.TryParse(dateConcertStr, out DateTime dateConcert ))
            {
                Console.WriteLine("La fecha ingresada no es válida.");
            }
            else
            {
                
                Console.WriteLine("Ingrese el precio del concierto: ");
                double priceConcert =  Convert.ToDouble(Console.ReadLine());
                int newId = concerts.Count == 0 ? 1 : concerts.Keys.Max() + 1;
                Concert newConcert = new Concert
                {
                    idConcert = newId,
                    nameConcert = nameConcert,
                    infoConcert = infoConcert,
                    cityConcert = cityConcert,
                    abalityConcert = abalityConcert,
                    dateConcert = dateConcert,
                    priceConcert = priceConcert,
                };
                concerts.Add(newId, newConcert);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Concierto agregado con exito");
                Console.WriteLine("----------------------------------------");

                
                returnRegisterConcert = false;
            }
        }
        
        
    }

    public void viewConcerts(Dictionary<int, Concert> concerts)
    {
        Console.WriteLine("DATOS  DEL CLIENTE");
        Console.WriteLine("------------------------------");
        foreach (KeyValuePair<int, Concert> concert in concerts)
        {
            Console.WriteLine($" Id: {concert.Value.idConcert} \n Nombre: {concert.Value.nameConcert} \n Info: {concert.Value.infoConcert} \n ciudad: {concert.Value.cityConcert}" +
                              $"\n Aforo: {concert.Value.abalityConcert} \n Fecha: {concert.Value.dateConcert} \n Precio:  {concert.Value.priceConcert} ");
            Console.WriteLine("------------------------------");

        }
    }

    public void editConcert(Dictionary<int, Concert> concerts)
    {
        Console.Write("escriba el Id del concierto que desea editar: ");
        int idConcertEdit = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese que desea editar del concierto: \n1. Nombre del concierto \n2. Informacion del concierto \n3. Ciudad del concierto \n4. Aforo del concierto" +
                          "\n5. Fecha del concierto \n6. Precio del concierto ");;
        int optionEdit = Convert.ToInt32(Console.ReadLine());
        switch (optionEdit)
        {
            case 1:
                Console.WriteLine("Ingrese el nuevo nombre del concierto: ");
                string newNameConcert = Console.ReadLine();
                concerts[idConcertEdit].nameConcert = newNameConcert;
                Console.WriteLine("------------------------------");
                Console.WriteLine("concierto editado con exito");
                Console.WriteLine("------------------------------");
                
                break;
            case 2:
                Console.WriteLine("Ingrese la nueva informacion del concierto: ");
                string newInfoConcert = Console.ReadLine();
                concerts[idConcertEdit].infoConcert = newInfoConcert;
                Console.WriteLine("------------------------------");
                Console.WriteLine("concierto editado con exito");
                Console.WriteLine("------------------------------");
                break;
            case 3:
                Console.WriteLine("Ingrese la nueva ciudad del concierto: ");
                string newCityConcert = Console.ReadLine();
                concerts[idConcertEdit].cityConcert = newCityConcert;
                Console.WriteLine("------------------------------");
                Console.WriteLine("concierto editado con exito");
                Console.WriteLine("------------------------------");
                break;
            case 4:
                Console.WriteLine("Ingrese el nuevo aforo del concierto: ");
                int newAbalityConcert = Convert.ToInt32(Console.ReadLine());
                concerts[idConcertEdit].abalityConcert = newAbalityConcert;
                Console.WriteLine("------------------------------");
                Console.WriteLine("concierto editado con exito");
                Console.WriteLine("------------------------------");
                break;
            case 5:
                bool returnUpdateDateConcert = true;
                while (returnUpdateDateConcert)
                {
                    
                Console.WriteLine("Ingrese la nueva fecha del concierto: ");
                string newDateConcertStr = Console.ReadLine();
                
                if (!DateTime.TryParse(newDateConcertStr, out DateTime newDateConcert ))
                {
                    Console.WriteLine("La fecha ingresada no es válida.");
                }
                else
                {
                    concerts[idConcertEdit].dateConcert = newDateConcert;
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("concierto editado con exito");
                    Console.WriteLine("------------------------------");
                    returnUpdateDateConcert = false;
                }
                }
                break;
            case 6:
                Console.WriteLine("Ingrese el nuevo precio del concierto: ");
                int newPriceConcert = Convert.ToInt32(Console.ReadLine());
                concerts[idConcertEdit].priceConcert = newPriceConcert;
                Console.WriteLine("------------------------------");
                Console.WriteLine("concierto editado con exito");
                Console.WriteLine("------------------------------");
                break;
        }
    }

    public void deleteConcert(Dictionary<int, Concert> concerts)
    {
        Console.WriteLine("Ingrese el id del concerto que desea eliminar: ");
        int idToDelete = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Seguro que quieres eliminar este concierto: "+ concerts[idToDelete].nameConcert + " (si/no)");
        string secureDeleteConcert = Console.ReadLine();
        if (secureDeleteConcert == "si")
        {
            concerts.Remove(idToDelete);
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Concierto eliminado con exito");
            Console.WriteLine("------------------------------------------------------------------------------");
            
        }
        
    }
}