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
        //FreezeTime
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

        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.J)) PlayerPrefs.SetString("key", "设置");
        //    if (Input.GetKeyDown(KeyCode.K)) PlayerPrefs.DeleteKey("key");//删除
        //    if(Input.GetKeyDown(KeyCode.Alpha9)) { Debug.Log(PlayerPrefs.HasKey("key")); }
        //}
    }
}