using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Player : MonoBehaviour
{
    private AudioController _audioController;
    private LayerMask _layerMaskEnemy;
    private Move _player;
    private Dog _dog;
    private bool nguaDon = true;
    private RaycastHit2D hit;

    private void Awake()
    {
        _audioController = FindObjectOfType<AudioController>();
        _player = FindObjectOfType<Move>();
        _dog = FindObjectOfType<Dog>();
        _layerMaskEnemy = LayerMask.GetMask("Enemy");
    }

    private void Update()
    {
        if (!_player.getIsAttack())
            nguaDon = true;
        checkEnemy_OpenSound();
    }

    private void checkEnemy_OpenSound()
    {
        hit = Physics2D.Raycast(transform.position+Vector3.up*0.5f, Vector2.right * (_player.getIsRight()?1:-1),2 ,_layerMaskEnemy);
        Debug.DrawLine(transform.position+Vector3.up*0.5f, transform.position+Vector3.up*0.5f + Vector3.right * 2, Color.blue);
        if (_player.getIsAttack()&&nguaDon)
        {
            nguaDon = false;
            attack();
        }
    }

    private void attack()
    {
        if (!hit.collider)
        {
            _audioController.Audio_MissAttack();
        }
        else
        {
            if (_dog.NumChoang < 2)
            {
                _audioController.Audio_Attack1();
                _dog.NumChoang++;
                Debug.Log("Hoc don");
            }
            else
            {
                _audioController.Audio_Attack2();
                _dog.NumChoang = 0;
                Debug.Log("Choang");
            }
        }
    }
}
