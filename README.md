# Evasion-Practice #

A place for me to practice writing various evasion techniques written in C#. The base code will remain the constant for future work while the evasion techniques utilized will vary. Many techniques are inspired by [this PDF](https://blog.sevagas.com/IMG/pdf/BypassAVDynamics.pdf).

### 00-BaseCode.cs ###
The base code that will remain constant across all trials.

### 01-AllocateAndFill.cs ###
Allocates a ~1.07GB byte array and zeroes it out, then checks if the last value is equal to 0. The theory is that an antivirus engine will forgo zeroing out all this memory, thus the program will quit before the shellcode runner can be examined.
