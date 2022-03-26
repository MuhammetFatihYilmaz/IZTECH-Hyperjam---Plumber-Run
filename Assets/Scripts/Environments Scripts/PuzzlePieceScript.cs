using UnityEngine;

public class PuzzlePieceScript : MonoBehaviour
{
    [SerializeField] int possibleRotationsForPipeUpRight = 1;
    //
    int currentRotationZ;
    int[] rotations = { 0, 90, 180, 270 };
    int[] correctRotationZ;
    int rotationIndex = 0;
    bool isCorrect = false;

    void Start()
    {
        SaveCorrectPipeRotationOnStart();
        GenerateRandomPipeRotationOnStart();
    }


    private void OnMouseDown()
    {
        if (!isCorrect)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotations[rotationIndex]);
            currentRotationZ = rotations[rotationIndex];
            rotationIndex++;
            if (rotationIndex == 4)
                rotationIndex = 0;
            //
            CheckCorrectPipeRotation();
        }
    }

    private void SaveCorrectPipeRotationOnStart()
    {
        correctRotationZ = new int[possibleRotationsForPipeUpRight];
        currentRotationZ = (int)transform.eulerAngles.z;
        if (possibleRotationsForPipeUpRight == 1)
            correctRotationZ[0] = currentRotationZ;
        else
        {
            correctRotationZ[0] = currentRotationZ;
            correctRotationZ[1] = currentRotationZ + 180;
        }
    }

    private void GenerateRandomPipeRotationOnStart()
    {
        int randomRotationIndex = Random.Range(0, 4);
        currentRotationZ = rotations[randomRotationIndex];
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentRotationZ);
        if (possibleRotationsForPipeUpRight == 1)
        {
            if (currentRotationZ == correctRotationZ[0])
                GenerateRandomPipeRotationOnStart();
        }
        else
        {
            if (currentRotationZ == correctRotationZ[0] || currentRotationZ == correctRotationZ[1])
                GenerateRandomPipeRotationOnStart();
        }
    }

    private void CheckCorrectPipeRotation()
    {
        if (possibleRotationsForPipeUpRight == 1)
        {
            if (currentRotationZ == correctRotationZ[0] && gameObject.CompareTag("CorrectPiece"))
                FoundCorrectPipe();
        }
        else
        {
            if ((currentRotationZ == correctRotationZ[0] || currentRotationZ == correctRotationZ[1]) && gameObject.CompareTag("CorrectPiece"))
                FoundCorrectPipe();
        }

    }

    private void FoundCorrectPipe()
    {
        isCorrect = true;
        AudioManager.Instance.PlayCorrectPuzzlePieceSound();
        GameManager.Instance.DecreaseRequiredCorrectPuzzlePieceCount();
    }
}
