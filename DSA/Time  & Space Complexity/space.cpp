/*
==============================
🚀 Space Complexity (C++ Guide)
==============================

Space Complexity = Program চলার সময় কত memory লাগছে

👉 Interview line:
"Time complexity tells how fast,
 Space complexity tells how much memory."

--------------------------------
🧠 Memory কোথায় লাগে?
--------------------------------

1. Variable → O(1)
2. Array / Vector → O(n)
3. 2D Array → O(n * m)
4. Recursion Stack → hidden cost

--------------------------------
🔥 Auxiliary vs Total Space
--------------------------------

Total Space = Input + Extra
Auxiliary Space = Only Extra (IMPORTANT)

👉 Interview তে Auxiliary Space জিজ্ঞেস করে

--------------------------------
✅ O(1) Space — Constant
--------------------------------
*/
#include <bits/stdc++.h>
using namespace std;

int sumArray(vector<int>& arr) {
    int sum = 0;   // only 1 variable
    for (int x : arr) {
        sum += x;
    }
    return sum;
}

/*
Space = O(1)
--------------------------------
✅ O(n) Space — Linear
--------------------------------
*/

vector<int> copyArray(vector<int>& arr) {
    vector<int> copy;
    for (int x : arr) {
        copy.push_back(x);
    }
    return copy;
}

/*
Space = O(n)

--------------------------------
✅ O(n^2) Space — 2D Array
--------------------------------
*/

vector<vector<int>> createMatrix(int n) {
    vector<vector<int>> matrix(n, vector<int>(n, 0));
    return matrix;
}

/*
Space = O(n^2)

--------------------------------
✅ O(log n) Space — Recursion
--------------------------------
*/

void binaryRec(int n) {
    if (n <= 1) return;
    binaryRec(n / 2);
}

/*
Depth = log n → Space = O(log n)

--------------------------------
✅ O(n) Space — Recursion
--------------------------------
*/

int factorial(int n) {
    if (n <= 1) return 1;
    return n * factorial(n - 1);
}

/*
Depth = n → Space = O(n)

--------------------------------
🔥 In-place vs Extra Memory
--------------------------------
*/

// ❌ Not in-place → O(n)
vector<int> reverseNew(vector<int>& arr) {
    vector<int> result;
    for (int i = arr.size() - 1; i >= 0; i--) {
        result.push_back(arr[i]);
    }
    return result;
}

// ✅ In-place → O(1)
void reverseInPlace(vector<int>& arr) {
    int left = 0, right = arr.size() - 1;
    while (left < right) {
        swap(arr[left], arr[right]);
        left++;
        right--;
    }
}

/*
--------------------------------
⚖️ Time vs Space Trade-off
--------------------------------
*/

// ❌ Less space, more time
// Time: O(n^2), Space: O(1)
bool hasDuplicateSlow(vector<int>& arr) {
    for (int i = 0; i < arr.size(); i++) {
        for (int j = i + 1; j < arr.size(); j++) {
            if (arr[i] == arr[j]) return true;
        }
    }
    return false;
}

// ✅ Less time, more space
// Time: O(n), Space: O(n)
bool hasDuplicateFast(vector<int>& arr) {
    unordered_set<int> st;
    for (int x : arr) {
        if (st.count(x)) return true;
        st.insert(x);
    }
    return false;
}

/*
--------------------------------
⚠️ Common Mistakes
--------------------------------

1. "Array নাই → O(1)" ❌
   → Recursion stack ভুলে গেছো

2. "2^n calls → O(2^n) space" ❌
   → Space = depth → O(n)

3. Input array count করো ❌
   → Auxiliary space এ input count হয় না

--------------------------------
🧾 Cheatsheet
--------------------------------

Variables            → O(1)
Array (n)            → O(n)
2D Array             → O(n^2)
HashMap / Set        → O(n)
Recursion depth n    → O(n)
Recursion depth logn → O(log n)

--------------------------------
🎯 Interview Answer Template
--------------------------------

"The auxiliary space complexity is O(n)
 due to the extra data structure.
 We can optimize it to O(1) using
 in-place approach but time will increase."

--------------------------------
🔥 Final Rule
--------------------------------

👉 Use memory to save time
👉 Or save memory and lose time
*/