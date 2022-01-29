using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UpdateObjective : MonoBehaviour
{
    private List<string> taskList = new List<string>();
    private static int index = 0;
    private int length;

    public void loadTask(int day)
    {
        FileInfo file = new FileInfo("Assets\\TaskList\\day" + day + ".txt");
        StreamReader reader = file.OpenText();

        while (true)
        {
            string temp = reader.ReadLine();

            if (temp == null)
            {
                break;
            }

            taskList.Add(temp);
        }

        length = taskList.Count;
    }

    public void nextTask()
    {
        Debug.Log(taskList[index]);
        this.GetComponent<EditText>().setText(taskList[index]);
        index++;
    }
    
    void Start()
    {
        loadTask(1);
        nextTask();
    }
}
