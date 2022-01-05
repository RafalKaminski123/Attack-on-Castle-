using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public abstract class BaseView : MonoBehaviour
    {
        public virtual void ShowView()
        {
            gameObject.SetActive(true);
        }

        public virtual void HideView()
        {
            gameObject.SetActive(false);
        }

        public void ScaleButtonUpAndDown(Button button)
        {
            var scaleSequence = DOTween.Sequence();
            scaleSequence
                .Append(button.transform.DOScale(1.1f, .2f))
                .Append(button.transform.DOScale(1f, .2f));
        }

        public void ScaleUp(Button button)
        {
            button.transform.DOScale(1.1f, .2f);
        }

        public void ScaleDown(Button button)
        {
            button.transform.DOScale(1f, .2f);
        }
    }
}
