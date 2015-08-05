using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    GameObject target = null;

    static GameManager _instance = null;

    public static GameManager Instance()
    {
        return _instance;
    }

    List<int> clickedCubeIdx = new List<int>();
    

    
    Cube[] cubes;

    List<Answer> answers = new List<Answer>();
    SHAPE[] shapes = new SHAPE[9];
    COLOR[] colores = new COLOR[9];
    BGCOLOR[] bgColores = new BGCOLOR[9];

    public List<Answer> GetAnswers()
    {
        return answers;
    }

    public List<int> GetClickedCubeList()
    {
        return clickedCubeIdx;
    }
    
    
    void Start()
    {
        Debug.Log("start");

        if(_instance == null)
        {
            _instance = this;
        }

        cubes = GetComponentsInChildren<Cube>();
        CubeSort();
        SearchAnswer();
       
    }

	void Update () {
	   
        if(true == Input.GetMouseButtonUp(0))
        {

            target = GetClickedObject();

            if (target != null)
            {

                if (LayerMask.NameToLayer("Clicked") == target.gameObject.layer)
                {

                    Cube chosenCube = target.gameObject.GetComponentInParent<Cube>();
                    
                    // current chosen cube should under 3
                    // current chosen cube is already clicked
                    if(chosenCube.IsClicked())
                    {
                        chosenCube.Click();

                        Debug.Log("chosenCube" + chosenCube.GetCubeIdx());
                        clickedCubeIdx.Remove(chosenCube.GetCubeIdx());
                        if(clickedCubeIdx.Contains(chosenCube.GetCubeIdx()))
                        {
                            Debug.Log("no delete");
                        }
                    }
                    else if(CheckCurClickedNum() < 3)
                    {
                        chosenCube.Click();
                        clickedCubeIdx.Add(chosenCube.GetCubeIdx());
                    }

                    clickedCubeIdx.Sort();
                }
            }

        }
	}

    public bool IsNextGame()
    {
        int usedAnswer = 0;
        for (int i = 0; i < answers.Count; ++i)
        {
            if (answers[i].isUsed)
                ++usedAnswer;
        }

        if(answers.Count == 0 || answers.Count == usedAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }

    public bool IsHap()
    {
        if(clickedCubeIdx.Count != 3)
        {
            return false;
        }

        for (int i = 0; i < answers.Count; ++i)
        {
            if (clickedCubeIdx[0] == answers[i].firstIdx)
                if (clickedCubeIdx[1] == answers[i].secondIdx)
                    if (clickedCubeIdx[2] == answers[i].thirdIdx)
                    {
                        if (answers[i].isUsed)
                        {
                            Debug.Log("used Answer");
                            return false;
                        }
                        else
                        {
                            Answer tmp = answers[i];
                            tmp.isUsed = true;
                            Debug.Log("right");
                            Debug.Log("bool Change : " + answers[i].isUsed);
                            return true;
                        }
                    }
                    else
                        continue;
                else
                    continue;
            else
                continue;
        }

        Debug.Log("wrong");
        return false;
    }

    int CheckCurClickedNum()
    {
        int curClickedCubeNum = 0;

        foreach (Cube child in cubes)
        {
            if (child.IsClicked())
            {
                ++curClickedCubeNum;
            }
        }

        return curClickedCubeNum;
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(true == (Physics.Raycast(ray, out hit, 1000.0f, 1 << 12)))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

    void CubeSort()
    {
        int curMinPos = 0;
        int curMinVal = 0;

        for(int pivot = 0; pivot < cubes.Length; ++pivot)
        {
            curMinPos = pivot;
            curMinVal = int.MaxValue;

            for(int cmpPos = pivot; cmpPos < cubes.Length; ++cmpPos)
            {
                if(cubes[cmpPos].GetCubeIdx() < curMinVal)
                {
                    curMinPos = cmpPos;
                    curMinVal = cubes[cmpPos].GetCubeIdx();
                }
            }
            SwapCube(pivot, curMinPos);
        }
    }

    void SwapCube(int fIdx, int sIdx)
    {
        Cube tmp = cubes[fIdx];
        cubes[fIdx] = cubes[sIdx];
        cubes[sIdx] = tmp;
    }


    public void ChangeCurCombi()
    {
        foreach(Cube cube in cubes)
        {
            cube.changeLevel();
        }
        
        SearchAnswer();
    }
   

    public void SearchAnswer()
    {
        answers.Clear();

        for (int i = 0; i < cubes.Length; ++i)
        {
            shapes[i] = cubes[i].GetShape();
            colores[i] = cubes[i].GetColor();
            bgColores[i] = cubes[i].GetBGColor();
        }

        SHAPE shapeCandidate;
        COLOR colorCandidate;
        BGCOLOR bgCandidate;


        for(int first = 0; first < cubes.Length - 2; ++first)
        {
            for(int second = first + 1; second < cubes.Length - 1; ++second)
            {
                if(shapes[first] == shapes[second])
                {
                    shapeCandidate = shapes[first];            
                }
                else
                {
                    if(shapes[first] == SHAPE.CIRCLE)
                        if(shapes[second] == SHAPE.TRIANGLE)
                            shapeCandidate = SHAPE.RECT;
                        else
                            shapeCandidate = SHAPE.TRIANGLE;
                    else if(shapes[first] == SHAPE.TRIANGLE)
                        if (shapes[second] == SHAPE.RECT)
                            shapeCandidate = SHAPE.CIRCLE;
                        else
                            shapeCandidate = SHAPE.RECT;
                    else
                        if (shapes[second] == SHAPE.CIRCLE)
                            shapeCandidate = SHAPE.TRIANGLE;
                        else
                            shapeCandidate = SHAPE.CIRCLE;
                }

                if(colores[first] == colores[second])
                {
                    colorCandidate = colores[first];
                }
                else
                {
                    if (colores[first] == COLOR.RED)
                        if (colores[second] == COLOR.BLUE)
                            colorCandidate = COLOR.YELLOW;
                        else
                            colorCandidate = COLOR.BLUE;
                    else if (colores[first] == COLOR.BLUE)
                        if (colores[second] == COLOR.YELLOW)
                            colorCandidate = COLOR.RED;
                        else
                            colorCandidate = COLOR.YELLOW;
                    else
                        if (colores[second] == COLOR.RED)
                            colorCandidate = COLOR.BLUE;
                        else
                            colorCandidate = COLOR.RED;
                }

                if(bgColores[first] == bgColores[second])
                {
                    bgCandidate = bgColores[first];
                }
                else
                {
                    if (bgColores[first] == BGCOLOR.WHITE)
                        if (bgColores[second] == BGCOLOR.GRAY)
                            bgCandidate = BGCOLOR.BLACK;
                        else
                            bgCandidate = BGCOLOR.GRAY;
                    else if (bgColores[first] == BGCOLOR.GRAY)
                        if (bgColores[second] == BGCOLOR.BLACK)
                            bgCandidate = BGCOLOR.WHITE;
                        else
                            bgCandidate = BGCOLOR.BLACK;
                    else
                        if (bgColores[second] == BGCOLOR.WHITE)
                            bgCandidate = BGCOLOR.GRAY;
                        else
                            bgCandidate = BGCOLOR.WHITE;
                }

                for(int third = second + 1; third < cubes.Length; ++third)
                {
                    if(shapeCandidate == shapes[third] && colorCandidate == colores[third]
                        && bgCandidate == bgColores[third])
                    {
                        Answer tmp = new Answer();
                        tmp.firstIdx = first;
                        tmp.secondIdx = second;
                        tmp.thirdIdx = third;
                        tmp.isUsed = false;
                        answers.Add(tmp);
                    }
                }
            }
        }

        Debug.Log("answer count = " + answers.Count);

        foreach (Answer answer in answers)
        {
            Debug.Log(answer.firstIdx + ", " + answer.secondIdx + ", " + answer.thirdIdx);
        }
    }


    //public bool cmpAnswerAndClickedCube()
    //{
    //    Debug.Log("answer count");
    //    if (answers.Count == 0)
    //    {
    //        Debug.Log("gyul");
    //        return false;
    //    }

    //    int usedAnswer = 0;

    //    for (int i = 0; i < answers.Count; ++i )
    //    {
    //        if(answers[i].isUsed)
    //        {
    //            ++usedAnswer;
    //        }
    //    }

    //    Debug.Log("before answercount");
    //    if(usedAnswer == answers.Count)
    //    {
    //        Debug.Log("All Answer Find");
    //        return false;
    //    }

    //    Debug.Log("clicked count");
    //    if (clickedCubeIdx.Count != 3) return false;

    //    Debug.Log("find answer");
    //    for (int i = 0; i < answers.Count; ++i)
    //    {
    //        if (clickedCubeIdx[0] == answers[i].firstIdx)
    //            if (clickedCubeIdx[1] == answers[i].secondIdx)
    //                if (clickedCubeIdx[2] == answers[i].thirdIdx)
    //                {
    //                    if (answers[i].isUsed)
    //                    {
    //                        Debug.Log("used Answer");
    //                        return false;
    //                    }
    //                    else
    //                    {
    //                        Answer tmp = answers[i];
    //                        tmp.isUsed = true;
    //                        Debug.Log("right");
    //                        Debug.Log("bool Change : " + answers[i].isUsed);
    //                        return true;
    //                    }
    //                }
    //                else
    //                    continue;
    //            else
    //                continue;
    //        else
    //            continue;
    //    }

    //    Debug.Log("wrong");
    //    return false;
    //}

    //public void CheckAnswer()
    //{
    //    Debug.Log("Check Answer Start");
    //    if(cmpAnswerAndClickedCube())
    //    {

    //    }
    //    else
    //    {
         
    //    }

    //    ClearClickedCube();
    //}

    public void ClearClickedCube()
    {
        for (int i = 0; i < clickedCubeIdx.Count; ++i)
        {
            cubes[clickedCubeIdx[i]].Click();
        }

        clickedCubeIdx.Clear();
    }
}
