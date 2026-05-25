# NOTE:
Version 1.1 is a complete rewrite of the entire program from the ground up. As of now,
many of the features from 1.0 will be incomplete or missing entirely. So I do not recommend running this version until
this message says so, I am only pushing this to github for backup purposes. As of this commit, this program is not usable
at all.

## About
Centi is a console text editor like Nano or Vim. You can open, search, edit and save files.

### How to run
 - Linux/OSX: `./centi [FILE]`
 - Windows: `.\centi.exe [FILE]`

### List of keybindings
* CTRL + Q - Quit program
* CTRL + O - Open new file
* CTRL + X - Save file
* CTRL + F - Search file
* CTRL + L - Goto line 
* CTRL + N - Create new file
* CTRL + D - Delete line
* CTRL + C - Copy line
* CTRL + ALT + V - Paste line
* ALT + M - Cause a miracle to occur

### Current limitations
 - Resizing the terminal breaks the whole UI
 - Only one file can be opened in a single session
 - Searches aren't highlighted
 - No syntax highlighting
 - Cannot be configured (i.e. keybindings, themes, visual stuff)
 - Lacks undo/redo features
 - UI very minimalY
