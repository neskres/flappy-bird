using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class Bonus : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private BonusCollision _collision;

    [Inject]
    private IPool _pool;
    private Tween _tween;
    private BonusData data;

    public void Init(BonusData _data)
    {
        data = _data;
        _collision.Score = _data.Score;
        _collision.Name = _data.Name;
        _collision.BonusSprite = _data.BonusSprite;
        _sr.sprite = data.BonusSprite;
        _tween = _sr.transform
            .DOLocalMoveY(_sr.transform.localPosition.y + .5f, 1f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    public string Name
    {
        get { return data.Name; }
        protected set { }
    }

    public int Score
    {
        get { return data.Score; }
        protected set { }
    }

    public IPool Pool { get => _pool; set => _pool = value; }

    private void OnDisable()
    {
        _tween.Kill();
    }

    private void FixedUpdate()
    {
        if (transform.position.x < -5)
        {
            _pool.ReturnItem(this);
        }
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _pool.ReturnItem(this); 
        }
    }
}
