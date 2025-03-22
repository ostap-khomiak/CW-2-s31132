using APBD2.Interfaces;

namespace APBD2.Classes;

public abstract class Conteiner(int height, int massConteiner, int depth, int maxLoad) : IConteiner
{
    protected static int _nextId;
    
    public int MassLoad = 0;
    public int Height = height;
    public int MassContainer = massConteiner;
    public int Depth = depth;
    public int MaxLoad = maxLoad;
    public string SerialNumber { get; set; }

    public virtual void Load(int mass)
    {
        try
        {
            
            if (MassLoad + mass > MaxLoad )
            {
                throw new OverflowException("Masa ładunku jest więjsza niż pojemność danego kontenera");
            }

            MassLoad += mass;
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e);
        }
        
    }

    public virtual void Empty()
    {
        MassLoad = 0;
    }
}