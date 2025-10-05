# AI Usage Log

This document tracks all AI assistance used during the Gilded Rose refactoring project.

## Framework Modernization (October 5, 2025)

**Where used:** Project-wide framework upgrade to .NET 9.0
**Summary:** GitHub Copilot assisted with converting the project from .NET 8.0 to .NET 9.0, including updating project files, removing legacy NuGet configuration, and updating test dependencies.
**Model/tool:** GitHub Copilot
**How I validated/edited the output:** Verified all project files were updated correctly, tested build and test execution, confirmed removal of legacy .nuget folder and configurations.
**Why it helped / risks considered:** Automated the tedious process of updating multiple project files and configurations consistently. Risk was minimal as this was a straightforward framework version upgrade with backward compatibility.

## Test Case Implementation (October 5, 2025)

**Where used:** TestAssemblyTests.cs and Program.cs modifications
**Summary:** GitHub Copilot helped write a characterization test for regular item behavior, added project reference, and made Program class public for testability.
**Model/tool:** GitHub Copilot
**How I validated/edited the output:** Verified the test correctly validates the existing behavior (SellIn decreases by 1, Quality decreases by 1), confirmed build and test execution passes.
**Why it helped / risks considered:** Ensured proper test structure and naming conventions. Risk was minimal as this was adding test coverage for existing functionality without changing business logic.

## Comprehensive Test Suite Implementation (October 5, 2025)

**Where used:** TestAssemblyTests.cs - comprehensive characterization test suite
**Summary:** GitHub Copilot helped create 7 additional characterization tests covering all business rules: regular items (normal/expired/zero quality), Aged Brie (normal/max quality), Sulfuras (legendary), and Backstage passes (>10 days).
**Model/tool:** GitHub Copilot
**How I validated/edited the output:** All 8 tests pass, validating existing behavior patterns: quality bounds (0-50), sell date effects, item-specific rules. Each test follows AAA pattern with descriptive naming.
**Why it helped / risks considered:** Created comprehensive safety net for refactoring by locking in all current behaviors. Risk minimal as tests only validate existing logic without modification. Enables confident refactoring knowing any behavior changes will be caught.

## Complete Test Suite with Golden Master (October 5, 2025)

**Where used:** TestAssemblyTests.cs - final comprehensive test suite including complex backstage pass rules and 30-day golden master test
**Summary:** GitHub Copilot helped complete the characterization test suite with backstage pass edge cases (10-day, 5-day, after-concert rules) and a comprehensive 30-day golden master test simulating the entire system with all item types.
**Model/tool:** GitHub Copilot
**How I validated/edited the output:** All 12 tests pass (100% success rate). Golden master test validates system behavior over 30 days with 6 different item types, ensuring all business rules work correctly in combination. Each assertion validates expected end states after long-term operation.
**Why it helped / risks considered:** Completed full characterization coverage including complex time-based rules and system integration testing. The golden master test provides ultimate confidence for refactoring by validating the entire system behavior. Risk minimal as tests lock in existing behavior without modification, providing comprehensive safety net for any future code changes.