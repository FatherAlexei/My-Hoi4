    using System.Linq;
using UnityEngine;


public class OutlineSelector : MonoBehaviour
{
    private bool _isSelectedCache;
    public void SetSelected(bool isSelected)
    {
        if (isSelected == _isSelectedCache)
        {
            return;
        }
       if (isSelected)
       {
           gameObject.AddComponent<Outline2>();
       }
       else
       {
          Destroy(GetComponent<Outline2>());
       }
    
        _isSelectedCache = isSelected;
    }
}
