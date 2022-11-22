using System;
using UnityEngine;
using UnityEngine.UI;

public class TrainingController : MonoBehaviour
{
    public Button startButton, replayButton, topViewButton, backButton;
    public InputField answerText;
    public Text myReadingText, instructionsText;
    public Transform blockSpawn, tapeMeasureSpawn;
    public GameObject block, tapeMeasure, instructionsView;
    private GameObject blockObject, tapeMeasureObject;
    public Animator anim;
    public MeasureSelect measureSelect;
    private decimal  myMeasurements;
    private decimal CorrectMeasurements;
    private string message = "";

    private void Update()
    {
        Quit();
    }

    public void StartTask()
    {
        decimal randNum = (decimal)UnityEngine.Random.Range(0.5f, 2);
        CorrectMeasurements = randNum * 39.701m;
        CorrectMeasurements = Decimal.Round(CorrectMeasurements * 2) / 2;
        topViewButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        answerText.gameObject.SetActive(true);
        blockObject = Instantiate(block, blockSpawn.transform.position, blockSpawn.transform.rotation);
        blockObject.transform.localScale = new Vector3((float)randNum, 1, 1);
        //Debug.Log("Answer is :" + CorrectMeasurements);
        tapeMeasureObject = Instantiate(tapeMeasure, tapeMeasureSpawn.transform.position, tapeMeasureSpawn.transform.rotation);
        MeasureSelect.GetTip();
        message = "- Drag the tape measure around with the Left Mouse button and place it where needed.\n-  Right Click to drag out the tape. Line up the tip of the tape to the starting edge of the object.\n- Press the 'Top View' button for a better angle.";
        instructionsView.SetActive(true);
        Instructions(message);
    }

    public void TopView()
    {
        topViewButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
        anim.SetBool("Top", true);
        anim.SetBool("Norm", false);
        message = "- Click on part of the yellow tape where you feel is the closest to the edge of the object.\n- Input the measurements in the Input Field.\n- Press Enter when you are ready.";
        Instructions(message);
    }
    public void NormalView()
    {
        topViewButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        anim.SetBool("Top", false);
        anim.SetBool("Norm", true);
        message = "Drag The tape measure around with the Left Mouse button and place it where needed. Right Click to drag out the tape. Line up the tip of the tape to the starting edge of the object. Press the Top View button for a better angle.";

    }

    public void SubmittedReading()
    {
        if(answerText.text != "")
        {
            myMeasurements = decimal.Parse(answerText.text);
            Instructions(message = "");
            if (myMeasurements == CorrectMeasurements)
            {
                myReadingText.text = "Your measurements of " + answerText.text + " inches was correct!";
                myReadingText.color = Color.green;
            }
            else
            {
                myReadingText.text = "Your measurements of " + answerText.text + " inches was not correct! \n The correct measurements were " + CorrectMeasurements.ToString() + " inches.";
                myReadingText.color = Color.red;

            }

            answerText.text = "";

            replayButton.gameObject.SetActive(true);
            answerText.gameObject.SetActive(false);
            instructionsView.SetActive(false);
            backButton.gameObject.SetActive(false);
            topViewButton.gameObject.SetActive(false);
            measureSelect.currentInches.SetActive(false);
        }

    }

    void Instructions(string instuctions)
    {
        instructionsText.text = instuctions;
    }

    public void ReplayTraining()
    {
        replayButton.gameObject.SetActive(false);    
        startButton.gameObject.SetActive(true);
        answerText.gameObject.SetActive(false);
        myReadingText.text = "";
        Destroy(blockObject);
        Destroy(tapeMeasureObject);
        NormalView();
        topViewButton.gameObject.SetActive(false);
        Instructions(message = "");
    }

    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
