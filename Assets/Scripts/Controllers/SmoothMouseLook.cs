/*
 * SmoothMouseLook.cs
 * Created by Michael Woodard -- www.michaelwoodard.net
 * Smooth Mouse Look - controls camera using mouse input can also rotate another game body
 * Also implements cursor lock functions
 * Licensed under the MIT license
 */
using UnityEngine;

[AddComponentMenu("Camera/Smooth Mouse Look")]
public class SmoothMouseLook : MonoBehaviour
{
    public bool cursorLock = true;
    public bool cameraLock = false;
    public int inverted = -1; // must be either 1 or -1
    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;
    public float pitchClamp = 80f;
    public float smooth = 3.0f;
    public GameObject character;

    Vector2 smoothMouse;
    Vector2 finalMouse;
    PlayerController player;

    private void OnEnable()
    {
        // Register with Globals -------------------
        Globals.Instance.RegisterGlobal("MainCamera", gameObject);
        // ----------------------------------------
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked){
            float mouseX, mouseY;
            if (cameraLock)
            {
                mouseX = 0f;
                mouseY = 0f;
            }
            else
            {
                mouseX = Input.GetAxisRaw("Mouse X") * sensitivityX * smooth;
                mouseY = Input.GetAxisRaw("Mouse Y") * sensitivityY * smooth * inverted;
            }

            //smooth out our raw values and previous values using 1/smooth as the t
            smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseX, 1f / smooth);
            smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseY, 1f / smooth);

            //add the smoothed value to our current rotation value
            finalMouse += smoothMouse;

            finalMouse.y = Mathf.Clamp(finalMouse.y, -pitchClamp, pitchClamp);

            //if we have a body rotate the body on y axis and camera on x axis
            //otherwise apply both rotations to the camera
            if (character){
                transform.localRotation = Quaternion.AngleAxis(finalMouse.y, Vector3.right); //pitch
                character.transform.localRotation = Quaternion.AngleAxis(finalMouse.x, character.transform.up); //yaw
            }
            else
                transform.localRotation = Quaternion.Euler(finalMouse.y, finalMouse.x, 0);
        }
    }
    /// <summary>
    /// Unlocks the cursor to be inside the game window - Useful for in game windows
    /// </summary>
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    /// <summary>
    /// Locks the cursor - helpful if you need to lock the cursor back after unlocking it
    /// </summary>
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
