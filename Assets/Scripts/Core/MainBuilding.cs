using UnityEngine;
using Abstractions;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;
using System.Collections;

public sealed class MainBuilding : MonoBehaviour, IUnitProducer, ISelectables
{
         public float Health => _health;
         public float MaxHealth => _maxHealth;
         public Sprite Icon => _icon;


        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health = 500;

    public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }

    public IEnumerator GetEnumerator()
    {
        return null;
    }
} 