using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;
public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;
    private float containerInitPosition;
    private float moveAmount;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;

        moveAmount = current.rectTransform.rect.height;
    }


    public void UpdateScore(int score)
        {
        // set the score to the masked text UI
        toUpdate.SetText($"{score}");
        // trigger the local move animation
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration);
        StartCoroutine(ResetCoinContainer(score));


    }

    private IEnumerator ResetCoinContainer(int score)
    {
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
    }
}
