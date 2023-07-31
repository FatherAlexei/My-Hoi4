using Abstractions;
using UnityEngine;

public class Chomper : MonoBehaviour, ISelectables, IAttackable, IDamageDealer, IAutomaticAttacker
{

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    public Transform PivotPoint => _pivot;

    public int Damage => _damage;
    [SerializeField] private int _damage = 25;

    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Transform _pivot;
    [SerializeField] private Sprite _icon;
    private float _health = 100;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommand;

    public float VisionRadius => _visionRadius;
    [SerializeField] private float _visionRadius = 8f;
    public void RecieveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }
        _health -= amount;
        if (_health <= 0)
        {
            _animator.SetTrigger("PlayDead");
            Invoke(nameof(destroy), 1f);
        }
    }

    private async void destroy()
    {
        await _stopCommand.ExecuteSpecificCommand(new StopCommand());
        Destroy(gameObject);
    }


}
