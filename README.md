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

## Proposed Next Steps

## Assumptions & known gaps