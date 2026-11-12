using Environment.Tasks;
using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
[CreateAssetMenu(fileName = "BinarySearchTreeTaskData", menuName = "Scriptable Objects/BinarySearchTreeTask")]
public class BinarySearchTreeTask : Task {
    [SerializeField] public string firstDate;
    [SerializeField] public string secondDate;
    private BinaryTree bst;
   
    public override void Execute() {
        DateTime firstDateTime;
        DateTime secondDateTime;

        if(!DateTime.TryParseExact(firstDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out firstDateTime) ||
            !DateTime.TryParseExact(secondDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out secondDateTime)) {
            throw new ArgumentException("Invalid date format. Please use 'yyyy-MM-dd'.");
        }
        Employees root = SortingTask.sortedEmployees[400];
        bst = new BinaryTree(root);

        for (int i = 0; i < SortingTask.sortedEmployees.Length; i++) {
            if(i == 401 ) continue;
            bst.Insert(SortingTask.sortedEmployees[i]);
        }
        bst.BFS(bst.root, firstDateTime, secondDateTime);
        //bst.DFS(bst.root, firstDateTime, secondDateTime);
       
    }
}
