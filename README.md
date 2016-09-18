# Create Symlink
Demonstrates how to create a symlink in: 

1. A Universal Windows Platform (UWP) app using PInvoking to call the Win32 `[CreateSymbolicLink()](https://msdn.microsoft.com/en-us/library/windows/desktop/aa363866(v=vs.85).aspx)' API
2. A Win32 Console app which calls the `[CreateSymbolicLink()](https://msdn.microsoft.com/en-us/library/windows/desktop/aa363866(v=vs.85).aspx)' API directly

Currently, the UAP app (1, above) fails due to additional protections/constraints.
