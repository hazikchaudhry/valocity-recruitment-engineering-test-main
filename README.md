## Plan

### Characterising Current Behaviour
- Parameterised tests for each item type through multiple update cycles
- Boundary testing: quality limits (0, 50), sell-in transitions
- Focus on business rule coverage rather than exhaustive coverage

### Refactoring Approach
- Strategy pattern: Extract item-specific logic into separate classes
- Eliminate branching: Replace if/else with polymorphic behaviour
- Extract methods first, then introduce patterns

### Step Order
1. Write characterisation tests, Safety net before changes
2. Extract quality update methods, Small safe refactoring
3. Introduce item update strategies, Move type-specific logic
4. Clean up - Remove duplication, improve names


## How to run

## Design notes

First I wrote the plan to give a guideline and help me understand what and how I will do this. Then I wrote the Co-Pilot Instructions file that will help the AI system to better understand the code and what it may or may not do, it looks at it for each request. I did this by copying elements from the old_README.md, this does take some time but overall it pays off when working on a codebase overtime.

Ran the build.bat file and saw errors, searched up errors and installed the modern SDK for C# with the help of AI.

Started off by reading the main file properly, and then writing a test case to see functionality. Using AI I fed in the expected input and output for a regular Item and understood how to write a test in this framework. Had to make the program class public and add a reference in the csproj file to run the test cases. 

Program uses ALOT of if statements to make decisions, works but is not effective and not readable.

As I have written the behavior of the items already in the copilot instructions this now comes in handy as now I can generate more test cases without need of additional context




## Proposed Next Steps

## Assumptions & known gaps