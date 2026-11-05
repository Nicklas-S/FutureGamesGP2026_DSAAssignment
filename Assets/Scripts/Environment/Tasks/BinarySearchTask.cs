using Environment;
using Environment.Tasks;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
[CreateAssetMenu(fileName = "Binary Search TaskData", menuName = "Scriptable Objects/Binary Search Task")]

public class BinarySearchTask : Task {

    [SerializeField] public string firstDate;
    [SerializeField] public string secondDate;
    [SerializeField] TextMeshPro EmployeeList;

    public override void Execute() {
        DateTime start = DateTime.Now;
        DateTime firstDateTime;
        DateTime secondDateTime;
        if(!DateTime.TryParseExact(firstDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out firstDateTime) ||
            !DateTime.TryParseExact(secondDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out secondDateTime)) {
            throw new ArgumentException("Invalid date format. Please use 'yyyy-MM-dd'.");
            
        }
       

        int lowIndex = BinarySearchLow(SortingTask.sortedEmployees, firstDateTime);
        int highIndex = BinarySearchHigh(SortingTask.sortedEmployees, secondDateTime);
        Debug.Log("low index = " + lowIndex);
        Debug.Log("High index = " + highIndex);
        for(int i = lowIndex; i <= highIndex; i++) {
            Employees employee = SortingTask.sortedEmployees[i];

            Debug.Log(
               "\nName: " + employee.name + "\n" +
               "ID: " + employee.employeeId + "\n" +
               "Has clearance: " + employee.hasEngineRoomClearance + "\n" +
               "Last entered: " + employee.lastEntranceInEngineRoom + "\n" +
               "Last exited: " + employee.lastExitFromEngineRoom);
        }
            DateTime stop = DateTime.Now;
            TimeSpan elapsedTime = stop - start;
            Debug.Log("Elapsed time: " + elapsedTime.TotalMilliseconds + " ms");
    }

    public int BinarySearchLow(Employees[] arrayToSearch, DateTime targetDate) {
        int low = 0;
        int high = arrayToSearch.Length - 1;
        int mid = low + (high - low) / 2;

        while(low <= high) {
            if(arrayToSearch[mid].Entered.Date < targetDate.Date) {
                low = mid + 1;
                mid = low + (high - low) / 2;
            }

            else if(arrayToSearch[mid].Entered.Date == targetDate.Date) {
                //return mid;
                
                if(mid > 0 && (arrayToSearch[mid - 1].Entered.Date == targetDate.Date)) {
                    mid--;
                }
                else {
                    return mid;
                }
            }

            else {
                high = mid - 1;
                mid = low + (high - low) / 2;
            }
        }

        return -1;
    }
    public int BinarySearchHigh(Employees[] arrayToSearch, DateTime targetDate) {
        int low = 0;
        int high = arrayToSearch.Length - 1;
        int mid = low + (high - low) / 2;

        while(low <= high) {
            if( arrayToSearch[mid].Entered.Date < targetDate.Date) {
                low = mid + 1;
                mid = low + (high - low) / 2;
            }

            else if(arrayToSearch[mid].Entered.Date == targetDate.Date) {
                //return mid;
                if(mid < arrayToSearch.Length - 1 && arrayToSearch[mid + 1].Entered.Date == targetDate.Date) {
                    mid++;
                }
                else {
                    return mid;
                }
            }

            else {
                high = mid - 1;
                mid = low + (high - low) / 2;
            }
        }

        return -1;
    }
}
