using Abstractions;
using System.Linq;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.UI;
=======
using UnityEngine.EventSystems;
>>>>>>> Stashed changes
using UserControlSystem;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
<<<<<<< Updated upstream
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

=======
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private Transform _groundTransform;
    private Plane _groundPlane;
    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
>>>>>>> Stashed changes
    }
private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            var hits = Physics.RaycastAll(ray);
            if (hits.Length == 0)
            {
                return;
            }
            var selectable = hits
            .Select(hit =>
            hit.collider.GetComponentInParent<ISelectables>())
            .Where(c => c != null)
            .FirstOrDefault();
            _selectedObject.SetValue(selectable);
        }
        else
        {
            if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction
                * enter);
            }
        }
    }
}