# Presentation: What is a Shader?
- https://docs.google.com/presentation/d/19uHZCmhijtWHYk7oTaFWOPgLDQjFvwXGYUwshljkP_Q/edit?usp=sharing

# Short Break

# Unity Setup
- change camera background color to solid and black
- adjust camera to height 0 and play around with field of view (e. g. 25), angle etc. to match mapping scenerio, if needed
- create some primitive shapes in the Hierarchy Window such as Cube, Circle, Cylinder, Capsule, Quad to test shaders
- disable ambient lighting (Light window) and Post Processing (if you want)

# Materials
- create a new Material in the Project Window and assign it to the MeshRenderer of each primitive shape
- select a few of the built-in URP shaders for the material and assign some values

# Shader Graph Basics
- create a new shader in the Project Window -> Create -> Shader Graph -> URP -> Unlit Shader Graph
- double click to open in Shader Graph window
- add a new Color field in the Blackboard
- connect it to the fragment program (drag into window, drag from output to fragment input)
- apply new Shader to the previously created Material that is used on the primitives

# Shader Graph Color
- color is RGB, which is just 3 numbers that we can manually set
- conversion to HSV and back, Split Node and Vector4 Node
- Add and Multiply Node

# Shader Graph Texture and Blackboard
- sample Texture2D
- set test values in Blackboard (which will be manually set in the Material)
- UV (x and y mapping of textures to a 3D model)
- different texture mappings that are commonly used:
	+ UV Space: UV Node
	+ Object Space: Position Node set to Object
	+ World Space: Position Node set to World
	+ View Space: Position Node set to View
	+ Screen Space: Screen Position Node set to Default or Tiled

# Play Time 01
- create a Shader in the Project window
- apply it to a Material that you created in the Project window
- apply that Material to some GameObjects in your Scene via the Hierarchy and Inspector windows
- add at least one Color and one Texture to your Shader
- try out some of the nodes, see what you can connect, what happens, write down questions if you like

# Long Break

# Optional Show and Ask

# Shader Graph Animation
- Time and Modulo Nodes
- Lerp between two colors with moduloed time, then with a Blackboard Float slider
- Scene view + Always Refresh gives best results when we are not in Unity's Play Mode OR edit shaders in Play Mode
- Add, Subtract and Divide Nodes

# SubGraphs and more Examples
- inputs we have (Input Nodes, Texture, number = Float, multiple numbers = Vector)
- outputs we have (Vertex, Fragment)
- Polar Coordinates Node
- Step Node (normalizing into either 0 or 1)
- Lerp Node (mapping from range betwee 0 and 1)
- Inverse Lerp Node (mapping to range between 0 and 1)
- Saturate Node (clamping)
- Blend Node (same layer modes as in Photoshop)
- show examples I brought (share link with *.unitypackage)
	+ mouse
	+ keyboard
	+ music

# Play Time 02
- use time in your Shader
- expose some settings in the Inspector through the Blackboard