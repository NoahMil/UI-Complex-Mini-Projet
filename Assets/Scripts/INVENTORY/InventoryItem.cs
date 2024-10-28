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

    public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
   //     image.raycastTarget = false;
        _canvasGroup.blocksRaycasts = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
//        image.raycastTarget = true;
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