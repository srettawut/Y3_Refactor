using System;

public static class EventManager
{
    //public static event Action OnEnergyCollected;
    //public static void RaiseEnergyCollected() => OnEnergyCollected?.Invoke();

    public static event Action<int> OnEnergyCollected;
    public static void RaiseEnergyCollected(int amount)
    {
        OnEnergyCollected?.Invoke(amount);
    }


    public static event Action OnStageCleared;
    public static void RaiseStageCleared() => OnStageCleared?.Invoke();
}
