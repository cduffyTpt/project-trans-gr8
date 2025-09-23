# D&D Spell Checker - Interview Test

## What is this?
This is a **job interview coding test**. You will work on a program that checks if a player can cast magic spells in Dungeons & Dragons game. It looks at the player's stats and tells you "yes" or "no".

**Important:** Your completed code will be discussed during your interview. We will review your solution together and ask questions about your approach.

## The Problem
There is a **bug** (error) in the code. The program says players can cast spells when they should not be able to.

**Bug Details:**
- Spell name: "Cure Wounds"
- Problem: Players without "Somatic Component" can still cast this spell
- This is wrong - they should NOT be able to cast it

## What You Need to Do

### Main Tasks (Required)
1. **Copy this project** 
   - Fork this repository
   - Create a Pull Request back to the original

2. **Fix the code**
   - Use SOLID principles and Rule Engines
   - Keep this method signature the same: `public bool CanUserCastSpell(User user, string spellName)`
   - Fix the bug described above

3. **Add more tests**
   - Extend the unit tests 
   - Add new tests as needed

### Files to Change
- `SpellChecker.cs` (main code)
- `SpellCheckerTests.cs` (test code)

### Extra Tasks (Optional)
If you want to do more:
1. Load user data from a JSON file
2. Let users select which player to check
3. Use Serilog for logging instead of `Console.WriteLine`

## What This Test Shows
This test allows us to evaluate:
- Your knowledge of SOLID programming principles
- Your ability to implement Rule Engine patterns
- Your debugging and problem-solving skills
- Your approach to writing unit tests
