using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangmanGameController : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject lostPanel;
    public GameObject wordPanel;
    public GameObject letterText;
    public GameObject hangman;
    private int lettersFound = 0;
    private int hangmanPartIndex = 0;
    private int numHangmanParts = 0;
    public Button[] letterButtons;
    private char[] letters;
    private readonly string[] words = { "HELLO",
                                        "WORLD",
                                        "GOODBYE" };

    // Start is called before the first frame update
    void Start()
    {
        int randomPos = Random.Range(0, words.Length);
        letters = words[randomPos].ToCharArray();
        numHangmanParts = hangman.transform.childCount;

        GameObject charText;
        for (int i = 0; i < letters.Length; i++)
        {
            charText = Instantiate(letterText, wordPanel.transform);
            //charText.GetComponent<Text>().text = letters[i].ToString();
            charText.GetComponent<Text>().text = "_";
            charText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hangmanPartIndex == numHangmanParts)
        {
            lostPanel.SetActive(true);

            for (int i = 0; i < letterButtons.Length; i++)
                letterButtons[i].interactable = false;
        }

        if (lettersFound == letters.Length)
        {
            winPanel.SetActive(true);

            for (int i = 0; i < letterButtons.Length; i++)
                letterButtons[i].interactable = false;
        }
    }

    public void ButtonA()
    {
        letterButtons[0].interactable = false;
        SetLetterOrHangMan('A');
    }

    public void ButtonB()
    {
        letterButtons[1].interactable = false;
        SetLetterOrHangMan('B');
    }

    public void ButtonC()
    {
        letterButtons[2].interactable = false;
        SetLetterOrHangMan('C');
    }

    public void ButtonD()
    {
        letterButtons[3].interactable = false;
        SetLetterOrHangMan('D');
    }

    public void ButtonE()
    {
        letterButtons[4].interactable = false;
        SetLetterOrHangMan('E');
    }

    public void ButtonF()
    {
        letterButtons[5].interactable = false;
        SetLetterOrHangMan('F');
    }

    public void ButtonG()
    {
        letterButtons[6].interactable = false;
        SetLetterOrHangMan('G');
    }

    public void ButtonH()
    {
        letterButtons[7].interactable = false;
        SetLetterOrHangMan('H');
    }

    public void ButtonI()
    {
        letterButtons[8].interactable = false;
        SetLetterOrHangMan('I');
    }

    public void ButtonJ()
    {
        letterButtons[9].interactable = false;
        SetLetterOrHangMan('J');
    }

    public void ButtonK()
    {
        letterButtons[10].interactable = false;
        SetLetterOrHangMan('K');
    }

    public void ButtonL()
    {
        letterButtons[11].interactable = false;
        SetLetterOrHangMan('L');
    }

    public void ButtonM()
    {
        letterButtons[12].interactable = false;
        SetLetterOrHangMan('M');
    }

    public void ButtonN()
    {
        letterButtons[13].interactable = false;
        SetLetterOrHangMan('N');
    }

    public void ButtonO()
    {
        letterButtons[14].interactable = false;
        SetLetterOrHangMan('O');
    }

    public void ButtonP()
    {
        letterButtons[15].interactable = false;
        SetLetterOrHangMan('P');
    }

    public void ButtonQ()
    {
        letterButtons[16].interactable = false;
        SetLetterOrHangMan('Q');
    }

    public void ButtonR()
    {
        letterButtons[17].interactable = false;
        SetLetterOrHangMan('R');
    }

    public void ButtonS()
    {
        letterButtons[18].interactable = false;
        SetLetterOrHangMan('S');
    }

    public void ButtonT()
    {
        letterButtons[19].interactable = false;
        SetLetterOrHangMan('T');
    }

    public void ButtonU()
    {
        letterButtons[20].interactable = false;
        SetLetterOrHangMan('U');
    }

    public void ButtonV()
    {
        letterButtons[21].interactable = false;
        SetLetterOrHangMan('V');
    }

    public void ButtonW()
    {
        letterButtons[22].interactable = false;
        SetLetterOrHangMan('W');
    }

    public void ButtonX()
    {
        letterButtons[23].interactable = false;
        SetLetterOrHangMan('X');
    }

    public void ButtonY()
    {
        letterButtons[24].interactable = false;
        SetLetterOrHangMan('Y');
    }

    public void ButtonZ()
    {
        letterButtons[25].interactable = false;
        SetLetterOrHangMan('Z');
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void SetLetterOrHangMan(char letter)
    {
        bool found = false;
        GameObject hangmanPart, charText;

        for (int i = 0; i < letters.Length; i++)
        {
            if (letter == letters[i])
            {
                found = true;
                lettersFound++;
                charText = wordPanel.transform.GetChild(i).gameObject;
                charText.GetComponent<Text>().text = letter.ToString();
            }
        }

        if (!found)
        {
            hangmanPart = hangman.transform.GetChild(hangmanPartIndex).gameObject;
            hangmanPart.SetActive(true);
            hangmanPartIndex++;
        }
    }
}
