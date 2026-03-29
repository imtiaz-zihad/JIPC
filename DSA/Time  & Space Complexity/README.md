# 📘 Time & Space Complexity Interview Questions

---

## 🧠 1. What does Big-O notation represent?

### ✅ Answer:
**The upper bound (worst-case) growth rate of an algorithm**

### 📖 Explanation:
Big-O notation describes the **upper bound (worst-case)** growth rate of a function.

👉 Meaning:
- Input size বাড়লে algorithm এর time/space কতটা বাড়তে পারে সেটা বোঝায়  
- এটা exact time measure করে না  
- বরং বলে resource usage **কিভাবে scale করে**

### 📝 বাংলা ব্যাখ্যা:
Big-O notation একটা function এর growth rate এর **upper bound (worst-case)** বর্ণনা করে।

➡️ মানে:
- Input size বৃদ্ধির সাথে algorithm এর time/space সর্বোচ্চ কতটুকু যেতে পারে — সেটা বলে  
- এটা exact time measure করে না  
- বরং resource usage কিভাবে scale করে সেটা বোঝায়  

---

## 🧠 2. Which of the following growth rates is the fastest (worst)?

### ✅ Answer:
**O(2ⁿ)**

### 📖 Explanation:
Exponential growth O(2ⁿ) যেকোনো polynomial growth এর চেয়ে অনেক বেশি খারাপ।

👉 Order:
`O(n log n) < O(n²) < O(n³) < O(2ⁿ)`

👉 Example:
- n³ = 8,000  
- 2ⁿ = 1,048,576 (n = 20)

---

## 🧠 3. If f(n) = 5n³ + 3n² + 7n + 10, what is the Big-O complexity?

### ✅ Answer:
**O(n³)**

### 📖 Explanation:
- Constants এবং lower-order terms ignore করা হয়  
- Dominant term = **5n³**  
- Coefficient remove করা হয়  

👉 তাই: **O(n³)**

---

## 🧠 4. Which complexity class does O(1) belong to?

### ✅ Answer:
**Constant**

### 📖 Explanation:
O(1) মানে constant time complexity।

👉 Example:
- Array index access  
- Stack push  

---

## 🧠 5. What is the worst-case time complexity of Quicksort?

### ✅ Answer:
**O(n²)**

### 📖 Explanation:
Worst case occurs when:
- Pivot সবসময় smallest বা largest হয়  
- Partition highly unbalanced হয়  

👉 Result:
- Recursion depth = n  
- প্রতি level এ কাজ = O(n)  

👉 Total = **O(n²)**

---

## 🧠 6. What is the time complexity?

```cpp
for(int i = 0; i < n; i++) {
    for(int j = 0; j < n; j++) {
        if(i == j) {
            for(int k = 0; k < n; k++) {
                sum++;
            }
        }
    }
}