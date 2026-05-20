/*

Important link: https://www.cpsacademy.io/blog/sorting-algorithms--beginner--interview-ready/merge-sort--quick-sort--interview-patterns--use-cases

Sorting Interview Questions —> https://www.cpsacademy.io/blog/sorting-algorithms--beginner--interview-ready/sorting-interview-questions----


  ╔══════════════════════════════════════════════════════════════╗
  ║                                                              ║
  ║  Merge Sort কখন ভালো?                                        ║
  ║  ─────────────────                                          ║
  ║  ✅ Guaranteed O(n log n) দরকার                             ║
  ║  ✅ Stable sort দরকার (equal elements এর order preserve)   ║
  ║  ✅ LinkedList sort করতে হবে                                ║
  ║  ✅ External sorting (file disk এ, RAM এ fit করে না)       ║
  ║  ✅ Parallelization সহজ (divide-and-conquer)                ║
  ║                                                              ║
  ║  Quick Sort কখন ভালো?                                        ║
  ║  ─────────────────                                          ║
  ║  ✅ In-place sort দরকার (extra memory নেই)                 ║
  ║  ✅ Average case performance চাই (cache friendly)           ║
  ║  ✅ Array/random-access data                                 ║
  ║  ✅ Practical speed matter করে                              ║
  ║                                                              ║
  ╚══════════════════════════════════════════════════════════════╝
*/

/*

Interview এ Common প্রশ্ন ও উত্তর
Q1: Merge Sort vs Quick Sort — কোনটা ভালো?
❌ ভুল answer: "Quick Sort ভালো কারণ দ্রুত।"

✅ সঠিক answer: "Depends on the context. Merge Sort guaranteed O(n log n) আর stable, কিন্তু O(n) extra memory লাগে। Quick Sort average case এ faster practically, in-place, কিন্তু worst case O(n²) আর unstable। Memory constraint থাকলে Quick Sort, stability বা guarantee দরকার হলে Merge Sort।"

Q2: Quick Sort কেন practically Merge Sort এর চেয়ে দ্রুত?
In-place: Extra array allocation নেই, memory operation কম
Cache friendly: Swap operation CPU cache এ দ্রুত (sequential access pattern)
Constant factor ছোট: Merge Sort এ copy operation extra সময় নেয়
Q3: কেন Java Object sort এ TimSort কিন্তু primitive এ Quick Sort?
Object এর stability matter করে — দুইটা Object "equal" হলে সেগুলোর order distinguishable হতে পারে (ex: Person by age — same age এর দুইজন)
Primitive এ stability meaningless — দুইটা একই integer distinguishable না
Q4: O(n log n) এর চেয়ে দ্রুত sort করা যায়?
Comparison-based sorting এ না — theoretical lower bound O(n log n)। কিন্তু comparison ছাড়া (Counting Sort, Radix Sort) হ্যাঁ — O(n) possible (পরের পর্ব)।

Q5: Quick Sort এর worst case কখন হয় আর কীভাবে এড়াবে?
Already sorted/reverse sorted array + last/first element pivot = O(n²)। এড়ানোর উপায়:

Random pivot
Median-of-three pivot
Hybrid algorithm (IntroSort) — depth বেশি হলে Heap Sort এ switch
Q6: Linked List sort করতে কোনটা ব্যবহার করবে?
Merge Sort। কারণ:

LinkedList এ random access O(n), তাই Quick Sort এর partition expensive
Merge Sort এ sequential access যথেষ্ট
O(1) extra space এ possible (arrays এ O(n) লাগতো)
Q7: External sorting এ কোনটা?
Merge Sort। File RAM এ fit করে না — ছোট chunk RAM এ এনে sort করো, disk এ ফেরত দাও, পরে merge করো। Quick Sort এ in-place random access করতে হয় — disk এ expensive।




Interview Tips
১. Algorithm শুধু মুখস্থ করো না — intuition বুঝো। কোন step কেন হচ্ছে সেটা explain করতে পারতে হবে।

২. Edge cases জিজ্ঞেস করো:

Empty array?
Single element?
Duplicates?
Already sorted / reverse sorted?
Very large input?
৩. Trade-offs সবসময় mention করো: "এই solution O(n log n) time কিন্তু O(n) space। Space constraint থাকলে অন্য approach নেওয়া যায়।"

৪. Follow-up questions আশা করো:

"এটা কি stable?"
"Memory constraint থাকলে কী করবে?"
"আরো optimize করতে পারবে?"
"Parallelize করা যাবে?"
৫. Coding এর আগে approach explain করো। Interviewer তোমার চিন্তাভাবনা দেখতে চায়, শুধু code না।

তাহলে এতক্ষণে কী বুঝলাম?
১. Algorithm choice depends on context — Merge Sort stability+guarantee, Quick Sort speed+memory।

২. Merge Sort-based problems — Merge Two Arrays, Inversion Count, Sort Linked List, Merge K Lists। Merge step এ extra logic add করে অনেক problem solve করা যায়।

৩. Quick Sort-based problems — Kth Largest (Quickselect), Sort Colors (3-way partition)। Partition idea extend করে বিভিন্ন problem।

৪. Hybrid problems — অনেক real-world solution multiple sorting idea combine করে।

৫. Interview এ trade-offs mention করা important — কোনটা সবসময় best এটা ভুল mindset।
*/


