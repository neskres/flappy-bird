using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    //[SerializeField] private AudioSource _flySoundEffect;
    //[SerializeField] private AudioSource _collectSoundEffect;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                //_flySoundEffect.Play();
                _rb.velocity = Vector2.up * _velocity;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<BonusCollision>(out var bonus))
        {
            Score.instance.UpdateScore(bonus.Score);
            Score.instance.ShowBonusName(bonus.Name);
            Score.instance.ShowBonusSprite(bonus.BonusSprite);
            //_collectSoundEffect.Play();
        }
    }
}
