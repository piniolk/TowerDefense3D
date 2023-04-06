using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour {

    [SerializeField] private Camera camera;
    private PlayerControlActions playerControlActions;

    private void Start() {
        playerControlActions = new PlayerControlActions();
        playerControlActions.Camera.Enable();
    }

    private void Update() {
        RotateCamera();
        ZoomCamera();
        MoveCamera();
    }

    private void RotateCamera() {
        if (playerControlActions.Camera.Rotation.ReadValue<float>() < 0) {
            float rotateSpeed = 75f;
            Vector3 rotation = new Vector3(0, 1, 0);
            transform.eulerAngles += rotation * rotateSpeed * Time.deltaTime;
        }
        if (playerControlActions.Camera.Rotation.ReadValue<float>() > 0) {
            float rotateSpeed = 50f;
            Vector3 rotation = new Vector3(0, -1, 0);
            transform.eulerAngles += rotation * rotateSpeed * Time.deltaTime;
        }
    }

    private void ZoomCamera() {
        float zoomSpeed = 300f;
        float minZoom = 80f;
        float maxZoom = 30f; 
        if (playerControlActions.Camera.Scroll.ReadValue<float>() < 0) {
            //zoom out
            camera.fieldOfView += Mathf.RoundToInt(Time.deltaTime * zoomSpeed);
        }
        if (playerControlActions.Camera.Scroll.ReadValue<float>() > 0) {
            //zoom in
            camera.fieldOfView -= Mathf.RoundToInt(Time.deltaTime * zoomSpeed);
        }
        if (camera.fieldOfView >= minZoom) {
            camera.fieldOfView = minZoom;
        }
        if (camera.fieldOfView <= maxZoom) {
            camera.fieldOfView = maxZoom;
        }
    }

    private void MoveCamera() {
        float moveSpeed = 10f;
        if (playerControlActions.Camera.YLevel.ReadValue<float>() < 0) {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }
        if (playerControlActions.Camera.YLevel.ReadValue<float>() > 0) {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
        if(gameObject.transform.position.y < -2f) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -2f, gameObject.transform.position.z);
        }
        if(gameObject.transform.position.y > 10f) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 10f, gameObject.transform.position.z);
        }
    }
}
