namespace APBD2.Classes;

public class CoolContainer : Conteiner
{
    
    public int Id;
    public string PossibleProduct;
    public double Temperature;

    public CoolContainer(int height, int massConteiner, int depth, int maxLoad, string possibleProduct, double temperature) : base(height, massConteiner, depth, maxLoad)
    {
        PossibleProduct = possibleProduct;
        Temperature = temperature;
        Id = _nextId++;
        SerialNumber = $"KON-C-{Id}";
    }
    
    public void Load(int mass, double maxTemperature, string product)
    {
        try
        {
            if (mass > MaxLoad)
            {
                throw new OverflowException("Masa ładunku jest więjsza niż pojemność danego kontenera");
            }
            if (Temperature < maxTemperature && PossibleProduct == product)
            {
                MassLoad += mass;
            }
            else
            {
                throw new Exception($"Kontener {SerialNumber} nie może prazechowywac dany ładunek");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
    
    public override string ToString()
    {
        return $"{SerialNumber} (massLoad={MassLoad}, height={Height}, massContainer={MassContainer}, depth={Depth}, maxLoad={MaxLoad} , possibleProduct={PossibleProduct}, temperature={Temperature})";
    }
    
}