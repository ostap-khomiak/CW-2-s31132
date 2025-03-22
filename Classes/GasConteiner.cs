using APBD2.Interfaces;

namespace APBD2.Classes;

public class GasConteiner : Conteiner, IHazardNotifier
{
    
    public int Id;
    public int Pressure;


    public GasConteiner(int height, int massConteiner, int depth, int maxLoad, int pressure) : base(height, massConteiner, depth, maxLoad)
    {
        Pressure = pressure;
        Id = _nextId++;
        SerialNumber = $"KON-G-{Id}";
    }
    
    public override void Empty()
    {
        MassLoad = (int)(MassLoad * 0.05);
    }
    
    public void SendNotification()
    {
        Console.WriteLine($"Niebezpieczna sytuacja  {SerialNumber}");
    }
    
    public override string ToString()
    {
        return $"{SerialNumber} (massLoad={MassLoad}, height={Height}, massContainer={MassContainer}, depth={Depth}, maxLoad={MaxLoad} , pressure={Pressure})";
    }
    
}