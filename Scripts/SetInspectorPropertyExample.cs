using UnityEngine;

public class SetInspectorPropertyExample : MonoBehaviour
{
    [SerializeField, SetInspectorProperty("MyProperty")]
    private int myProperty = 0;
    public int MyProperty
    {
        get
        {
            return myProperty;
        }
        set
        {
            myProperty = value;
            Debug.LogError("MyProperty property set is executed.");
        }
    }
}