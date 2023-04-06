using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePosition : MonoBehaviour {
    
    public static MousePosition Instance { get; private set; }
    [SerializeField] private LayerMask placeableLayerMask;

    private void Awake() {
        Instance = this;
    }

    public bool TryGetWorldPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        return Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, placeableLayerMask);
    }

    public Vector3 GetWorldPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, placeableLayerMask); //mousePlaneLayerMask must be attached to an instance hence the awake method
        return raycastHit.point;
    }
}
