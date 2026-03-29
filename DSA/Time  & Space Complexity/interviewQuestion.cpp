#include <bits/stdc++.h>
using namespace std;

/*
====================================================
📘 Time & Space Complexity Interview Questions
====================================================
*/

/*
🧠 1. What does Big-O notation represent?

✅ Answer:
The upper bound (worst-case) growth rate of an algorithm

📖 Explanation:
- Input size বাড়লে algorithm এর time/space কতটা বাড়ে তা বোঝায়
- Exact time না, growth pattern বোঝায়
- Resource usage কিভাবে scale করে সেটা বলে
*/

/*
🧠 2. Which of the following growth rates is the fastest (worst)?

✅ Answer:
O(2ⁿ)

📖 Explanation:
- O(n log n) < O(n²) < O(n³) < O(2ⁿ)
- Exponential growth সবচেয়ে খারাপ
- Example: n=20 → n³=8000, 2^n≈10^6
}


/*
🧠 3. If f(n) = 5n³ + 3n² + 7n + 10, what is Big-O?

✅ Answer:
O(n³)

📖 Explanation:
- Dominant term = n³
- Constants ignore করা হয়
- Lower order terms বাদ দেওয়া হয়
*/

/*
🧠 4. Which complexity class does O(1) belong to?

✅ Answer:
Constant

📖 Explanation:
- Input size বাড়লেও time change হয় না
- Example: array index access, stack push
*/

/*
🧠 5. Worst-case time complexity of Quicksort?

✅ Answer:
O(n²)

📖 Explanation:
- Pivot সবসময় smallest/largest হলে
- Partition imbalance হয়
- Recursion depth n, প্রতি level এ O(n) → O(n²)
*/

/*
🧠 6. What is the time complexity?

for(int i = 0; i < n; i++) {
    for(int j = 0; j < n; j++) {
        if(i == j) {
            for(int k = 0; k < n; k++) {
                sum++;
            }
        }
    }
}

✅ Answer:
O(n²)

📖 Explanation:
- Outer loops = n²
- k-loop runs only when i == j → n times
- Total: n² + n*n = O(n²)
*/

/*
🧠 7. What is the time complexity?

void func(int n) {
    if(n <= 0) return;
    func(n - 1);
    func(n - 1);
}

✅ Answer:
O(2ⁿ)

📖 Explanation:
- Each call makes 2 recursive calls
- Depth = n
- Total calls = 2ⁿ
*/

/*
🧠 8. What is the time complexity?

for(int i = 1; i <= n; i++) {
    for(int j = 1; j <= n; j += i) {
        sum++;
    }
}

✅ Answer:
O(n log n)

📖 Explanation:
- Inner loop runs n/i times
- Total: n/1 + n/2 + ... + n/n
- Harmonic series ≈ n log n
*/

/*
🧠 9. What is the time complexity?

for(int i = 0; i < n; i++) {
    for(int j = n; j > 0; j /= 2) {
        for(int k = 0; k < j; k++) {
            sum++;
        }
    }
}

✅ Answer:
O(n²)

📖 Explanation:
- Inner work: n + n/2 + n/4 + ... = 2n
- Outer loop runs n times
- Total = n * n = O(n²)
*/

/*
🧠 10. What is the space complexity of Fibonacci?

int fib(int n) {
    if(n <= 1) return n;
    return fib(n-1) + fib(n-2);
}

✅ Answer:
O(n)

📖 Explanation:
- Time complexity = O(2ⁿ)
- Space complexity = O(n)
- Call stack depth সর্বোচ্চ n
*/

/*
🧠 11. What is the time complexity?

for(int i = n; i >= 1; i /= 2) {
    for(int j = 1; j <= i; j++) {
        sum++;
    }
}

✅ Answer:
O(n)

📖 Explanation:
- i = n, n/2, n/4, ..., 1
- Work: n + n/2 + n/4 + ... = 2n
- Geometric series → O(n)
*/

/*
🧠 12. What is the time complexity?

void func(int n) {
    if(n <= 0) return;
    for(int i = 1; i <= n; i++) {
        func(n/2);
    }
}

✅ Answer:
O(n^(log n))

📖 Explanation:
- T(n) = n * T(n/2)
- Level wise multiply: n × (n/2) × (n/4) ...
- Total ≈ n^(log n)
*/

