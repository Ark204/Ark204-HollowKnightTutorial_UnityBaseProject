using BerserkPixel.Prata;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.BerserkPixel.Prata.Samples.Scripts
{
    public class TestDialogRenderer: DialogRenderer
    {
        [SerializeField] private GameObject container;
        [SerializeField] private Text authorText;
        [SerializeField] private Text dialogText;
        [SerializeField] private Image dialogLeftImage;
        [SerializeField] private Image dialogRightImage;
        [SerializeField] private Transform choicesContainer;
        [SerializeField] private GameObject choiceButtonPrefab;
        //[SerializeField] int index = -1;//选择对话框的选项
        
        public override void Show()
        {
            container.SetActive(true);
        }

        public override void Render(string text)
        {
            dialogText.text = text;
            //说话对象
            //authorText.text = dialog.character.characterName;

            //左右图片
            //if (dialog.isFacingRight)
            //{
            //    dialogLeftImage.enabled = true;
            //    dialogLeftImage.sprite = dialog.GetImage();
            //    dialogRightImage.enabled = false;
            //}
            //else
            //{
            //    dialogRightImage.enabled = true;
            //    dialogRightImage.sprite = dialog.GetImage();
            //    dialogLeftImage.enabled = false;
            //}

            //省略选择
            choicesContainer.gameObject.SetActive(false);
        }
        public override void Render(IDialog dialog)
        {
            dialogText.text = dialog.Text;
            if (dialog.Choices.Count > 1)
            {
                RemoveChoices();
                foreach (var choice in dialog.Choices)
                {
                    GameObject choiceButton = Instantiate(choiceButtonPrefab, choicesContainer);
                    choiceButton.GetComponentInChildren<Text>().text = choice;
                    choiceButton.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        dialog.Selected = dialog.Choices.IndexOf(choice);
                    });
                }
                choicesContainer.gameObject.SetActive(true);
                //移除当前选择对象
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
                //选中第一个选项为选择对象
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(choicesContainer.GetChild(0).gameObject);
            }
              else
              {
                   choicesContainer.gameObject.SetActive(false);
              }
        }
        public override void Render(Dialog dialog)
        {
            throw new System.NotImplementedException();
        }
        //public override void Render(Dialog dialog)
        //{
        //    dialogText.text = dialog.text;
        //    authorText.text = dialog.character.characterName;

        //    if (dialog.isFacingRight)
        //    {
        //        dialogLeftImage.enabled = true;
        //        dialogLeftImage.sprite = dialog.GetImage();
        //        dialogRightImage.enabled = false;
        //    }
        //    else
        //    {
        //        dialogRightImage.enabled = true;
        //        dialogRightImage.sprite = dialog.GetImage();
        //        dialogLeftImage.enabled = false;
        //    }

        //    if (dialog.choices.Count > 1)
        //    {
        //        RemoveChoices();
        //        foreach (var choice in dialog.choices)
        //        {
        //            GameObject choiceButton = Instantiate(choiceButtonPrefab, choicesContainer);
        //            choiceButton.GetComponentInChildren<Text>().text = choice;
        //            choiceButton.GetComponent<Button>().onClick.AddListener(() =>
        //            {
        //                DialogManager.Instance.MakeChoice(dialog.guid, choice);
        //            });
        //        }

        //        choicesContainer.gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        choicesContainer.gameObject.SetActive(false);
        //    }
        //}

        public override void Hide()
        {
            RemoveChoices();
            container.SetActive(false);
        }

        private void RemoveChoices()
        {
            if (choicesContainer.childCount > 0)
            {
                foreach (Transform child in choicesContainer)
                {
                    Destroy(child.gameObject);
                }
            }
        }

    }
}