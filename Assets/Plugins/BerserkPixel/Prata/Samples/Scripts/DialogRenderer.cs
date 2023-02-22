using UnityEngine;

namespace BerserkPixel.Prata
{
    public abstract class DialogRenderer : MonoBehaviour
    {
        public abstract void Show();

        public abstract void Render(string text);

        public abstract void Render(Dialog dialog);

        public abstract void Render(IDialog dialog);

        public abstract void Hide();
    }
}