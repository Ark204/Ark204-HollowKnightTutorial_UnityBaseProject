using System;
using UnityEngine;

namespace Core.Combat
{
    public class Destructable : Hittable
    {
        public int health = 10;
        [Baracuda.Monitoring.Monitor]
        [Baracuda.Monitoring.MPosition(Baracuda.Monitoring.UIPosition.UpperRight)]
        [SerializeField] int m_currentHp;
        public int CurrentHealth { get=>m_currentHp; set { m_currentHp = value; } }
        public bool Invincible { get; set; }

        public event Action OnDestroyed;

        protected override void Awake()
        {
            base.Awake();
            CurrentHealth = health;
            Invincible = false;
        }

        public override void OnAttackHit(Vector2 position, Vector2 force, float damage)
        {
            if (CurrentHealth <= 0 || Invincible)
                return;

            DealDamage((int)damage);

            base.OnAttackHit(position, force, damage); // Order of this call is important
        }

        public void DealDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                OnDestroyed?.Invoke();
                Destroy(this.gameObject);
            }
        }

        public void Revive()
        {
            CurrentHealth = health;
        }
    }
}