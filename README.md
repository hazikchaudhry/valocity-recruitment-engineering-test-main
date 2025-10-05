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

# How to Run Gilded Rose

## Prerequisites
- .NET Framework or .NET Core installed
- Visual Studio or any C# compatible IDE

## Running the Application

### Method 1: Using Visual Studio
1. Open GildedRose.sln in Visual Studio
2. Set GildedRose.Console as startup project
3. Press F5 or click Run

### Method 2: Command Line
Navigate to the project directory and run:
```
cd src\GildedRose.Console
dotnet run
```

### Method 3: Using build.bat
From the root directory:
```
build.bat
```

## Expected Output
The application will display "OMGHAI!" and show the current state of all items, then wait for a key press before closing.

## Running Tests
```
cd src\GildedRose.Tests
dotnet test
```



## Design notes

First I wrote the plan to give a guideline and help me understand what and how I will do this. Then I wrote the Co-Pilot Instructions file that will help the AI system to better understand the code and what it may or may not do, it looks at it for each request. I did this by copying elements from the old_README.md, this does take some time but overall it pays off when working on a codebase overtime.

Ran the build.bat file and saw errors, searched up errors and installed the modern SDK for C# with the help of AI.

Started off by reading the main file properly, and then writing a test case to see functionality. Using AI I fed in the expected input and output for a regular Item and understood how to write a test in this framework. Had to make the program class public and add a reference in the csproj file to run the test cases. 

Program uses ALOT of if statements to make decisions, works but is not effective and not readable.

As I have written the behavior of the items already in the copilot instructions this now comes in handy as now I can generate more test cases without need of additional context. Did three batches total. 

Now that we have a proper snapshot of the initial output of the system we can now look at the code and start making small changes, this line of repeated code seems to be reducing the item quality by 1,

```csharp
if (Items[i].Quality > 0)
{
    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
    {
        Items[i].Quality = Items[i].Quality - 1;
    }
}
```
So I will make a small helper function inside the program to help, then replace this by a call.

It passed all test cases, so therefore this small refactor worked.

Saw another repeated code block for increasing, made a helper method for that as well, only replaced exact code for small improvements, passed all test cases so refactor is good, After each increase or decrease it would be nice if the user got a print message so confirm the system status.

Did some small refactoring for the expiry of the item, this could be useful in future, passed all tests

Now since its the final 10 ish mins, I will write about the next steps.



## Proposed Next Steps

The plan in my head was something like this 

Phase 1: Characterization Tests 
Phase 2: Extract helper methods (DecreaseQuality, etc) <- Here Currently


### Phase 3: Extract item-specific methods 
Extract SellIn management method
Add item type checking methods

### Phase 4: Introduce polymorphism 
Create update methods for each item type
Simplify main method with cleaner conditionals

### Phase 5: Add Strategy pattern 
Define strategy interface
Create strategy implementations for each item type
Implement strategy selection logic

Strategy pattern is favoured over Factory or Template Method because it encapsulates algorithms at runtime, making it straightforward to add new item types without modifying existing code. Each item type gets its own strategy class with complete control over its update behaviour.



Production Considerations for Gilded Rose

User Interface Requirements
Product users would benefit from a proper interface to explain the business rules clearly. Current string-based item identification is fragile and unclear.

Collaborative Development Practices
For team collaboration, would implement proper Git branching strategy, pull requests, code reviews, and continuous integration pipelines.

Production Readiness
Live deployment requires robust error handling, comprehensive logging, user-friendly interface for inventory management, and proper validation of item data.

Key Concerns
User impact: Changes could affect inventory calculations
Invariants: Quality bounds (0-50), Sulfuras properties must remain constant
Guardrails: Input validation, defensive programming against invalid items
Clarity: Business rules need documentation, better naming conventions for item types

Risk Mitigation
Comprehensive test coverage, gradual rollout, monitoring, and rollback capabilities essential before production deployment.


## Assumptions & known gaps

Assuming the initial code was correct in terms of functionality fully, the test cases confirmed this

I do work more with Java, due to my coursework, but the concepts are the same the syntax make it a bit less slower to write code quickly, but I still get it 

