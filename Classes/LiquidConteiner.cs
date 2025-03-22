using APBD2.Interfaces;

namespace APBD2.Classes;

public class LiquidConteiner :  Conteiner, IHazardNotifier
{
    public bool IsDangerous;
    public int Id;
    
    
    public LiquidConteiner(int height, int massConteiner, int depth, int maxLoad, bool isDangerous) : base(height, massConteiner, depth, maxLoad)
    {
        IsDangerous = isDangerous;
        Id = _nextId++;
        SerialNumber = $"KON-L-{Id}";
    }

    public void Load(int mass)
    {
        if ((IsDangerous && mass > MaxLoad * 0.5) || (!IsDangerous && mass > MaxLoad * 0.9))
        {
            SendNotification();
        }
        else
        {
            MassLoad += mass;
        }
    }
    
    public void SendNotification()
    {
        Console.WriteLine($"Niebezpieczna sytuacja:  {SerialNumber}");
    }
    
    public override string ToString()
    {
        return $"{SerialNumber} (massLoad={MassLoad}, height={Height}, massContainer={MassContainer}, depth={Depth}, maxLoad={MaxLoad}, isDangerous={IsDangerous})";
    }
    
}