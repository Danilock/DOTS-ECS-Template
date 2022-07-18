using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private bool _invulnerable, _isDead;

    [System.Flags] public enum TypeMonster { A, B, C}
    [SerializeField] private TypeMonster _monsterType;
    private void Awake()
    {
        _currentHealth = _startHealth;
    }

    public void DoDamage(int amount)
    {
        if (_isDead || _invulnerable)
            return;

        _currentHealth -= amount;

        if (_currentHealth <= 0f) gameObject.SetActive(false);
    }
}