/*
সব Algorithm এক নজরে — Master Reference
  ╔══════════════╦═════════╦═════════╦═════════╦═════════╦════════╦═══════════════╗
  ║  Algorithm   ║  Best   ║  Avg    ║  Worst  ║  Space  ║ Stable ║  Use Case    ║
  ╠══════════════╬═════════╬═════════╬═════════╬═════════╬════════╬═══════════════╣
  ║              ║         ║         ║         ║         ║        ║               ║
  ║ Bubble       ║  O(n)   ║  O(n²)  ║  O(n²)  ║  O(1)   ║   ✅   ║  শেখার জন্য  ║
  ║              ║         ║         ║         ║         ║        ║               ║
  ║ Selection    ║  O(n²)  ║  O(n²)  ║  O(n²)  ║  O(1)   ║   ❌   ║  Swap কম দরকার║
  ║              ║         ║         ║         ║         ║        ║               ║
  ║ Insertion    ║  O(n)   ║  O(n²)  ║  O(n²)  ║  O(1)   ║   ✅   ║  Small/nearly ║
  ║              ║         ║         ║         ║         ║        ║  sorted       ║
  ║              ║         ║         ║         ║         ║        ║               ║
  ║ Merge        ║ n log n ║ n log n ║ n log n ║  O(n)   ║   ✅   ║  Stability +  ║
  ║              ║         ║         ║         ║         ║        ║  guarantee    ║
  ║              ║         ║         ║         ║         ║        ║               ║
  ║ Quick        ║ n log n ║ n log n ║  O(n²)  ║ O(logn) ║   ❌   ║  In-place,    ║
  ║              ║         ║         ║         ║         ║        ║  general      ║
  ║              ║         ║         ║         ║         ║        ║               ║
  ║ Counting     ║  n + k  ║  n + k  ║  n + k  ║ O(n+k)  ║   ✅   ║  Small range  ║
  ║              ║         ║         ║         ║         ║        ║  integers     ║
  ║              ║         ║         ║         ║         ║        ║               ║
  ║ Radix        ║ d(n+k)  ║ d(n+k)  ║ d(n+k)  ║ O(n+k)  ║   ✅   ║  Fixed digit  ║
  ║              ║         ║         ║         ║         ║        ║  integers     ║
  ║              ║         ║         ║         ║         ║        ║               ║
  ╚══════════════╩═════════╩═════════╩═════════╩═════════╩════════╩═══════════════╝
*/


