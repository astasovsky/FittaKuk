using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DialogLogicLevel2 : MonoBehaviour
{
    //№ NPC
    //0 - П - Продавец
    //1 - А - Активист
    //2 - Г - Газетчик
    //3 - г - газета

    [SerializeField] private GameObject _bulletin;
    [SerializeField] private GameObject _credits;
    [SerializeField] private GameObject _pause;
    static private GameObject bulletin;
    static private GameObject credits;
    static private GameObject pause;

    static int[,] dialogsList;
    static int[] currentDialog;

    private void Start()
    {
        dialogsList = new int[,]
        {
            {0, 0, 0},
            {0, 1, 0},
            {1, 0, 0},
            {1, 1, 0},
            {1, 2, 0},
            {2, 0, 0},
            {3, 0, 0}
        };

        currentDialog = new int[] { 0, 0, 0, 0 };

        bulletin = _bulletin;
        credits = _credits;
        pause = _pause;
    }

    public static int GetCurrentDialogNumber(int NPSNumber)
    {
        return currentDialog[NPSNumber];
    }

    public static void SetDialogEnding(int NPSNumber, int currentDialogNumber)
    {
        for (int i = 0; i < dialogsList.GetUpperBound(0) + 1; i++)
        {
            if (dialogsList[i, 0] == NPSNumber && dialogsList[i, 1] == currentDialogNumber)
            {
                dialogsList[i, 2] = 1;
                break;
            }
        }
        LogicProcessing();
    }

    static private void LogicProcessing()
    {
        //Если г завершен (газета прочитана) - открывается А1
        if (dialogsList[6, 2] == 1 && currentDialog[1] == 0)
        {
            currentDialog[1] = 1;
        }
        //Если А1 завершен - открывается буллетень и А2
        if (dialogsList[3, 2] == 1 && currentDialog[1] == 1)
        {
            bulletin.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            currentDialog[1] = 2;
        }
        //Если А2 завершен - открывается П1
        if (dialogsList[4, 2] == 1 && currentDialog[0] == 0)
        {
            currentDialog[0] = 1;
        }

        if (dialogsList[1, 2] == 1)
        {
            pause.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerController.CanMove = false;
            credits.SetActive(true);
            pause.GetComponent<Pause>().DelayToMainMenu(25f);
        }
    }
}
