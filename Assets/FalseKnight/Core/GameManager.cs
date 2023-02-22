using System.Collections;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoSingleton<GameManager>
    {
        protected override void Awake()
        {
            base.Awake();
            //DontDestroyOnLoad(this);
        }

        public void FreezeTime(float duration)
        {
            Time.timeScale = 0.1f;
            StartCoroutine(UnfreezeTime(duration));
        }
        
        private IEnumerator UnfreezeTime(float duration)
        {
            yield return new WaitForSeconds(duration);
            Time.timeScale = 1.0f;
        }
    }
}