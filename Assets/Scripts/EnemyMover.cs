using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _groundDetection;

    private bool _moovRight = true;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed", 1);
    }

    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        RaycastHit2D GroundInfo = Physics2D.Raycast(_groundDetection.position, Vector2.down, _distance);

        if (!GroundInfo.collider)
        {
            if (_moovRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _moovRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _moovRight = true;
            }
        }
    }
}
