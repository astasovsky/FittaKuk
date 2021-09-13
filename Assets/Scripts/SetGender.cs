using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class SwappableObjects
{
    public GameObject MaleObject;
    public GameObject FemaleObject;
}
public class SetGender : MonoBehaviour
{
    [SerializeField] private SwappableObjects[] swappableObjects;
    static public bool isMale{ get; private set; }

    public void SetGenderMale()
    {
        isMale = true;
        foreach (var item in swappableObjects)
        {
            item.MaleObject.SetActive(true);
            item.FemaleObject.SetActive(false);
        }
    }
    public void SetGenderFemale()
    {
        isMale = false;
        foreach (var item in swappableObjects)
        {
            item.MaleObject.SetActive(false);
            item.FemaleObject.SetActive(true);
        }
    }
}
