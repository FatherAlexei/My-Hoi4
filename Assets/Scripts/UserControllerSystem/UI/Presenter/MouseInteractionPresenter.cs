using Abstractions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UserControlSystem;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private RaycastHit[] _hits;
    [SerializeField] private EventSystem _eventSystem;

    private void Update()
    {

            if (!Input.GetMouseButtonUp(0))
                return;

             if (_eventSystem.IsPointerOverGameObject())
            return;

              var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
            if (hits.Length == 0)
                return;

            var selectable = hits.Select(hit => hit.collider.GetComponentInParent<ISelectables>()).FirstOrDefault(c => c != null);



            _selectedObject.SetValue(selectable);
    }
}
