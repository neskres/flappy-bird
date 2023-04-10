using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PoolItem : MonoBehaviour, IPool
{
    [SerializeField] private int _maxItemsCount;
    [SerializeField] private Bonus _prefab;

    private Queue<Bonus> _availableObjects = new();
   
    [Inject]
    private DiContainer _container; 
    private void Awake()
    {
        InitPool();
    }

    private void InitPool()
    {
        for (int i = 0; i < _maxItemsCount; i++)
        {
            var item = _container 
                .InstantiatePrefabForComponent<Bonus>(_prefab, transform);
            item.gameObject.SetActive(false);
            _availableObjects.Enqueue(item);
        }
    }

    public Bonus GetItem()
    {
        if (_availableObjects.Count > 0)
        {
            var item = _availableObjects.Dequeue();
            item.gameObject.SetActive(true);
            return item;
        }
        else 
            return null;
    }
    
    public void ReturnItem(Bonus item)
    {
        item.gameObject.SetActive(false);
        _availableObjects.Enqueue(item);
    }
}

public interface IPool
{
    void ReturnItem(Bonus item);
}
