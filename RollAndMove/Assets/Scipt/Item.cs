using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    UseBeforeRoll,        // this will use in the future
    UseImmediately      // this is Bonus or Fail sector
}

public enum ItemUseFor
{
    PlusOneTurn,
    PushBack3Block,

}

public class Item : MonoBehaviour
{
    #region Fields

    [SerializeField]
    ItemType type;
    public ItemType Type { get { return type; } private set { type = value; } }

    [SerializeField]
    ItemUseFor useFor;
    public ItemUseFor UseFor { get { return useFor; } private set { useFor = value; } }

    #endregion

    #region System Events
    // Start is called before the first frame update
    void Start()
    {
        type = ItemType.UseImmediately;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region My Events

    public void Init(Vector3 position, ItemType type, ItemUseFor useFor)
    {
        //Debug.Log(position);
        position.y += 0.5f;
        transform.position = position;
        this.type = type;
        this.useFor = useFor;
    }

    // link: https://stackoverflow.com/questions/16100/convert-a-string-to-an-enum-in-c-sharp
    public static T ParseEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    #endregion
}
