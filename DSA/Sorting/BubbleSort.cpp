#include <iostream>
using namespace std;

/*
    Bubble Sort Algorithm --> compare between adjacent elements and swap if they are in the wrong order.
    - Repeatedly steps through the list, compares adjacent elements and swaps them if they are in the wrong order.
    - The pass through the list is repeated until the list is sorted.
    - Time Complexity: O(n²) in the worst and average case, O(n) in the best case (when the array is already sorted).

    Disadvantage:
    - Inefficient for large datasets.
    - Not suitable for sorting large lists as its average and worst-case time complexity is quite high compared to other sorting algorithms.

    Important link: https://www.cpsacademy.io/blog/sorting-algorithms--beginner--interview-ready/bubble-sort---compare----swap-

    Code — ✅ Optimized Version
সমাধান সহজ — একটা swapped নামে boolean variable রাখো। প্রতি pass এর শুরুতে false করো। কোনো swap হলে true করো। Pass শেষে যদি swapped এখনো false থাকে — মানে কোনো swap হয়নি — মানে array already sorted। থামো!

*/

void bubbleSort(int arr[], int n) {
    for (int pass = 0; pass < n - 1; pass++) {
        bool swapped = false;                      // ← এই line নতুন

        for (int i = 0; i < n - 1 - pass; i++) {
            if (arr[i] > arr[i + 1]) {
                swap(arr[i], arr[i + 1]);
                swapped = true;                    // ← swap হয়েছে!
            }
        }

        if (!swapped) break;                       // ← কোনো swap নেই? থামো!
    }
}

int main() {
    int arr[] = {168, 155, 172, 150, 161};
    int n = 5;

    cout << "Before: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    bubbleSort(arr, n);

    cout << "After:  ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    return 0;
}