using System;
using UniRx;
public abstract class StatefulScriptableObjectValueBase<T> :
ScriptableValue<T>, IObservable<T>
{
    private ReactiveProperty<T> _innerDataSource = new
    ReactiveProperty<T>();
    public new void SetValue(T value)
    {
        base.SetValue(value);
        _innerDataSource.Value = value;
    }
    public IDisposable Subscribe(IObserver<T> observer) =>
    _innerDataSource.Subscribe(observer);
}