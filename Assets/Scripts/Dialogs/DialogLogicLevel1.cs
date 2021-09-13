using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogLogicLevel1 : MonoBehaviour
{
    //№ NPC
    //0 - Р - Рабочий
    //1 - П - Протестующие
    //2 - М - Муравейник
    //3 - Ч - Веган
    //4 - В - Ворона
    //5 - Е - Еж

    [SerializeField] GameObject _worker;
    [SerializeField] GameObject _protesters;
    [SerializeField] GameObject _ant;
    [SerializeField] GameObject _vegan;
    [SerializeField] GameObject _crow;
    [SerializeField] GameObject _hedgehog;
    static GameObject worker;
    static GameObject protesters;
    static GameObject ant;
    static GameObject vegan;
    static GameObject crow;
    static GameObject hedgehog;

    [SerializeField] private GameObject _credits;
    [SerializeField] private GameObject _pause;
    static private GameObject credits;
    static private GameObject pause;

    static int[,] dialogsList =
    {
        //№ NPC / № диалога NPC/ был ли показан (0 - нет, 1 - да)
        {0, 0, 0},
        {0, 1, 0},
        {1, 0, 0},
        {2, 0, 0},
        {2, 1, 0},
        {2, 2, 0},
        {3, 0, 0},
        {3, 1, 0},
        {4, 0, 0},
        {4, 1, 0},
        {5, 0, 0},
        {5, 1, 0}
    };

    static int[] currentDialog = { 0, 0, 0, 0, -1, -1 };

    private void Start()
    {
        worker = _worker;
        protesters = _protesters;
        ant = _ant;
        vegan = _vegan;
        crow = _crow;
        hedgehog = _hedgehog;

        credits = _credits;
        pause = _pause;

        dialogsList = new int[,]
        {
            //№ NPC / № диалога NPC/ был ли показан (0 - нет, 1 - да)
            { 0, 0, 0},
            { 0, 1, 0},
            { 1, 0, 0},
            { 2, 0, 0},
            { 2, 1, 0},
            { 2, 2, 0},
            { 3, 0, 0},
            { 3, 1, 0},
            { 4, 0, 0},
            { 4, 1, 0},
            { 5, 0, 0},
            { 5, 1, 0}
        };
        currentDialog = new int[] { 0, 0, 0, 0, -1, -1 };
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

    private static void LogicProcessing()
    {
        //Если завершен Р0 и П0 - открывается М1
        if (dialogsList[0, 2] == 1 && dialogsList[2, 2] == 1 && currentDialog[2] == 0)
        {
            currentDialog[2] = 1;
        }
        //Если завершен М1 - открывается В0
        if (dialogsList[4, 2] == 1 && currentDialog[4] == -1)
        {
            currentDialog[4] = 0;
            crow.SetActive(true);
        }
        //Если завершен В0 - открывается Е0
        if (dialogsList[8, 2] == 1 && currentDialog[5] == -1)
        {
            currentDialog[5] = 0;
            hedgehog.SetActive(true);
        }
        //Если завершен Е0 - открывается Ч1
        if (dialogsList[10, 2] == 1 && currentDialog[3] == 0)
        {
            currentDialog[3] = 1;
        }
        //Если завершен Ч1 - открывается Е1
        if (dialogsList[7, 2] == 1 && currentDialog[5] == 0)
        {
            currentDialog[5] = 1;
        }
        //Если завершен Е1 - открывается В1
        if (dialogsList[11, 2] == 1 && currentDialog[4] == 0)
        {
            currentDialog[4] = 1;
        }
        //Если завершен В1 - открывается М2
        if (dialogsList[9, 2] == 1 && currentDialog[2] == 1)
        {
            currentDialog[2] = 2;
        }
        //Если завершен М2 - открывается Р1
        if (dialogsList[5, 2] == 1 && currentDialog[0] == 0)
        {
            currentDialog[0] = 1;
        }
        //Если завершен Р1 - переход к титрам и выход в главное меню
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
