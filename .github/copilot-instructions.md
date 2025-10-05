# Copilot Instructions for Gilded Rose Refactoring

## Project Context
You are working on the Gilded Rose legacy code refactoring kata. 

## Gilded Rose Business Rules

**Basic Item Properties:**
- All items have SellIn (days to sell) and Quality (value)
- Each day: SellIn decreases by 1, Quality changes per item type

**Quality Rules:**
- Quality is never negative
- Quality never exceeds 50 (except Sulfuras at 80)
- After sell date passes, Quality degrades twice as fast

**Special Items:**
- **Regular items:** Quality decreases by 1 per day (2 after sell date)
- **Aged Brie:** Quality increases by 1 per day (2 after sell date)  
- **Sulfuras:** Never changes (Quality stays 80, SellIn unchanged)
- **Backstage passes:** Quality increases by 1 (>10 days), 2 (6-10 days), 3 (1-5 days), drops to 0 after concert
- **Conjured items:** Quality decreases by 2 per day (4 after sell date)

**Code Constraints:**
- DO NOT alter Item class or Items property
- CAN modify UpdateQuality method and add new code
- CAN make UpdateQuality and Items static

## Constraints & Expectations

**Production Code Standards:**
- Treat this as production code: small safe commits; meaningful messages; tests first or fast-follow
- Don't change public contracts unless justified (preserve `UpdateQuality` signature unless wrapped)
- Engineers own quality: tests should give confidence to change code
- Consider product & customers: note product-thinking observations (rules that could confuse users, invariants worth documenting)

## Evaluation Criteria

**Code Design & Refactoring:**
- Simplify branching logic
- Isolate business rules  
- Take small, safe steps
- Apply SOLID principles where helpful, not dogmatically

**Testing Strategy & Quality:**
- Characterize existing behavior with tests
- Cover meaningful edge cases
- Write readable, fast, deterministic tests

**Product Thinking:**
- Note user impact and invariants
- Identify guardrails needed
- Ensure clarity of rules and naming

**Engineering Hygiene:**
- Clear commit messages
- Good code structure and documentation
- "Engineers own quality" mindset

## Key Guidelines

**Testing Approach:**
- Use characterization tests or golden-master to de-risk refactors
- Lock in current behavior before changing structure

**Code Style:**
- Prefer intent-revealing names
- Keep control flow flat and readable
- Stage larger patterns (strategy/policy objects) behind tests
- Document why you chose your approach over alternatives

**AI Usage Requirements:**
- Document all AI usage in `AI_USAGE.md`
- Use clear prompts and validate output
- Avoid hallucinations
- Boost speed without hiding knowledge gaps

## AI Usage Logging
For every AI interaction, log to `AI_USAGE.md` using this format:

```
**Where used:** [file/line or task description]
**Summary:** [brief description of what AI helped with]
**Model/tool:** [e.g., GitHub Copilot, ChatGPT-4, etc.]
**How I validated/edited the output:** [leave blank initially]
**Why it helped / risks considered:** [leave blank initially]
```

## Success Signals
- Simplified, readable code with clear business rule separation
- Comprehensive test coverage of existing behavior
- Small, reversible commits with clear progression
- Product-aware observations about rule clarity and user impact