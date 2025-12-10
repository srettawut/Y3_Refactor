public class PowerupCommand : ICommand
{
    private StatsController _reciever;
    private PowerupType _type;
    private float _duration;
    public PowerupCommand(StatsController r, PowerupType t, float d)
    {
        _reciever = r;
        _type = t;
        _duration = d;
    }

    public void Execute()
    {
        _reciever.ApplyPowerup(_type, _duration);
    }
}
