# Dungeons & Dragons Spell Checker

As an avid D&D player, I have written an application which allows me to check if a user has the correct stats to cast spells in my quest. 

I have a found some bug in the code but not too sure about how to fix it. 

I have read some things online about a principal called SOLID and Rule Engines which I think may help me identify and fix the issue. 


## Task
1. I would like the code fixed so that we follow the new principal, without changing the signature of the Method `public bool CanUserCastSpell(User user, string spellName)` 
2. I would like the Bug identified and fixed
3. I would like the Unit Tests provided to be extended so they capture new tests as they are required


## Bug
The bug is defined as such:

When the Spell is "Cure Wounds" and the User DOES NOT HAVE "Somatic Component" then they are still able to cast the spell. 

### HINT
 The code which needs to be modified is centered in 2 files
 1. SpellChecker.cs
 2. SpellCheckerTests.cs

### Optional Extras (not required)
1. Load all users into the application - Via a JSON File
2. Select a User to Check the Spell for
3. Use a Logger (Serilog) to write the messages rather than a Console.WriteLine statement.
