
namespace APBD2.Classes;

public class Ship
{
    private static int _nextId = 0;
    public int Id;
    public List<Conteiner> Conteiners;
    public int Speed;
    public int ConteinerLimit;
    public int MaxMass;

    
    public Ship(int speed, int maxMass, int conteinerLimit)
    {
        _nextId++;
        Id = _nextId;
        Speed = speed;
        MaxMass = maxMass;
        ConteinerLimit = conteinerLimit;
        Conteiners = new List<Conteiner>();
    }
    
    public override string ToString()
    {
        return $"Statek {Id} (speed={Speed}, maxContainerNum={ConteinerLimit}, maxWeight={MaxMass})";
    }
    
    public bool AddContainer(Conteiner container)
    {
        if (Conteiners.Count >= ConteinerLimit)
        {
            Console.WriteLine("Limit kontenerów");
            return false;
        }
        int currentWeight = 0;
        for (int i = 0; i < Conteiners.Count; i++)
        {
            currentWeight += Conteiners[i].MassContainer + Conteiners[i].MassLoad;
        }
        if (currentWeight + container.MassContainer + container.MassLoad > MaxMass)
        {
            Console.WriteLine("Zbyt wielka waga");
            return false;
        }
        Conteiners.Add(container);
        return true;
    }

    public void AddContainers(List<Conteiner> list)
    {
        foreach (var con in list)
        {
            AddContainer(con);
        }
    }
    
    public void RemoveContainer(string serialNumber)
    {
        for (int i = 0; i < Conteiners.Count; i++)
        {
            if (Conteiners[i].SerialNumber.Equals(serialNumber))
            {
                Conteiners.RemoveAt(i);
                return;
            }
        }
        Console.WriteLine("Nie ma takiego kontenera");
    }
    
    public void ReplaceContainer(string serialNumber, Conteiner newContainer)
    {
        for (int i = 0; i < Conteiners.Count; i++)
        {
            if (Conteiners[i].SerialNumber.Equals(serialNumber))
            {
                Conteiners[i] = newContainer;
                return;
            }
        }
        Console.WriteLine("Nie ma takiego kontenera");
    }
    
    public void TransferContainer(Ship targetShip, string serialNumber)
    {
        Conteiner container = null;
        int index = -1;
        for (int i = 0; i < Conteiners.Count; i++)
        {
            if (Conteiners[i].SerialNumber.Equals(serialNumber))
            {
                container = Conteiners[i];
                index = i;
                break;
            }
        }
        if (container == null)
        {
            Console.WriteLine("Nie ma takiego kontenera");
            return;
        }
        if (targetShip.AddContainer(container))
        {
            Conteiners.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Nie udało się");
        }
    }

    public void ShowContainers()
    {
        Console.WriteLine( $"{ToString()}  Kontenery: ");
        if (Conteiners.Count == 0)
        {
            Console.WriteLine("Brak");
        }
        else
        {
            for (int i = 0; i < Conteiners.Count; i++)
            {
                Console.WriteLine($" - {Conteiners[i]}");
            }
        }
    }
    
    
}