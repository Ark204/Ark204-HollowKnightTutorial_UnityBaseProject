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
        //死亡特效
        [SerializeField] private GameObject deathParticles;
        //死亡掉落物
        [SerializeField] GameObject[] objects;
        [SerializeField] float amount; //Amount can only be used if objects is one item
        //生成物品
        public void InstantiateObjects()
        {
            GameObject iObject;

            //Instantiate the entire array of objects
            if (amount == 0)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    iObject = Instantiate(objects[i], transform.position, Quaternion.identity, null);
                    if (iObject.GetComponent<Ejector>() != null)
                    {
                        iObject.GetComponent<Ejector>().launchOnStart = true;
                    }
                }
            }

            //Instantiate a specific amount of the first object in the array
            else if (objects.Length != 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    iObject = Instantiate(objects[0], transform.position, Quaternion.identity, null);
                    if (iObject.GetComponent<Ejector>() != null)
                    {
                        iObject.GetComponent<Ejector>().launchOnStart = true;
                    }
                }

            }
        }

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
                OnDestroyed?.Invoke();//死亡事件触发
                deathParticles.SetActive(true);
                deathParticles.transform.parent = transform.parent;
                InstantiateObjects();
                Destroy(this.gameObject);//销毁自身
            }
        }

        public void Revive()
        {
            CurrentHealth = health;
        }
    }
}