#include <iostream>
using namespace std;

/*
    Merge Sort Algorithm --> a divide-and-conquer algorithm that divides the input array into two halves, calls itself for the two halves, and then merges the two sorted halves.
    - Time Complexity: O(n log n) in all cases (best, worst, and average).

    Important link: https://www.cpsacademy.io/blog/sorting-algorithms--beginner--interview-ready/merge-sort-part-1----sort--

    Disadvantage:
    - Requires additional space for the temporary arrays used during merging, making it less space-efficient than some other sorting algorithms like Quick Sort or Insertion Sort.

 */

void merge(int arr[], int left, int mid, int right) {
    int n1 = mid - left + 1;
    int n2 = right - mid;

    int L[n1], R[n2];

    for (int i = 0; i < n1; i++) L[i] = arr[left + i];
    for (int i = 0; i < n2; i++) R[i] = arr[mid + 1 + i];

    int i = 0, j = 0, k = left;

    while (i < n1 && j < n2) {
        if (L[i] <= R[j]) {
            arr[k] = L[i];
            i++;
        } else {
            arr[k] = R[j];
            j++;
        }
        k++;
    }

    while (i < n1) { arr[k] = L[i]; i++; k++; }
    while (j < n2) { arr[k] = R[j]; j++; k++; }
}

void mergeSort(int arr[], int left, int right) {
    if (left >= right) return;

    int mid = left + (right - left) / 2;

    mergeSort(arr, left, mid);
    mergeSort(arr, mid + 1, right);
    merge(arr, left, mid, right);
}

int main() {
    int arr[] = {38, 27, 43, 3, 9, 82, 10, 56};
    int n = 8;

    cout << "Before: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    mergeSort(arr, 0, n - 1);

    cout << "After:  ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    return 0;
}

/*
  ╔═══════════════════════════════════════════════════╗
  ║           Merge Sort এর Trade-off                  ║
  ╠═══════════════════════════════════════════════════╣
  ║                                                    ║
  ║  ✅ সময় কম:    O(n log n) — O(n²) এর চেয়ে      ║
  ║                 অনেক দ্রুত                         ║
  ║                                                    ║
  ║  ❌ Memory বেশি: O(n) extra space — merge করতে    ║
  ║                 আলাদা array লাগে                   ║
  ║                                                    ║
  ╚═══════════════════════════════════════════════════╝

    ╔══════════════════════════════════╗
  ║    Merge Sort Properties         ║
  ╠══════════════════════════════════╣
  ║  Stable:     ✅ হ্যাঁ            ║
  ║  In-Place:   ❌ না (O(n) extra)  ║
  ║  Best Case:  O(n log n)         ║
  ║  Worst Case: O(n log n)         ║
  ║  Space:      O(n)               ║
  ╚══════════════════════════════════╝
*/