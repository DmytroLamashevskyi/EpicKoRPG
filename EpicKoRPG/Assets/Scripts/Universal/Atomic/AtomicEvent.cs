using System; 

[Serializable]
public sealed class AtomicEvent<T>
{
    private event Action<T> onEvent;

    public void Invoke(T args)
    {
        this.onEvent?.Invoke(args);
    }

    public void Subscribe(Action<T> action)
    {
        this.onEvent += action;
    }

    public void Unsubscribe(Action<T> action)
    {
        this.onEvent -= action;
    }
}