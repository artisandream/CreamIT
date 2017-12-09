using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class LetterGamePiece : GamePiece, 
    IBeginDragHandler, 
    IDragHandler, 
    IEndDragHandler
{
    [SerializeField] private float _moveSpeed = 0.75f;
    private Vector3 _startPosition;
    [HideInInspector] public bool IsMatched = false;
    [HideInInspector] public EmptyLetterGamePiece LastCollidedEmptyPiece = null;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null && eventData.dragging)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!AttachLetter())
        {
            this.gameObject.transform.DOMove(_startPosition, _moveSpeed);
        }
    }

    private bool AttachLetter()
    {
        if (LastCollidedEmptyPiece == null || LastCollidedEmptyPiece.CharecterValue != this.CharecterValue)
        {
            return false;
        }

        if (IsMatched)
        {
            return true;
        }

        IsMatched = true;

        this.transform.SetParent(LastCollidedEmptyPiece.gameObject.transform);

        return true;
    }

}