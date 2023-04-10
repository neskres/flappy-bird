using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class BonusSpawner : MonoBehaviour
{
    [Inject] 
    [SerializeField] private PoolItem _pool;
    [SerializeField] private List<BonusData> _data;
    [SerializeField] private float _maxTime = 2.5f;
    [SerializeField] private float _heightRange = 0.5f;
    private System.Random _rnd = new System.Random();
    private float _timer;


    private void Update()
    {
        if (_timer > _maxTime)
        {
            Spawn();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void Spawn()
    {
        var data = _data[_rnd.Next(0, _data.Count)];

        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        var bonus = _pool.GetItem();
        bonus.transform.localPosition = spawnPos;
        bonus.Init(data);
    }
}
