using UnityEngine;

public class SetInspectorPropertyAttribute : PropertyAttribute
{
    public string Name { get; private set; }
    public bool IsDirty { get; set; }

    public SetInspectorPropertyAttribute(string name)
    {
        this.Name = name;
    }
}