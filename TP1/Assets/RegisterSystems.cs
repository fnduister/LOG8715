using System.Collections.Generic;

public class RegisterSystems
{
    public static List<ISystem> GetListOfSystems()
    {
        // determine order of systems to add
        var toRegister = new List<ISystem>();

        // Add your systems here
        
        toRegister.Add(new StartGame());
        toRegister.Add(new SaveState());
        toRegister.Add(new MoveEntity());
        toRegister.Add(new ColorManager());
        toRegister.Add(new RestoreState());

        return toRegister;
    }
}