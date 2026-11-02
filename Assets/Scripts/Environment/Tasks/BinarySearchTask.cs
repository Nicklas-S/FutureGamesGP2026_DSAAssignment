using Environment.Tasks;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "Binary Search TaskData", menuName = "Scriptable Objects/Binary Search Task")]

public class BinarySearchTask : Task {

   TMP_InputField firstDate;
   TMP_InputField secondDate;
    string firstDateString;
    string secondDateString;
    private DateTime firstDateTime;
    private DateTime secondDateTime;
    public override void Execute() {
        firstDateString = firstDate.text;
        secondDateString = secondDate.text;
        firstDateTime = DateTime.ParseExact(firstDateString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        secondDateTime = DateTime.ParseExact(secondDateString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        throw new System.NotImplementedException();
    }


}
