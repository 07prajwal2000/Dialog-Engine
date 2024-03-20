# Dialog Engine
A Free and Open source dialog engine written in C# made specifically for using this library in any game engine or graphics library that supports C#.
Or you can implement to your language just by looking into code.

# Demo
- I made a simple demo using Raylib_CsLo library that reads JSON file and converts to Dialog Nodes (which are the main backbone).

# Planned Feature lists
- [ ] Adding characters attribute i,e (Which character is active/talking).
- [ ] Support for custom data embedding to Dialog nodes.
- [ ] Optimising Parser class.
- [ ] Documentation.
- [ ] Support for Events
	- Started
	- Dialog Node changed (when `engine.Next()` is called)
	- Ended
- [ ] Support for web-based Dialogs generator (probably node-editor with good visuals).

# Supported Features
- Dialog flow.
- Loading from JSON file. (if used, it supports going to different nodes at runtime).
- Dialogs Branching. (multiple options at a node and user can choose which dialog to go).

# Contributing
This repo is open to contributions. PRs from anyone is accepted if it a valid feature, bug fix or an enhancement.

# Getting Started
- Make sure Dotnet 8 is installed.
- Clone the repository.
- cd into the demos folder.
- Run the Demos using `dotnet run` command.
- Modify the `dialog.json` file according to your needs.

## Dependencies
- Newtonsoft.Json

## Dialog Node Types
- Dialog Node (1)
- Dialog Branch Node (2)
- Choice Node. Doesnt have any index-value. But it resides only inside a branch node.

# Quick Docs
- Sample JSON file. For more complex version you can look at [here](./DialogEngine.Demos/dialog.json)
```json
[
	{
		// required and must be unique, if not Engine will generate random number.
		"id": 1,
		"type": 1, // Dialog node
		"title": "Title 1",
		"description": "Description 1", // optional,
		"next": 2 // the next node to go when engine.Next() is called
	},
	{
		// after above node is completed it moves to next node i,e this node.
		"id": 2,
		"type": 1,
		"title": "Title 2",
		"description": "Description 2", // optional,
		"next": 3 // the next node to go when engine.Next() is called
	},
	{
		"id": 3,
		"type": 2, // branch node
		"nodes": [
			{
				"title": "Apple", // required
				"next": 2 // optional. if not provided engine will exit out. but here it goes back to node 2
			},
			{
				"title": "Orange",
				"next": 1
			}
		]
	}
]
```