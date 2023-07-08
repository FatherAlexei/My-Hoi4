using Abstractions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UserControlSystem;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private RaycastHit[] _hits;

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
            return;

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0)
            return;

        foreach ( var hit in hits )
        {
            if (hit.collider.GetComponentInParent<ISelectables>() != null)
                hit.collider.gameObject.AddComponent<Outline2>();
        }

        var selectable = hits.Select(hit => hit.collider.GetComponentInParent<ISelectables>()).FirstOrDefault(c => c != null);


        _selectedObject.SetValue(selectable);

    }
}
