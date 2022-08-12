using DG.Tweening;
using UnityEngine;

namespace ISDevTemplate
{
    public static class CanvasGroupExtensions
    {
        public static void Disable(this CanvasGroup canvasGroup, float fadeDuration)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.DOFade(0f, fadeDuration);
        }

        public static void Enable(this CanvasGroup canvasGroup, float fadeDuration)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.DOFade(1f, fadeDuration);
        }
    }
}
