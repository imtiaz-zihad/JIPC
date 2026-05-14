#include <iostream>
using namespace std;

/*
    Insertion Sort Algorithm --> builds the sorted array one item at a time by repeatedly taking the next item and inserting it into the correct position.
    - Time Complexity: O(n²) in the worst and average case, O(n) in the best case (when the array is already sorted).

    Important link: https://www.cpsacademy.io/blog/sorting-algorithms--beginner--interview-ready/insertion-sort-----

    Disadvantage:
    - Inefficient for large datasets.
    - Not suitable for sorting large lists as its average and worst-case time complexity is quite high compared to other sorting algorithms.

 */

void insertionSort(int arr[], int n)
{
    for (int i = 1; i < n; i++)
    {
        int key = arr[i];
        int j = i - 1;

        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j];
            j--;
        }

        arr[j + 1] = key;
    }
}

int main()
{
    int arr[] = {168, 155, 172, 150, 161};
    int n = 5;

    cout << "Before: ";
    for (int i = 0; i < n; i++)
        cout << arr[i] << " ";
    cout << endl;

    insertionSort(arr, n);

    cout << "After:  ";
    for (int i = 0; i < n; i++)
        cout << arr[i] << " ";
    cout << endl;

    return 0;
}

/*
  ╔═══════════════════════════════════════════════════════════════════╗
  ║                   Bubble    Selection    Insertion               ║
  ╠═══════════════════════════════════════════════════════════════════╣
  ║  Best Case        O(n)      O(n²)        O(n)                  ║
  ║  Worst Case       O(n²)     O(n²)        O(n²)                 ║
  ║  Average Case     O(n²)     O(n²)        O(n²)                 ║
  ║  Space            O(1)      O(1)         O(1)                  ║
  ║  Stable           ✅ হ্যাঁ    ❌ না        ✅ হ্যাঁ              ║
  ║  Swap/Shift       বেশি      কম (n-1)     মাঝামাঝি              ║
  ║  Nearly Sorted    ভালো      কোনো লাভ নেই  সবচেয়ে ভালো          ║
  ╚═══════════════════════════════════════════════════════════════════╝

  কোনটা কখন?
Nearly sorted data: Insertion Sort — while loop প্রায় চলে না, O(n) এর কাছাকাছি।

Swap minimize করতে হলে: Selection Sort — সর্বোচ্চ n-1 swap।

Stability দরকার হলে: Bubble Sort বা Insertion Sort — দুইটাই stable।

শেখার জন্য: Bubble Sort — concept সবচেয়ে সহজ।

সাধারণ ক্ষেত্রে (ছোট data): Insertion Sort — nearly sorted এ fastest, random data তেও Bubble Sort এর চেয়ে practically faster।


*/