/*
🧠 13. What is the time complexity?

for(int i = 1; i <= n; i++) {
    for(int j = 1; j <= n; j++) {
        int k = 1;
        while(k <= i + j) {
            k *= 2;
        }
    }
}

✅ Answer:
O(n² log n)

📖 Explanation:
- while loop → log(i+j) ≈ log(n)
- Total = n² * log n
*/

/*
🧠 14. What is the time complexity?

for(int i = 1; i <= n; i++) {
    for(int j = 1; j <= n; j++) {
        int x = min(i, j);
        for(int k = 1; k <= x; k++) {
            sum++;
        }
    }
}

✅ Answer:
O(n³)

📖 Explanation:
- k runs min(i,j)
- Total ≈ n³/3 → O(n³)
*/

/*
🧠 15. What is the time complexity?

for(int i = 1; i <= n; i++) {
    for(int j = 1; j <= n; j += i) {
        for(int k = 1; k <= n; k += j) {
            count++;
        }
    }
}

✅ Answer:
O(n log² n)

📖 Explanation:
- Harmonic series twice
- Total ≈ n (log n)²
*/

/*
🧠 16. What is the time complexity?

T(n) = 2T(n-1) + O(n)

✅ Answer:
O(n · 2ⁿ)

📖 Explanation:
- Each node does O(n) work
- Total nodes ≈ 2ⁿ
*/

void q16(int n)
{
    if (n <= 1)
        return;
    q16(n - 1);
    for (int i = 0; i < n; i++)
        ;
    q16(n - 1);
}

/*
🧠 17. What is the time complexity?

    for(int i = 1; i <= n; i++) {
        int j = i;
        while(j % 2 == 0) {
            j /= 2;
            sum++;
        }
    }



✅ Answer:
O(n)

📖 Explanation:
- Counts how many times divisible by 2
- Total = n/2 + n/4 + ... = n
*/

/*
🧠 18. T(n) = 4T(n/2) + O(n^2)


void q(int n) {
    if(n <= 1) return;
    q(n/2);
    q(n/2);
    q(n/2);
    q(n/2);
    for(int i = 0; i < n*n; i++);
}

✅ Answer:
O(n² log n)

📖 Explanation:
- Master theorem case 2
*/

/*
🧠 19. T(n) = 2T(n/2) + O(n²)
void q(int n) {
    if(n <= 1) return;
    for(int i = 0; i < n; i++)
        for(int j = 0; j < n; j++);
    q(n/2);
    q(n/2);
}

✅ Answer:
O(n²)

📖 Explanation:
- Root dominates
*/

/*
🧠 20. What is the time complexity?


    int sum = 0;
    for (int i = 1; i <= n; i *= 2)
    {
        for (int j = 1; j <= n; j *= 2)
        {
            for (int k = 1; k <= n; k *= 2)
            {
                sum++;
            }
        }
    }


✅ Answer:
O(log³ n)

📖 Explanation:
- Each loop = log n
*/

/*
🧠 21. 4 nested dependent loops

    int sum = 0;
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= i; j++)
            for (int k = 1; k <= j; k++)
                for (int l = 1; l <= k; l++)
                    sum++;


✅ Answer:
O(n⁴)

📖 Explanation:
- Total ≈ n⁴/24
*/

/*
🧠 22. What is the time complexity?


    for (int i = 1; i <= n; i++)
    {
        int j = n;
        while (j >= 1)
        {
            j -= i;
        }
    }


✅ Answer:
O(n log n)

📖 Explanation:
- n/i pattern → harmonic series
*/

/*
🧠 23. T(n) = T(n/2) + T(n/3) + O(n)
void q(int n)
{
    if (n <= 1)
        return;
    q(n / 2);
    q(n / 3);
    for (int i = 0; i < n; i++)
        ;
}

✅ Answer:
O(n)

📖 Explanation:
- Geometric series ratio < 1
*/

/*
🧠 24. What is the time complexity?


    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n / i; j++)
        {
            for (int k = 1; k <= n / i; k++)
            {
                sum++;
            }
        }
    }


✅ Answer:
O(n²)

📖 Explanation:
- Σ(1/i²) converges
*/

/*
🧠 25. Tribonacci recursion
void q(int n)
{
    if (n <= 1)
        return;
    q(n - 1);
    q(n - 2);
    q(n - 3);
}

✅ Answer:
≈ O(1.84ⁿ)

📖 Explanation:
- Root of x³ = x² + x + 1 ≈ 1.84
*/

int main()
{

    return 0;
}