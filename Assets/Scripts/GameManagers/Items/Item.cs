using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string m_name;
    public Sprite image;

    public bool Equals(Item other)
    {
        if(other == null) return false;
        else return this.id == other.id;
    }

    public virtual void Use()
    {
        // Does nothing here (see subclasses)
        return;
    }
}
