using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private PlayerController _playerController;

    private void Awake()
    {
        Instance = this;

        _playerController = FindObjectOfType<PlayerController>();
    }

    public void EnablePlayerController(bool enable)
    {
        _playerController.EnableMovement(enable);
    }
}
