using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BerserkPixel.Prata
{
    public class DialogManager : MonoBehaviour
    {
        private static DialogManager _instance;
        public static DialogManager Instance => _instance;

        [SerializeField] private DialogRenderer dialogRenderer;

        /// <summary>
        /// Subscribe to this actions to listen and act according to this different events
        ///
        /// For example on another script you can do:
        ///
        /// private void Start()
        /// {
        ///     DialogManager.Instance.OnDialogStart += HandleDialogStart;
        ///     DialogManager.Instance.OnDialogEnds += HandleDialogEnd;
        ///     DialogManager.Instance.OnDialogCancelled += HandleDialogEnd;
        /// }
        ///
        /// private void OnDisable()
        /// {
        ///     DialogManager.Instance.OnDialogStart -= HandleDialogStart;
        ///     DialogManager.Instance.OnDialogEnds -= HandleDialogEnd;
        ///     DialogManager.Instance.OnDialogCancelled -= HandleDialogEnd;
        /// }
        ///
        /// private void HandleDialogStart()
        /// {
        ///     // Not allow player to move 
        /// }
        ///
        /// private void HandleDialogEnd()
        /// {
        ///     // Enable player movement
        /// }
        ///  
        /// </summary>
        public Action OnDialogStart = delegate { };

        public Action OnDialogEnds = delegate { };
        public Action OnDialogCancelled = delegate { };

        private bool isInConversation;
        //Tips
        [SerializeField]Text tipText;//提示文本
        [SerializeField] GameObject penal;//整个提示框
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        //public void BeginConversation(Interaction interaction)
        //{
        //    if (dialogRenderer != null)
        //        dialogRenderer.Show();

        //    if (!isInConversation)
        //    {
        //        isInConversation = true;
        //        OnDialogStart?.Invoke();
        //    }

        //    lastInteraction = interaction;

        //    ShowDialog();
        //}

        public void HideDialog()
        {
            if (dialogRenderer != null)
                dialogRenderer.Hide();

            //if (lastInteraction != null)
            //{
            //    if (lastInteraction.HasAnyDialogLeft())
            //    {
            //        OnDialogCancelled?.Invoke();
            //    }
            //    else
            //    {
            //        OnDialogEnds?.Invoke();
            //    }

            //    lastInteraction = null;
            //}

            //isInConversation = false;
        }
        public void ShowDialog(string text)
        {
            if (dialogRenderer != null)
                   dialogRenderer.Show();
             dialogRenderer.Render(text);
        }
        public void ShowDialog(IDialog dialog)
        {
            if (dialogRenderer != null)
                dialogRenderer.Show();
            dialogRenderer.Render(dialog);
        }

        private void ShowDialog()
        {
            //Dialog dialog = lastInteraction.GetCurrentDialog();

            //if (dialog == null)
            //{
            //    HideDialog();
            //    return;
            //}

            //if (dialogRenderer != null)
            //    dialogRenderer.Render(dialog);
        }

        public void MakeChoice(string dialogGuid, string choice)
        {
            //if (lastInteraction == null) return;

            //Dialog dialog = lastInteraction.GetCurrentDialogFromChoice(dialogGuid, choice);

            //if (dialog == null)
            //{
            //    HideDialog();
            //    return;
            //}

            //if (dialogRenderer != null)
            //    dialogRenderer.Render(dialog);
        }

        //---------------Tips-------------------
        public void ShowTips(string text)
        {
            tipText.text = text;//更换提示文本
            penal.SetActive(true);//开启框
        }
        public void HideTips()
        {
            penal.SetActive(false);//关闭框
        }
        public void ShowTips(string text,float time)
        {
            tipText.text = text;//更换提示文本
            penal.SetActive(true);//开启框
            StartCoroutine(HideEnum(time));
        }
         IEnumerator HideEnum(float time=1f)
        {
            yield return new WaitForSeconds(time);
            HideTips();
        }
    }

    [Serializable]
    public class Dialog
    {
        //public string guid;
        //public Character character;
        //public ActorsEmotions emotion;
        //public string text;
        //public bool isFacingRight = true;
        //public List<string> choices;

        //public Sprite GetImage() => character.GetFaceForEmotion(emotion);
    }
    public interface IDialog
    {
        public string authorName { get; }//对话者名称
        public string Text { get; }//对话内容
        public List<string> Choices { get; }
        public int Selected { set; }//选择的选项
        public bool isFacingRight { get; }//图片朝向
        public Sprite GetImage() ;//对话者图标
    }
}