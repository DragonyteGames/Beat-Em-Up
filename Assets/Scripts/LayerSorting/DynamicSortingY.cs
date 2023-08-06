using UnityEngine;
using UnityEngine.Rendering;

public class DynamicSortingY : MonoBehaviour
{
    private int baseSortingOrder;
    private float ySortingOffset;
    [SerializeField] private SortingGroup spriteRender;
    [SerializeField] private Transform sortingOffsetMarker;
    // Start is called before the first frame update
    void Start()
    {
        ySortingOffset = sortingOffsetMarker.position.y;
    }

    // Update is called once per frame
    void Update()
    {   
        baseSortingOrder = transform.GetSortingOrder();
        spriteRender.sortingOrder = baseSortingOrder;
    }

}
