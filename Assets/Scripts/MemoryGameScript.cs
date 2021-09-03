using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemoryGameScript : MonoBehaviour
{
    public Button[] cards;
    private Vector3[] positions;
    private Dictionary<Button, Button> cardPairs;
    private Button firstCard = null;
    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        int numCards = cards.Length;
        int halfNum = (numCards / 2);

        positions = new Vector3[numCards];
        for (int i = 0; i < numCards; i++)
            positions[i] = cards[i].transform.position;

        int[] indices = new int[numCards];
        for (int i = 0; i < numCards; i++)
            indices[i] = i;

        int j, temp;
        for (int i = indices.Length - 1; i > 0; i--)
        {
            j = Random.Range(0, i + 1);
            temp = indices[i];
            indices[i] = indices[j];
            indices[j] = temp;
        }

        for (int i = 0; i < numCards; i++)
            cards[i].transform.position = positions[indices[i]];

        for (int i = 0; i < numCards; i++)
            cards[i].GetComponent<Image>().color = Color.black;

        cardPairs = new Dictionary<Button, Button>();
        for (int i = 0; i < halfNum; i++)
        {
            cardPairs.Add(cards[i], cards[i + halfNum]);
            cardPairs.Add(cards[i + halfNum], cards[i]);
        }

        foreach (KeyValuePair<Button, Button> kvp in cardPairs)
            print("Key = " + kvp.Key.ToString() + " Value = " + kvp.Value.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (AllCardsFlipped())
        {
            winPanel.SetActive(true);
        }
    }

    public void Card1A()
    {
        FlipCard(cards[0]);
    }

    public void Card1B()
    {
        FlipCard(cards[0+(cards.Length / 2)]);
    }

    public void Card2A()
    {
        FlipCard(cards[1]);
    }

    public void Card2B()
    {
        FlipCard(cards[1+ (cards.Length / 2)]);
    }

    public void Card3A()
    {
        FlipCard(cards[2]);
    }

    public void Card3B()
    {
        FlipCard(cards[2+ (cards.Length / 2)]);
    }

    public void Card4A()
    {
        FlipCard(cards[3]);
    }

    public void Card4B()
    {
        FlipCard(cards[3+ (cards.Length / 2)]);
    }

    public void Card5A()
    {
        FlipCard(cards[4]);
    }

    public void Card5B()
    {
        FlipCard(cards[4+ (cards.Length / 2)]);
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void FlipCard(Button card)
    {
        Button secondCard;

        print(card.ToString());

        card.GetComponent<Image>().color = Color.white;

        if (firstCard == null) //card is the first card
        {
            firstCard = card;
            card.interactable = false;
        }
        else //card is the second card
        {
            secondCard = cardPairs[firstCard];

            if (secondCard.Equals(card)) //cards match
            {
                firstCard.interactable = false;
                card.interactable = false;
                firstCard = null;
            }
            else
                StartCoroutine(HideCards(card));
        }
    }

    private IEnumerator HideCards(Button secondCard)
    {
        firstCard.interactable = false;
        secondCard.interactable = false;

        yield return new WaitForSeconds(0.5f);

        firstCard.GetComponent<Image>().color = Color.black;
        secondCard.GetComponent<Image>().color = Color.black;

        firstCard.interactable = true;
        secondCard.interactable = true;

        firstCard = null;
    }

    private bool AllCardsFlipped()
    {
        int count = 0;

        for (int i = 0; i < cards.Length; i++)
        {
            if (!cards[i].interactable)
                count++;
        }

        if (count == cards.Length)
            return true;
        else
            return false;
    }
}
