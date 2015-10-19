Notes/Known issues:

Editor is preset to support SIC.

TODO List:

- Implement a SIC/XE assembler
- Implement a debugger class for the current simulator
- Improve the performance of formatting (4ms/line/(Space|Enter) is not acceptable with big files)
	-- Store the RTF of lines and only reformat if changed.
	-- A multithreading approach could be useful, especially if full RTF parsing is implemented.

Longterm goals:

- Implement/Include a linker.
- Add support for real machines (Intel/AMD 32/64bit)
- Implement a resource editor.
- Implement a disassembler.
- Implement/Integrate a general debugger.