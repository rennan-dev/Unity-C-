using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraController : MonoBehaviour
{
    //1-posicionar o Camera Target na posição do jogador com um offset na altura
    //2-girar o Camera Target de acordo com o input do mouse

    public CharacterMovement CharacterMovement;
    public Transform CameraTarget;
    public float TargetHeight = 1f;
    public Vector2 XRotationRange = new Vector2(-70, 70);

    private Vector2 targetLook;

    public Quaternion LookRotation => CameraTarget.rotation;

    private void LateUpdate() {
        CameraTarget.transform.position = CharacterMovement.transform.position + Vector3.up * TargetHeight;
        CameraTarget.transform.rotation = Quaternion.Euler(targetLook.x, targetLook.y, 0);
    }
     

    public void IncrementLookRotation(Vector2 lookDelta) {
        targetLook += lookDelta;
        targetLook.x = Mathf.Clamp(targetLook.x, XRotationRange.x, XRotationRange.y);
    }
}