/*
Real-World Scenarios
শুধু theory না, concrete examples দিয়ে দেখি।

Scenario 1: E-commerce Rating Sort
Problem: ১০ লাখ product, প্রতিটার rating 1-5 star। Rating অনুযায়ী sort করতে হবে।

Analysis:

Integer data ✅
Range very small (k=5) ✅
Stability দরকার (same rating এর product display order preserve)
Best: Counting Sort। O(n+k) = 10⁶ + 5 = 10⁶ operation। Merge Sort এর চেয়ে ~২০ গুণ দ্রুত!

Scenario 2: Student Marks Sort
Problem: ৫০০০ students এর marks (0-100) sort।

Analysis: Integer, k=100, stability ভালো হবে।

Best: Counting Sort। k=100, n=5000, O(n) practically।

Scenario 3: Phone Number Database
Problem: ১ কোটি phone numbers (10-digit) sort।

Analysis:

Integer (treat as integer) ✅
Fixed digit count ✅
Value range huge (10⁹)
Best: Radix Sort। Counting Sort fail করবে (10⁹ memory!)। Merge Sort O(n log n) ≈ ২৩ কোটি operation, Radix Sort O(d × n) = 10 × ১ কোটি = ১০ কোটি — দ্রুত!

Scenario 4: Order Sort by Timestamp
Problem: ১০ লাখ order sort by date+time। Same timestamp হলে order ID অনুযায়ী sequential থাকতে হবে।

Analysis:

Comparison-based লাগবে (timestamp তো integer হতে পারে, কিন্তু complex)
Stability critical — same timestamp এর order ভাঙলে সমস্যা
Best: Merge Sort। Stable এবং guaranteed O(n log n)।

Scenario 5: Competitive Programming
Problem: Contest এ ১ লাখ random integers sort করতে হবে।

Analysis: Quick sort, general purpose, memory উদার।

Best: std::sort() বা sorted() — built-in সবচেয়ে fast। IntroSort/TimSort optimized।

Scenario 6: External Sort (Disk)
Problem: 50 GB log file sort করতে হবে, RAM মাত্র 8 GB।

Analysis:

Data RAM এ ফিট করে না
Disk I/O expensive
Best: External Merge Sort। ছোট chunks RAM এ sort করো, disk এ save, তারপর merge। Merge Sort sequential access friendly তাই ভালো।

Scenario 7: Real-Time Small Data
Problem: Sensor থেকে প্রতি second এ ২০টা reading আসে, sort করতে হবে।

Analysis: n=20, নতুন reading প্রায় sorted position এ আসে।

Best: Insertion Sort। Simple, small overhead, nearly sorted data তে O(n)।

Scenario 8: LinkedList Sort
Problem: A linked list sort করতে হবে।

Analysis:

Random access O(n) — Quick Sort unsuitable
Sequential access natural
Best: Merge Sort। Slow-fast pointer দিয়ে middle, recursive sort, merge।

Scenario 9: Embedded System
Problem: IoT device এ 256 KB RAM, ১০,০০০ sensor values sort।

Analysis:

Memory strictly limited
In-place must
Best: Randomized Quick Sort। In-place, O(1) extra memory (recursion stack বাদে)।

Scenario 10: Already Sorted Data
Problem: User already-sorted list এ নতুন element insert করে আবার sort চাপলো।

Analysis:

Array almost fully sorted
Very few inversions
Best: Insertion Sort। Nearly sorted data তে O(n)। Quick Sort এ worst case O(n²) হতে পারে!

Common Mistakes — এগুলো এড়িয়ে চলো
❌ Rating (1-5) sort করতে Merge Sort। Counting Sort দিয়ে ২৩ গুণ দ্রুত হতো।

❌ LinkedList এ Quick Sort। Random access এ O(n) — পুরো Quick Sort O(n²)।

❌ Last-element pivot Quick Sort production এ। User যদি already sorted data দেয় → worst case O(n²)। সবসময় randomized।

❌ Large memory available তে Quick Sort over Merge Sort। Merge Sort stability offer করে — যদি matter করে তো loss।

❌ Stability দরকার যেখানে Quick Sort। Bug! Equal elements এর order ভাঙে।

❌ Small n (< 50) এ Merge Sort। Overhead বেশি। Insertion Sort সহজ + দ্রুত।

❌ Counting Sort blindly। Range check না করে — memory explode হতে পারে।


*/