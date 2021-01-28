using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    private Rigidbody2D _player;

    private void Start()
    {
        _player = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyMover>(out EnemyMover enemyMover))
        {
            _player.constraints = RigidbodyConstraints2D.FreezePositionX;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
