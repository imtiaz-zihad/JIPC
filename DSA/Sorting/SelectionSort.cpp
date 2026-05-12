#include <iostream>
using namespace std;

/*
    Selection Sort Algorithm --> find the minimum element in the unsorted array and swap it with the first element.
    - Repeatedly finds the minimum element from the unsorted part and places it at the beginning.
    - Time Complexity: O(n²) in all cases (best, average, and worst).

    Important link: https://www.cpsacademy.io/blog/sorting-algorithms--beginner--interview-ready/selection-sort------

    Disadvantage:
    - Inefficient for large datasets.
    - Not suitable for sorting large lists as its time complexity is quite high compared to other sorting algorithms.
*/

void selectionSort(int arr[], int n) {
    for (int pos = 0; pos < n - 1; pos++) {
        int minIndex = pos;

        for (int j = pos + 1; j < n; j++) {
            if (arr[j] < arr[minIndex]) {
                minIndex = j;
            }
        }

        if (minIndex != pos) {
            swap(arr[pos], arr[minIndex]);
        }
    }
}

int main() {
    int arr[] = {168, 155, 172, 150, 161};
    int n = 5;

    cout << "Before: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    selectionSort(arr, n);

    cout << "After:  ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    return 0;
}