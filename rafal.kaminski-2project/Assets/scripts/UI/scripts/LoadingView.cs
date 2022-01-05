using System.Collections;
using TMPro;
using UnityEngine;

namespace SDA.UI
{
    public class LoadingView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI loadingText;

        public override void ShowView()
        {
            base.ShowView();
            StartCoroutine(AnimateText());
        }

        private IEnumerator AnimateText()
        {
            while (true)
            {
                loadingText.text = "LOADING";
                yield return new WaitForSeconds(.5f);
                loadingText.text = "LOADING.";
                yield return new WaitForSeconds(.5f);
                loadingText.text = "LOADING..";
                yield return new WaitForSeconds(.5f);
                loadingText.text = "LOADING...";
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}
