using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    private void OnDisable()
    {
        DialogLogicLevel2.SetDialogEnding(3, 0);
    }
}
