# Presentation: What is a Shader?
- https://docs.google.com/presentation/d/19uHZCmhijtWHYk7oTaFWOPgLDQjFvwXGYUwshljkP_Q/edit?usp=sharing

# Unity Setup
- change camera background color to sold and black
- adjust camera to height 0 and play around with field of view (e. g. 25), angle etc. to match mapping scenerio, if needed
- create some primitive shapes in the Hierarchy Window such as Cube, Circle, Cylinder, Capsule, Quad to test shaders

# Materials
- create a new Material in the Project Window and assign it to the MeshRenderer of each primitive shape
- select a few of the built-in URP shaders for the material and assign some values

# Shader Graph Basics
- create a new shader in the Project Window -> Create -> Shader Graph -> URP -> Unlit Shader Graph
- double click to open in Shader Graph window
- add a new Color field in the Blackboard
- connect it to the fragment program (drag into window, drag from output to fragment input)
- apply new Shader to the previously created Material that is used on the primitives
- sample Texture2D
- set test values in Blackboard (which will be manually set in the Material)
- UV (x and y mapping of textures to a 3D model)
- Multiply Node (Color multiplied with Texture, as both output a Vector4 RGBA)
- Split Node (to understand that even a color is just made up of numbers)
- Time and Modulo Nodes
- Lerp between two colors with moduloed time, then with a Blackboard Float slider
- Scene view + Always Refresh gives best results when we are not in Unity's Play Mode OR edit shaders in Play Mode
- Add, Subtract and Divide Nodes

# Play Time 01

# SubGraphs and Fun Examples
- inputs we have (texture, number = float, multiple numbers = vector, time)
- outputs we have (vertex, fragment)
- Step Node
- Lerp Node
- Blend Node (same as in Photoshop)
- show examples I brought (share link with *.unitypackage)

# Play Time 02