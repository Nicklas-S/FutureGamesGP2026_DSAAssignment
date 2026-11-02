using Environment.Tasks;
using System;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "SortTaskData", menuName = "Scriptable Objects/SortingTask")]

public class SortingTask : Task {
    [SerializeField] EmployeeData employeeData;
    [SerializeField] TextAsset jsonFile;
    public Employees[] sortedEmployees;
    public override void Execute() {
        sortedEmployees = JsonUtility.FromJson<EmployeeArray>(jsonFile.text)?.employees;
        foreach(Employees employee in sortedEmployees) {
             employee.Entered = DateTime.ParseExact(employee.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
            employee.Exiting = DateTime.ParseExact(employee.lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
        }
        MergeSort(sortedEmployees, 0, sortedEmployees.Length - 1);
        foreach(Employees employee in sortedEmployees) {
            Debug.Log(
            "\nName: " + employee.name + "\n" +
            "ID: " + employee.employeeId + "\n" +
            "Has clearance: " + employee.hasEngineRoomClearance + "\n" +
            "Last entered: " + employee.lastEntranceInEngineRoom + "\n" +
            "Last exited: " + employee.lastExitFromEngineRoom);
        }
    }

    static void MergeSort(Employees[] ArrayToSort, int leftSide, int rightSide) {

        if(leftSide < rightSide) {
            int middleIndex = leftSide + ((rightSide - leftSide) / 2);
            MergeSort(ArrayToSort, leftSide, middleIndex);
            MergeSort(ArrayToSort, middleIndex + 1, rightSide);
            Merge(ArrayToSort, leftSide, middleIndex, rightSide);
        }
    }

    static void Merge(Employees[] arrayToMerge, int leftSide, int middleIndex, int rightSide) {

        int sizeLeftSide = middleIndex - leftSide + 1; //every index to the LEFT of the middle index, EXcluding the middle index
        int sizeRightSide = rightSide - (middleIndex + 1) + 1; //every index to the RIGHT of the middle index, INcluding the middle index

        Employees[] tempLeft = new Employees[sizeLeftSide];
        Employees[] tempRight = new Employees[sizeRightSide];
        int i;
        int j;

        for(i = 0; i < sizeLeftSide; i++) {
            tempLeft[i] = arrayToMerge[i + leftSide];
        }

        for(j = 0; j < sizeRightSide; j++) {
            tempRight[j] = arrayToMerge[j + middleIndex + 1];
        }
        i = 0;
        j = 0;
        int k = leftSide;

        while(i < sizeLeftSide && j < sizeRightSide) {
            if(tempLeft[i].Entered >= tempRight[j].Entered) {
                arrayToMerge[k] = tempLeft[i];
                i++;

            }
            else {
                arrayToMerge[k] = tempRight[j];
                j++;

            }
            k++;
        }

        while(i < sizeLeftSide) {
            arrayToMerge[k] = tempLeft[i];
            i++;
            k++;
        }

        while(j < sizeRightSide) {
            arrayToMerge[k] = tempRight[j];
            j++;
            k++;
        }
    }
}
