/*
Basic of  Time Complexity 
1. https://www.cpsacademy.io/blog/complexity-analysis-a-to-z--interview-crack--secret-weapon

Easy to understand :

Pattern 1: একটা Loop → O(n) --> সোজা — loop n বার ঘোরে, তাই O(n)।
Pattern 2: একটা Loop এর ভিতরে আরেকটা Loop → O(n^2) --> nested loop, তাই O(n^2)।
Pattern 3: Loop Variable অর্ধেক হচ্ছে বা দ্বিগুণ হচ্ছে → O(log n) --> log n, কারণ প্রতি iteration এ search space অর্ধেক হচ্ছে।
Pattern 4: পাশাপাশি blocks → যোগ করো, বড়টা রাখো


 Cheatsheet:

 Complexity Ranking (ছোট → বড়)
 O(1) → O(log n) → O(√n) → O(n) → O(n log n) → O(n²) → O(n³) → O(2ⁿ) → O(n!)

 Code Pattern দেখো → Complexity বলো
 Single loop (0 to n)                    → O(n)
Nested loop (both 0 to n)              → O(n²)
Triple nested loop                      → O(n³)
Loop variable halving (i /= 2)         → O(log n)
Loop variable doubling (i *= 2)        → O(log n)
Two nested loops, inner is log         → O(n log n)
Recursion: 2 calls, size n-1           → O(2ⁿ)
Recursion: 1 call, size n/2            → O(log n)
Recursion: 2 calls, size n/2 + O(n)   → O(n log n)

Problem এ n দেখেই বুঝে যাও কী লাগবে
n ≤ 10-12       → O(n!) okay
n ≤ 20-25       → O(2ⁿ) okay
n ≤ 10⁴         → O(n²) okay
n ≤ 10⁵-10⁶    → O(n log n) দরকার
n ≤ 10⁸         → O(n) দরকার
n > 10⁸         → O(log n) বা O(1) দরকার
*/
#include <bits/stdc++.h>
using namespace std;

int main() {
    // O(n) time complexity
    int sum = 0, n = 100;
    for (int i = 0; i < n; i++) {
        sum += i;
    }
    cout << sum << endl;
    
    
    int target = 50;
    for (int i = 0; i < n; i++) {
        if (i == target) {
            cout << "Found target: " << target << endl;
            break;
        }
    }

    // O(1) time complexity
    int sum2 = (n * (n - 1)) / 2;
    cout << sum2 << endl;

    // O(n^2) time complexity
    int prod;
    vector<int> arr1 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    vector<int> arr2 = {11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
    for (int i = 0; i < arr1.size(); i++) {
        for (int j = 0; j < arr2.size(); j++) {
            prod = arr1[i] * arr2[j];
            cout << prod << " ";
        }
        cout << endl;
    }
    
    // divisors of a number
    // O(sqrt(n)) time complexity
    int num = 36;
    int numDivisors = 0;
    vector<int> divisors;
    cout << "Divisors of " << num << ": ";
    for (int i = 1; i * i <= num; i++) {
        if (num % i == 0) {
            cout << i << " ";
            numDivisors++;
            divisors.push_back(i);
            if (i != num / i) {
                cout << num / i << " ";
                numDivisors++;
                divisors.push_back(num / i);
            }
        }
    }
    cout << endl;

    cout << "Number of divisors: " << numDivisors << endl;

    sort(divisors.begin(), divisors.end());
    for(auto d : divisors) {
        cout << d << " ";
    }
    cout << endl;


    // O(n*k) time complexity
    int nn = 5, k = 3;
    // int arr3[n][k];
    // for (int i = 0; i < n; i++) {
    //     for (int j = 0; j < k; j++) {
    //         cin >> arr3[i][j];
    //     }
    // }

    int arr3[5][3] = {
        {1, 2, 3},
        {4, 5, 6},
        {7, 8, 9},
        {10, 11, 12},
        {13, 14, 15}
    };

    int total = 0;
    for (int i = 0; i < nn; i++) {
        for (int j = 0; j < k; j++) {
            total += arr3[i][j];
        }
    }
    cout << "Total: " << total << endl;


    // O(log n) time complexity
    vector<int> arr4 = {5, 2, 9, 1, 5, 6};
    sort(arr4.begin(), arr4.end());

    int target2 = 5;
    // raw way
    int left = 0, right = arr4.size() - 1;
    while (left <= right) {
        int mid = left + (right - left) / 2;
        if (arr4[mid] == target2) {
            cout << "Found target at index: " << mid << endl;
            break;
        } else if (arr4[mid] < target2) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    if (left > right) {
        cout << "Target not found: " << target2 << endl;
    }

    // using STL
    bool found = binary_search(arr4.begin(), arr4.end(), target2);
    if (found) {
        cout << "Found target: " << target2 << endl;
    } else {
        cout << "Target not found: " << target2 << endl;
    }
}