using System;
using UniRx;
public abstract class StatelessScriptableObjectValueBase<T> : ScriptableValue<T>, IObservable<T>
{
    private Subject<T> _innerDataSource = new Subject<T>();
    public new void SetValue(T value)
    {
        base.SetValue(value);
        _innerDataSource.OnNext(value);
    }
    public IDisposable Subscribe(IObserver<T> observer) =>
    _innerDataSource.Subscribe(observer);
}
