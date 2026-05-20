#include <iostream>
#include <cstdlib>    // rand, srand এর জন্য
#include <ctime>      // time এর জন্য
using namespace std;

/*
    Quick Sort Algorithm --> a divide-and-conquer algorithm that picks an element as a pivot and partitions the given array around the picked pivot.
    - Time Complexity: O(n log n) average case, O(n²) worst case.

    Important link: https://www.cpsacademy.io/blog/sorting-algorithms--beginner--interview-ready/quick-sort-part-1--pivot--partition-

    Advantage:
    - In-place sorting (requires only O(log n) extra space).
    - Generally faster than Merge Sort in practice due to better cache locality.

    Disadvantage:
    - Worst-case time complexity is O(n²), which can occur when the pivot is always the smallest or largest element.
    - Not stable (does not preserve the relative order of equal elements).

 */


int partition(int arr[], int left, int right) {
    int randomIndex = left + rand() % (right - left + 1);
    swap(arr[randomIndex], arr[right]);

    int pivot = arr[right];
    int i = left - 1;

    for (int j = left; j < right; j++) {
        if (arr[j] < pivot) {
            i++;
            swap(arr[i], arr[j]);
        }
    }

    swap(arr[i + 1], arr[right]);
    return i + 1;
}

void quickSort(int arr[], int left, int right) {
    if (left >= right) return;
    int pivotIndex = partition(arr, left, right);
    quickSort(arr, left, pivotIndex - 1);
    quickSort(arr, pivotIndex + 1, right);
}

int main() {
    srand(time(0));    // একবার, program শুরুতে

    int arr[] = {1, 2, 3, 4, 5, 6, 7, 8};    // already sorted!
    int n = 8;

    cout << "Before: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    quickSort(arr, 0, n - 1);

    cout << "After:  ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    return 0;
}
