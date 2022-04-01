using UnityEngine;
using UnityEngine.EventSystems;

public class SkillActiveManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform rectTransform;
    public RectTransform Lever;
    [Range(10, 150)]
    public float leverRange;
    public CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        var inputPos = eventData.position - rectTransform.anchoredPosition;
        inputPos = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;

        Lever.anchoredPosition = inputPos;


    }

    public void OnDrag(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        inputPos = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;

        Lever.anchoredPosition = inputPos;


        canvasGroup.blocksRaycasts = false;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Lever.anchoredPosition = Vector2.zero;
        canvasGroup.blocksRaycasts = true;

    }


}
