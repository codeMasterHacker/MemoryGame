using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TileGameControllerScript : MonoBehaviour
{
    private const float DISTANCE = 125.0f;
    private Vector3[] positions;
    public Button[] buttons;
    private Button invisibleTile;
    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        invisibleTile = buttons[8];

        positions = new Vector3[9];
        for (int i = 0; i < 9; i++)
            positions[i] = buttons[i].transform.position;

        int j, temp;
        int[] indices = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        for (int i = indices.Length - 1; i > 0; i--)
        {
            j = Random.Range(0, i + 1);
            temp = indices[i];
            indices[i] = indices[j];
            indices[j] = temp;
        }

        for (int i = 0; i < 9; i++)
            buttons[i].transform.position = positions[indices[i]];
    }

    // Update is called once per frame
    void Update()
    {
        if (SolvedPuzzle())
        {
            winPanel.SetActive(true);

            for (int i = 0; i < 9; i++)
                buttons[i].interactable = false;
        }
    }

    public void Button1()
    {
        SwitchTile(buttons[0]);
        print("Button 1");
    }

    public void Button2()
    {
        SwitchTile(buttons[1]);
        print("Button 2");
    }

    public void Button3()
    {
        SwitchTile(buttons[2]);
        print("Button 3");
    }

    public void Button4()
    {
        SwitchTile(buttons[3]);
        print("Button 4");
    }

    public void Button5()
    {
        SwitchTile(buttons[4]);
        print("Button 5");
    }

    public void Button6()
    {
        SwitchTile(buttons[5]);
        print("Button 6");
    }

    public void Button7()
    {
        SwitchTile(buttons[6]);
        print("Button 7");
    }

    public void Button8()
    {
        SwitchTile(buttons[7]);
        print("Button 8");
    }

    public void Button9()
    {
        print(buttons[8].transform.position);
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    private bool SolvedPuzzle()
    {
        for (int i = 0; i < 9; i++)
        {
            if (buttons[i].transform.position != positions[i])
                return false;
        }

        return true;
    }

    private void SwitchTile(Button tile)
    {
        bool canMoveUp = false;
        bool canMoveDown = false;
        bool canMoveRight = false;
        bool canMoveLeft = false;

        float x = tile.transform.localPosition.x - invisibleTile.transform.localPosition.x;
        float y = tile.transform.localPosition.y - invisibleTile.transform.localPosition.y;

        Vector3 temp;

        if (tile.transform.localPosition.x == invisibleTile.transform.localPosition.x)
        {
            if (y == (-1 * DISTANCE))
                canMoveUp = true;
            else if (y == DISTANCE)
                canMoveDown = true;

            if (canMoveUp || canMoveDown)
            {
                temp = tile.transform.localPosition;
                tile.transform.localPosition = invisibleTile.transform.localPosition;
                invisibleTile.transform.localPosition = temp;
            }
        }
        else if (tile.transform.localPosition.y == invisibleTile.transform.localPosition.y)
        {
            if (x == DISTANCE)
                canMoveRight = true;
            else if (x == (-1 * DISTANCE))
                canMoveLeft = true;

            if (canMoveRight || canMoveLeft)
            {
                temp = tile.transform.localPosition;
                tile.transform.localPosition = invisibleTile.transform.localPosition;
                invisibleTile.transform.localPosition = temp;
            }
        }
    }
}
