using UnityEngine;

/// <summary>
/// Abstraction on simple touch/mouse input
/// </summary>
public class TouchInput: AppSystem<TouchInput>
{
    // positions are between (0, 0) = bottom left and (1, 1) = top right
    public Vector2 pointerStartPosition;
    public Vector2 pointerPosition;
    public Vector2 singleFramePositionChange;

    public bool pointerDown;
    public bool pointerUp;
    public bool pointerHeld;

    void Update()
    {
        Vector2 lastPointerPosition = pointerPosition;
        bool lastPointerHeld = pointerHeld;
        pointerHeld = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            pointerPosition = new Vector2(touch.position.x / Screen.width, touch.position.y / Screen.height);
            pointerHeld = true;
        }  
        if (Input.GetMouseButton(0)) {
            pointerPosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
            pointerHeld = true;
        }

        pointerDown = !lastPointerHeld && pointerHeld;
        pointerUp = lastPointerHeld && !pointerHeld;

        if (pointerDown) pointerStartPosition = pointerPosition;
        
        if (!pointerDown && pointerHeld) {
            singleFramePositionChange = pointerPosition - lastPointerPosition;
        } else {
            singleFramePositionChange = Vector2.zero;
        }
    }
}