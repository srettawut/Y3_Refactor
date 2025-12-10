using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public void ExecuteCommand(ICommand command)
    {
        if(command == null) return;
        command.Execute();
    }
}
