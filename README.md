# GamesEngines1
In this project I intend to create an procedural genrated infinite galaxy with randomised planets being infinitly spawned around the player (spaceship). Im going to generate a mountainous terrain on the planets using code which i hope to add textures to that change depending on their amplitude for example snow at the top of the mountain, then rock, then grass etc.

What I achieved:
I managed to create a sphere from 6 procedurally generated meshes. The Sphere was basicially a cube shape that i rounded into a sphere. I made a class script called AudioTFace which generated a mesh then I made a game object for the sphere called planet and added an AudioPlanet script to it which made an array of 6 AudioTFaces creating the spere. 

I then created a script called AudioPeer to get the spectrum data of the audio source that i am using for the visualizer using 512 samples.

Then I went back into the AudioTFace class that I created for generating the 6 meshes for the sphere and I multiplied the vertices on the mesh's by the samples i recieved from my AudioPeer script. I also multiplied the vertices by perlin noise. This created a great sphereical visualizer effect.

To make the visualizer look better I used shader graph to make the sphere look better The shader pulses between 2 colours with a glow effect on the edge of the sphere. 

I created a rotation script to make the sphere spin.

I created a canvas to control the visualizer while the project is playing. I added a volume and pitch slider to change the volume and pitch of the audio source. I then made an intensity slider to change how much the vertices are multipied by based on the spectrum data, basically making the sphere be effected more or less by the audio. Then I added more songs so that you can chan change the song and see how different songs effect the visualizer.

Then I created a new visualizer because I felt the sphere looked bare in the scene by itself. I made the vusualizer out of a cube prefav that is generated into a circle around the sphere visualizer. The cubes colours are randomly changed every frame. They are being multiplied by the spectrum data as well as the sphere. I added the rotation script to the new visualizer as well so it rotates arounds the sphere visualizer. Then I added an intensity slider to the canvas to control the intensity of the new visualizer.
