using System;
using UnityEngine;

[Serializable]
public sealed class AtomicVariable<T>
{
    private event Action<T> onValueChanged;

    public T Value
    {
        get { return this.value; }
        set
        {
            this.value = value;
            this.onValueChanged?.Invoke(value);
        }
    }

    [SerializeField]
    private T value;

    public AtomicVariable()
    {
    }

    public AtomicVariable(T value)
    {
        this.value = value;
    }

    public void Subscribe(Action<T> action)
    {
        this.onValueChanged += action;
    }

    public void Unsubscribe(Action<T> action)
    {
        this.onValueChanged -= action;
    }
}