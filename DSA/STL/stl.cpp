/*
STL stands for Standard Template Library. It is a powerful set of C++ template classes to provide general-purpose classes and functions with templates. It includes algorithms and data structures that allow programmers to use them without having to write their own implementations.
The STL provides a collection of template classes and functions for data structures such as vectors, lists, queues, stacks, and algorithms for sorting, searching, and manipulating these data structures. It is a fundamental part of C++ programming and is widely used in various applications.

Resources:
1. C++ Reference: https://en.cppreference.com/w/cpp
2. STL Documentation: https://www.cpsacademy.io/blog/c-stl-complete-guide-beginner-to-advanced--
*/

#include <bits/stdc++.h>
using namespace std;
int main()
{

    //============== Pair ===========
    // A pair is a simple container that holds two values of different types. It is defined in the <utility> header and can be used to store and manipulate pairs of data.
    pair<int, string> dedmoPair;
    dedmoPair.first = 10;
    dedmoPair.second = "Hello, STL!";
    cout << "Pair: " << dedmoPair.first << ", " << dedmoPair.second << endl;

    // Using make_pair to create a pair
    pair<int, string> anotherPair(20, "C++ STL");
    cout << "Another Pair: " << anotherPair.first << ", " << anotherPair.second << endl;

    // Array of pairs
    pair<double, double> point[5];
    for (int i = 0; i < 5; i++)
    {
        point[i].first = i * 1.0;
        point[i].second = i * 2.0;
    }
    for (int i = 0; i < 5; i++)
    {
        cout << "Point " << i << ": (" << point[i].first << ", " << point[i].second << ")" << endl;
    }

    pair<double, pair<double, double>> point3D[5];

    for (int i = 0; i < 5; i++)
    {
        point3D[i].first = i * 1.0;
        point3D[i].second.first = i * 2.0;
        point3D[i].second.second = i * 3.0;
    }

    for (int i = 0; i < 5; i++)
    {
        cout << "Point " << i << ": (" << point3D[i].first << ", " << point3D[i].second.first << ", " << point3D[i].second.second << ")" << endl;
    }

    //============== Vector ===========
    // A vector is a dynamic array that can resize itself automatically when elements are added or removed. It provides fast access to elements and is one of the most commonly used data structures in C++.
    vector<int> vec;
    for (int i = 0; i < 5; i++)
    {
        vec.push_back(i * 10);
    }
    for (int i = 0; i < vec.size(); i++)
    {
        cout << "Vector element " << i << ": " << vec[i] << endl;
    }

    vec.pop_back();
    for (int i = 0; i < vec.size(); i++)
    {
        cout << "Vector element " << i << ": " << vec[i] << endl;
    }

    //============== Unordered Set ===========
    // An unordered set is a collection of unique elements that are not stored in any particular order. It uses a hash table for storage, which allows for fast insertion, deletion, and lookup operations.
    unordered_set<int> mySet;
    mySet.insert(10);
    mySet.insert(20);
    mySet.insert(30);
    cout << "Unordered Set contains 20: " << (mySet.count(20) ? "Yes" : "No") << endl;

    mySet.erase(20); // Erase element 20 from the set

    // Check if 20 is still in the set after erasing
    cout << "Unordered Set contains 20 after erasing: " << (mySet.count(20) ? "Yes" : "No") << endl;

    // Iterate through the unordered set
    unordered_set<int>::iterator it;
    for (it = mySet.begin(); it != mySet.end(); it++)
    {
        cout << "Unordered Set element: " << *it << endl;
    }

    // Using range-based for loop to iterate through the unordered set
    unordered_set<string> stringSet;
    for (int i = 0; i < 3; i++)
    {
        string name;
        cin >> name;
        stringSet.insert(name);
    }

    for (auto name : stringSet)
    {
        cout << "Name in set: " << name << endl;
    }

    //============== Set ===========
    // A set is an ordered collection of unique elements. It automatically sorts the elements in ascending order and does not allow duplicates.
    set<int> myOrderedSet;
    myOrderedSet.insert(30);
    myOrderedSet.insert(10);
    myOrderedSet.insert(20);

    for (auto value : myOrderedSet)
    {
        cout << "Ordered Set element: " << value << endl;
    }

    // Erase an element from the ordered set
    myOrderedSet.erase(20);

    for (auto it = myOrderedSet.begin(); it != myOrderedSet.end(); it++)
    {
        cout << "Ordered Set element using iterator: " << *it << endl;
    }

    // Check if an element exists in the ordered set
    cout << "Ordered Set contains 20: " << (myOrderedSet.count(20) ? "Yes" : "No") << endl;

    //============== Multiset ===========
    // A multiset is a collection of elements that allows duplicate values. It is similar to a set but can store multiple instances of the same element.

    multiset<string> myMultiset;
    myMultiset.insert("apple");
    myMultiset.insert("banana");
    myMultiset.insert("apple"); // Duplicate element

    for (auto fruit : myMultiset)
    {
        cout << "Multiset element: " << fruit << endl;
    }

    // Erase one instance of "apple" from the multiset
    auto fruitDelete = myMultiset.find("apple");
    myMultiset.erase(fruitDelete);

    cout << "After erasing one instance of 'apple':" << endl;
    for (auto fruit : myMultiset)
    {
        cout << "Multiset element: " << fruit << endl;
    }

    // ============== Unordered Map ===========
    // An unordered map is a collection of key-value pairs that allows for fast retrieval of values based on their keys. It uses a hash table for storage, which provides average-case constant time complexity for search, insertion, and deletion operations.

    unordered_map<double, string> myUnorderedMap;
    myUnorderedMap[3.14] = "pi";
    myUnorderedMap[2.71] = "e";
    cout << "Value for key 3.14: " << myUnorderedMap[3.14] << endl;
    cout << "Value for key 2.71: " << myUnorderedMap[2.71] << endl;

    myUnorderedMap[3.14] = "PI";

    myUnorderedMap.erase(2.71); // Erase key 2.71 from the unordered map

    for (auto keyValue : myUnorderedMap)
    {
        cout << "Key: " << keyValue.first << ", Value: " << keyValue.second << endl;
    }

    cout << "Unordered Map contains key 2.71: " << (myUnorderedMap.count(2.71) ? "Yes" : "No") << endl;

    // ============== Map ===========
    // A map is a collection of key-value pairs that allows for fast retrieval of values based on their keys. It automatically sorts the keys in ascending order and does not allow duplicate keys.

    map<string, int> myMap;
    myMap["Alice"] = 30;
    myMap["Bob"] = 25;
    myMap["Charlie"] = 35;

    cout << "Age of Alice: " << myMap["Alice"] << endl;

    for (auto keyValue : myMap)
    {
        cout << "Key: " << keyValue.first << ", Value: " << keyValue.second << endl;
    }

    myMap.erase("Bob"); // Erase key "Bob" from the map

    cout << "After erasing key 'Bob':" << endl;
    for (auto keyValue : myMap)
    {
        cout << "Key: " << keyValue.first << ", Value: " << keyValue.second << endl;
    }

    //============= Multimap ===========
    // A multimap is a collection of key-value pairs that allows for multiple values to be associated with the same key. It is similar to a map but can store multiple instances of the same key.

    multimap<string, int> myMultimap;
    myMultimap.insert({"Alice", 30});
    myMultimap.insert({"Bob", 25});
    myMultimap.insert({"Charlie", 35});
    myMultimap.insert({"Alice", 35}); // Duplicate key

    for (auto keyValue : myMultimap)
    {
        cout << "Key: " << keyValue.first << ", Value: " << keyValue.second << endl;
    }

    myMultimap.erase(myMultimap.find("Alice")); // Erase one instance of key "Alice" from the multimap

    cout << "After erasing one instance of key 'Alice':" << endl;
    for (auto keyValue : myMultimap)
    {
        cout << "Key: " << keyValue.first << ", Value: " << keyValue.second << endl;
    }

    //============= Stack ===========
    // A stack is a data structure that follows the Last In, First Out (LIFO) principle. It allows for adding and removing elements from only one end, called the top of the stack.

    stack<int> myStack;
    myStack.push(10);
    myStack.push(20);
    myStack.push(30);
    myStack.push(40);
    myStack.push(50);
    myStack.push(60);
    myStack.push(70);

    cout << "Top element of the stack: " << myStack.top() << endl;
    myStack.pop();
    cout << "Top element of the stack after popping: " << myStack.top() << endl;

    while (!myStack.empty())
    {
        cout << "Popping element: " << myStack.top() << endl;
        myStack.pop();
    }

    //============= Queue ===========
    // A queue is a data structure that follows the First In, First Out (FIFO) principle. It allows for adding elements at the back and removing elements from the front.

    queue<string> myQueue;
    myQueue.push("Alice");
    myQueue.push("Bob");
    myQueue.push("Charlie");
    myQueue.push("David");

    cout << "Front element of the queue: " << myQueue.front() << endl;
    cout << "Back element of the queue: " << myQueue.back() << endl;

    myQueue.pop(); // Remove the front element (Alice)

    while (!myQueue.empty())
    {
        cout << "Popping element: " << myQueue.front() << endl;
        myQueue.pop();
    }

    //============= Priority Queue ===========
    // A priority queue is a data structure that allows for efficient retrieval of the highest (or lowest) priority element. It is typically implemented using a binary heap.

    priority_queue<int, vector<int>, greater<int>> myPriorityQueue; // Min-heap

    myPriorityQueue.push(30);
    myPriorityQueue.push(10);
    myPriorityQueue.push(20);

    cout << "Top element of the priority queue: " << myPriorityQueue.top() << endl; // Should be 10, the smallest element

    while (!myPriorityQueue.empty())
    {
        cout << "Popping element: " << myPriorityQueue.top() << endl;
        myPriorityQueue.pop();
    }

    priority_queue<pair<int, int>, vector<pair<int, int>>, greater<pair<int, int>>> myPairPriorityQueue; // Min-heap for pairs
    myPairPriorityQueue.push({1, 2});
    myPairPriorityQueue.push({5, 4});
    myPairPriorityQueue.push({1, 5});
    myPairPriorityQueue.push({2, 6});
    myPairPriorityQueue.push({2, 10});

    while (!myPairPriorityQueue.empty())
    {
        pair<int, int> topPair = myPairPriorityQueue.top();
        cout << "Popping pair: (" << topPair.first << ", " << topPair.second << ")" << endl;
        myPairPriorityQueue.pop();
    }

    //============= Deque ===========
    // A deque (double-ended queue) is a data structure that allows for efficient insertion and deletion of elements at both the front and back ends. It is implemented as a dynamic array that can grow in both directions.

    deque<int> myDeque;
    myDeque.push_back(10);
    myDeque.push_back(20);
    myDeque.push_front(5);
    myDeque.push_back(30);
    myDeque.push_front(1);

    cout << "Front element of the deque: " << myDeque.front() << endl; // Should be 1
    cout << "Back element of the deque: " << myDeque.back() << endl;   // Should be 30

    for (auto element : myDeque)
    {
        cout << "Deque element: " << element << endl;
    }

    // ============= Sort ===========
    vector<pair<int, int>> points;
    for (int i = 0; i < 5; i++)
    {
        int x, y;
        cin >> x >> y;
        points.push_back({x, y});
    }
    sort(points.begin(), points.end(), greater<>()); // Sorts based on the first element of the pair, then the second element if the first elements are equal
    for (auto point : points)
    {
        cout << "Point: (" << point.first << ", " << point.second << ")" << endl;
    }

    // ============= UpperBound & LowerBound ===========
    vector<int> v;
    for (int i = 0; i < 5; i++)
    {
        int x;
        cin >> x;
        v.push_back(x);
    }
    sort(v.begin(), v.end());

    cout << *lower_bound(v.begin(), v.end(), 3) << endl; // First element not less than 3
    cout << *upper_bound(v.begin(), v.end(), 3) << endl; // First element greater than 3
    cout << *lower_bound(v.begin(), v.end(), 4) << endl; // First element not less than 4


    // Using lower_bound with a set
    set<int> s;
    s.insert(1);
    s.insert(10);
    s.insert(13);
    s.insert(15);
    cout << *s.lower_bound(12) << '\n';

    return 0;
}