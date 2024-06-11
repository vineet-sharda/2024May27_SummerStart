# A project to check probability for the following question:

A soda manufacturer knows that sales of soda increase during the summer. To make sure that they get a large portion of the sales, they decide to offer a contest throughout the spring. The contest is pretty simple: when you open your bottle of soda, if it says, “You win!” under the cap, you get another bottle of their soda for free. The chance of winning a free soda is 1 in 12. Lucky Lucy bought five sodas and won a free one with four of the caps. What’s the probability of that happening?

---
2 Projects in this solution:
 - SummerStart - real code
 - 2024May27_SummerStart - client to see the code in action

**Remember**, start with small numbers to see how much your system can handle.

---
Here is the output of running the above question in 10 million ways
![10 million iterations of 5 turns each](/2024May27_SummerStart/Images/10_mil_iterations.png?raw=true "10 million iterations of 5 turns each")

The count of 4 wins out of 5 is quite close to 10 million times ![assertion](/2024May27_SummerStart/Images/assertion.png?raw=true "assertion") = 2210


---
This is explained by 2 different people very nicely here:
 - [StackOverflow](https://math.stackexchange.com/questions/1269115/probability-of-particular-subset-of-balls-occurring-in-a-larger-set-chosen-from) - remember a large set can be seen as one with replacement
 - [Nice image explanation](https://www.quora.com/What-is-the-probability-that-when-a-coin-is-tossed-5-times-we-will-get-exactly-4-heads) - coin toss is slightly simpler, hence 1/(2 ^ 4) * 1/2 is combined to 1 / (2 ^ 5).
