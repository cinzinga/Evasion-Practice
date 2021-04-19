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

### 04-NonExistingURL.cs ###
This code makes an HTTP request to a fictitious domain, if no response is received (expected outcome) the shellcode runner will execute. If a response is received, this indicates some shenanigans are going on. AV sandboxes often are not allowed to make outbound requests and will instead reply with a fake response so the code may continue execution. Thus, if the code fails it is in the real world, otherwise it might be in an AV sandbox.

### 05-KnownPath.cs ###
If the target's username is known, then it may be possible to specify specific actions that will only run in the context of that user. For example, here we are writing a file to the desktop of the user "User". Then, the contents of that file are read back, if they match what was written, the shellcode will execute.

### 06-VirtualAllocExNuma.cs ###
Some AV engine simply can not emulate all known Windows APIs. This means if they encounter an unknown API, it will stop examining the malicious program. Here we are imported the Win32 API VirtualAllocExNuma which is used to configure memory management in multiprocessing systems. If the memory allocated is not NULL, then the shellcode will execute.

### 07-FlsAlloc.cs ###
Similar logic to `06`, some AV emulators will return a failing condition when FlSAlloc is called. For future reference, `UInt32` is the C# equivalent of `DWORD` and `IntPtr.Zero` is the equivalent of `NULL`. `0xFFFFFFFF` equates to `-1` which is equivalent to failing conditions, the original code uses `FLS_OUT_OF_INDEXES`.

### 08-CheckProcessMemory.cs ###
In this example, `GetProcessMemoryInfo` is imported then information is gathered about the current process. If the the current working set (amount of memory a process requires in a given time interval) is less than 3.5MB then the shellcode executes. Much of this code can be found from the "Sample Code" section [here](https://www.pinvoke.net/default.aspx/psapi.getprocessmemoryinfo).