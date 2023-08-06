using UnityEngine;
using UnityEngine.Rendering;

public class StaticSortingY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var spriteRender = GetComponent<SortingGroup>();
        spriteRender.sortingOrder = transform.GetSortingOrder();
    }
}
