using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public const int columns = 5, rows = 2;

    public const float xspace = 4f, yspace = -5f;

    [SerializeField] MainImageScript startObject;
    [SerializeField] Sprite[] images;

    [SerializeField] GameObject welldonePanel;

    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    int score = 0, attempts = 0;
    [SerializeField] TextMesh scoreText, attemptsText;

    GeneralVoices generalVoices;
    bool cantplay = false;

    [SerializeField] PlayerInfo playerInfo;

    private void Awake()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
    }

    private int[] Randomizer(int[] locations)
    {
        int[] array = locations.Clone() as int[];

        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }

        return array;
    }

    private void Start()
    {
        

        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };
        locations = Randomizer(locations);

        Vector3 startPosition = startObject.transform.position;

        for (int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;
                if(i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScript;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (xspace * i) + startPosition.x;
                float positionY = (yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
        //vaihda tähän oikea ääni
        FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[10].Play();
    }

    private void Update()
    {
        if(score >= 5)
        {
            //vaihda tähän oikea ääni
            if(cantplay == false)
            {
                FindObjectOfType<PlayerInfo>().characterVoices[playerInfo.mySellectedCharacter].GetComponent<PlrVoices>().voices[13].Play();
                cantplay = true;
            }
            
            welldonePanel.SetActive(true);
        }
    }


    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    public void ImageOpen(MainImageScript startObject)
    {
        if(firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if(firstOpen.SpriteId == secondOpen.SpriteId)
        {
            score++;
            scoreText.text = "Score " + score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            firstOpen.Close();
            secondOpen.Close();
        }

        attempts++;
        attemptsText.text = "Attempts " + attempts;

        firstOpen = null;
        secondOpen = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene(7);
    }

}
