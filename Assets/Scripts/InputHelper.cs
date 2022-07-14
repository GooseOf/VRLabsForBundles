
   using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
/// <summary>
/// Позволяет с помощью мыши имитировать тачи
/// </summary>
public class InputHelper : MonoBehaviour
{
    private static TouchCreator lastFakeTouch;
    private static TouchCreator copyFakeTouch;

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Клики мыши в виде тачей + тачи по экрану</returns>
    public static List<Touch> GetTouches()
    {
        List<Touch> touches = new List<Touch>();
        touches.AddRange(Input.touches);
#if UNITY_EDITOR
        if (lastFakeTouch == null) lastFakeTouch = new TouchCreator();
        if (Input.GetKey(KeyCode.B))
            if (copyFakeTouch == null) copyFakeTouch = new TouchCreator();
        if (Input.GetMouseButtonDown(0))
        {
            lastFakeTouch.phase = TouchPhase.Began;
            lastFakeTouch.deltaPosition = new Vector2(0, 0);
            lastFakeTouch.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            lastFakeTouch.fingerId = 0;

            if (Input.GetKey(KeyCode.B))
            {
                copyFakeTouch.phase = TouchPhase.Began;
                copyFakeTouch.deltaPosition = new Vector2(0, 0);
                copyFakeTouch.position = new Vector2(Screen.width / 2 - Input.mousePosition.x, Input.mousePosition.y);
                copyFakeTouch.fingerId = 1;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastFakeTouch.phase = TouchPhase.Ended;
            Vector2 newPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            lastFakeTouch.deltaPosition = newPosition - lastFakeTouch.position;
            lastFakeTouch.position = newPosition;
            lastFakeTouch.fingerId = 0;

            if (Input.GetKey(KeyCode.B))
            {
                copyFakeTouch.phase = TouchPhase.Ended;
                newPosition.x = Screen.width / 2 - newPosition.x;
                copyFakeTouch.deltaPosition = newPosition - copyFakeTouch.position;
                copyFakeTouch.position = newPosition;
                copyFakeTouch.fingerId = 1;

                copyFakeTouch = null;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            lastFakeTouch.phase = TouchPhase.Moved;
            Vector2 newPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            lastFakeTouch.deltaPosition = newPosition - lastFakeTouch.position;
            lastFakeTouch.position = newPosition;
            lastFakeTouch.fingerId = 0;

            if (Input.GetKey(KeyCode.B))
            {
                if (copyFakeTouch != null)
                {

                    copyFakeTouch.phase = TouchPhase.Moved;
                    newPosition.x = Screen.width / 2 - newPosition.x;
                    copyFakeTouch.deltaPosition = newPosition - copyFakeTouch.position;
                    copyFakeTouch.position = newPosition;
                    copyFakeTouch.fingerId = 1;
                }
            }
        }
        else
        {
            lastFakeTouch = null;
        }
        if (lastFakeTouch != null) touches.Add(lastFakeTouch.Create());
        if(Input.GetKey(KeyCode.B))
            if (copyFakeTouch != null) touches.Add(copyFakeTouch.Create());
#endif


        return touches;
    }

}

public class TouchCreator
{
    static Dictionary<string, FieldInfo> fields;

    object touch;

    public float deltaTime { get { return ((Touch)touch).deltaTime; } set { fields["m_TimeDelta"].SetValue(touch, value); } }
    public int tapCount { get { return ((Touch)touch).tapCount; } set { fields["m_TapCount"].SetValue(touch, value); } }
    public TouchPhase phase { get { return ((Touch)touch).phase; } set { fields["m_Phase"].SetValue(touch, value); } }
    public Vector2 deltaPosition { get { return ((Touch)touch).deltaPosition; } set { fields["m_PositionDelta"].SetValue(touch, value); } }
    public int fingerId { get { return ((Touch)touch).fingerId; } set { fields["m_FingerId"].SetValue(touch, value); } }
    public Vector2 position { get { return ((Touch)touch).position; } set { fields["m_Position"].SetValue(touch, value); } }
    public Vector2 rawPosition { get { return ((Touch)touch).rawPosition; } set { fields["m_RawPosition"].SetValue(touch, value); } }

    public Touch Create()
    {
        return (Touch)touch;
    }

    public TouchCreator()
    {
        touch = new Touch();
    }

    static TouchCreator()
    {
        fields = new Dictionary<string, FieldInfo>();
        foreach (var f in typeof(Touch).GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            fields.Add(f.Name, f);
            //Debug.Log("name: " + f.Name);
        }
    }
}

