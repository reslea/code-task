## Intro 
The coding part of the technical interview consists of two parts: "offline" and "online".

## "Offline" Coding Session

The main puprpose of this simple coding task - to make you more confident with the process we use for an "online" coding session.
You can work on it at time that is corfortable for you. It should not take more than an hour or so.
We're not looking for "perfect" solution. First of all we're looking for a "working" solution.

So, there are two projects in the VS solution in this repo: console and test.
The console project contains `StringUtils.RearrangeWords` method which is not yet implemented.
You should imlement the method according to the **"Rearrange Words in a Sentence"** spec below.
Make sure all tests in the test project are passed.
You can use either VS Code or Visual Studio while crafting this - whatever is more convenient for you.

## "Online" Coding Session

We're going to talk a little bit about implementation details of the "offline" task. So, there is no need to send it in advance.
Also, there will be several additional small tasks you need to code online.
Don't be stressed out - they are all simple and straightforward.
You're free to use Intellisense hints, Google whatever you need in order to make it working.
This should not take more than an hour as well.

Make sure you have [Visual Studio Live Share](https://visualstudio.microsoft.com/services/live-share/) extension installed locally.
We are going to use it during online coding session. 
Also, keep in mind that in order to start Live Share session you should use either Microsoft or GitHub account.

## Rearrange Words in a Sentence

Given a sentence text (A sentence is a string of space-separated words) in the following format:
- First letter is in upper case.
- Each word in text are separated by a single space.

Your task is to rearrange the words in text such that all words are rearranged in an increasing order of their lengths.
If two words have the same length, arrange them in their original order.

Return the new text following the format shown above.

### Example 1:

```
Input: text = "Coding is cool"
Output: "Is cool coding"
Explanation: There are 3 words, "Coding" of length 6, "is" of length 2 and "cool" of length 4.
Output is ordered by length and the new first word starts with capital letter.
```

### Example 2:

```
Input: text = "Keep calm and code on"
Output: "On and keep calm code"
Explanation: Output is ordered as follows:
"On" 2 letters.
"and" 3 letters.
"keep" 4 letters in case of tie order by position in original text.
"calm" 4 letters.
"code" 4 letters.
```

### Example 3:

```
Input: text = "To be or not to be"
Output: "To be or to be not"
```
