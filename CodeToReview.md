Line 2: Compilation Error using System.Collegctions.Generic; contains a typo. Should be System.Collections.Generic


Lines 68-71: Logic Error in GetMarried Method. The substring operation result is not returned or assigned. Therefore nothing happens with it, unless this is intended ? Unlikely.


Line 42: Random Number Generation Bug random.Next(0, 1) will always return 0 because the upper bound is not included, so the number will always be less than 0. This means the name will always be "Bob", never "Betty". Should be random.Next(0, 2), so the number can be greater than 0 in some cases.


Line 7: Class Naming People should be a singular Person name because its only one person per object, not a multiple person.


Line 18: Class Naming BirthingUnit does not sound right, should be something else.


Line 21: Misleading XML, the XML does not seem to be relevant here ?, the names of certain things in the XML do not appear anywhere else in the file.


Line 38: Typo in Comment should be "Creates a random Name".


Line 48: Date Calculation Using 356 days does not seem correct from my understanding, perhaps it should be 365.


Line 36: Method Behavior The GetPeople method adds to the existing _people list rather than creating a new list, which means multiple calls will add results rather than generate a new fresh list of people.


Line 51: Poor Exception Handling, should be more specific and allow for easier de bugging of the code


Line 66: Input Validation Missing No null checks on parameters in GetMarried method could cause error.


Line 14-15: Naming Of Variables, The use of Name and DOB, should be in camel case and should not use abbreviations  


Line 59: Date Comparison Logic Error The comparison x.DOB >= … is wrong for filtering people older than 30. It looks to be greater than or equal to, but rather it should be less than 30 years ago.


Line 9: Static Field Usage Using DateTimeOffset.UtcNow in a static field means the var Under16 value is fixed at time we make the class, not per call we make to it. The number which we subtract from it seems to be -15 ? Perhaps it should be -16.
