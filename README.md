# Evasion-Practice #

A place for me to practice writing various evasion techniques in C#. The base code will remain the constant for future work while the evasion techniques utilized will vary. Many techniques are inspired by [this PDF](https://blog.sevagas.com/IMG/pdf/BypassAVDynamics.pdf).

### 00-BaseCode.cs ###
The base code that will remain constant across all trials.

### 01-AllocateAndFill.cs ###
Allocates a ~1.07GB byte array and zeroes it out, then checks if the last value is equal to 0. The theory is that an antivirus engine will forgo zeroing out all this memory, thus the program will quit before the shellcode runner can be examined.

### 02-ManyIterations.cs ###
Iterates through a for loop nine hundred million times in an effort to discourage AV from emulating the rest of the program.

### 03-OpenSystemProcess.cs ###

This code attempts to open PID 4, which is a SYSTEM process. In theory, a normal user should not be able to open this process while an AV engine would be able to. This would return a null handle when run by a legitimate user. The Win32 API  ` OpenProcess` is imported for this code snippet. This API is often used in malicious code so this evasion technique may generate more detections. `0x001F0FFF` is the hexadecimal representation of `PROCESS_ALL_ACCESS`.
