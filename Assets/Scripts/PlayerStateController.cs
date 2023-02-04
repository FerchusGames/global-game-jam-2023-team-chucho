using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    [field: SerializeField] public bool IsHuman { get; private set; }

    private void Awake()
    {
        IsHuman = true;
    }

    public void ChangePlayerState()
    {
        IsHuman = !IsHuman;
    }
}