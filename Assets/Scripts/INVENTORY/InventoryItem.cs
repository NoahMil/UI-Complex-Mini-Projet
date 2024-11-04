using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")] public Image image;
    
    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;
    private CanvasGroup _canvasGroup;
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform, 
            Input.mousePosition, 
            _canvas.worldCamera, 
            out var localPoint
        );
        
        transform.localPosition = localPoint; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;

        if (transform.parent == transform.root)
        {
            StartCoroutine(ReturnToOriginalPosition());  
        }
    }

    private IEnumerator ReturnToOriginalPosition()
    {
        transform.SetParent(parentAfterDrag); 
        Vector3 startPosition = transform.position;
        Vector3 endPosition = parentAfterDrag.position;
        float elapsedTime = 0f;
        float duration = 0.25f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;  
    }
}
