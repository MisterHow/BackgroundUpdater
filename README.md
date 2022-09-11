# BackgroundUpdater
Calling off to NASA's APOD endpoint. Pulling down the latest image, saving it and setting it as your desktop background.

# Generate API Key for APOD
Use the NASA site to generate your API key
https://api.nasa.gov/

# Set your API key in the Consts.cs
Open Consts.cs and replace 'NASA_API_KEY' with your key.

# Project Properties 
Ensure your Project Properties are set to 'Windows Application'.
This avoid a window popping up.

# Project Publishing
Publish to a Folder of your choosing, it really doesn't matter.
Set Deployment-mode to 'self-contained'
Tick all options for File publish options. 
The most important one is 'ReadyToRun compilation', the others just ensure clean structure.

# Scheduling
Open Task Scheduler.
Create a new task which runs when user logs on.
Set the action to run the .exe which was placed in the folder of your choosing.

# End Result
A .png called 'background.png' will be created or modified whenever the app runs.
If the latest pull from APOD endpoint is a video from youtube, the app will go back a day and continue to do so until the app pulls an image not source from youtube.
