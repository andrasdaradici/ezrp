![image](https://github.com/andrasdaradici/ezrp/assets/90605554/674240c2-45fe-4a7a-91e8-ea955beca0c4)# EZRP - A Simple Discord RichPresence integration for Unity.

# Features
**Available**
- Simple static RichPresence
- Scene-Based RichPresence (Data changes based on the scene that you are currently on)
- Update notice, it connects to a webserver to check if the version number there matches the current version you have installed, and if they don't, you get a notice inside the editor in the script itself.

**Planned**
- Party invites (See image below)

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/8b7ba6d8-63f6-497f-9c28-ba65d8c27046)
- A nicer, simpler interface

# Faq
Q: Does this collect my data?
A: No, it does not collect your data. You can check the code itself, it is attached above. Most of the code in this project either way is from the custom-editor script that I have created and from the [Discord Game SDK](https://discord.com/developers/docs/game-sdk/sdk-starter-guide)

Q: Will there be updates to this?
A: Yes, there will be updates to make the code look nicer and to have more functions. (See planned features section.)

# Getting started
## Step 1 - Creating an application on the Discord Developer Website.
1 - Search for the [Discord Developer Portal](https://discord.com/developers/applications)

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/cd5e92f6-d518-4cf1-82ef-0741e9b5b455)

2 - Log in to your Discord account.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/80158021-8e64-40eb-8d23-db951bdbf47b)

3 - Create an application.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/a3b7a687-1c93-4a94-a4dd-1e2a8bca4fa2)

## Step 2 - Importing the asset

**Method A:**

1 - Go to the releases tab of the GitHub repository.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/3dbe964f-e00d-44e8-8edb-5f07f8cfdd0c)

2 - Select the version that you'd like (The newest version is always recommended) and download the `.unitypackage` file.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/02cfdbc2-323b-4043-b4f7-638a1696b463)

3A - Once the file is downloaded, open your project in Unity and double-click the file in File Explorer to import it and you should see this.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/c69b5d3e-3ce6-49f9-9d27-e05cb2ac2ca8)

**Method B:**

1 - Download the source code, and then drag and drop the "EZRP" and the "Plugin" folder into your project's "Assets" folder.

## Step 3 - Setting up the asset

1 - Go to the first scene (Scene with a build index of 0) of your game and right-click in the scene hierarchy.

2 - After right-clicking, if you imported the asset correctly, you should see a "Discord Rich Presence" menu.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/b08597a3-b02d-4c77-899f-87940de8fc3f)

3 - Hover your mouse over it and click "Add RichPresence" and a game object with the RichPresence tag and script attached to it should appear.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/8f71b660-3ee0-450e-b929-4b0d236a87b7)
![image](https://github.com/andrasdaradici/ezrp/assets/90605554/0793c3f6-1ac3-4e5a-8bc4-29f2d140c797)

4 - Enter the Application ID. 

Remember the Application we created back in Step 1? Go back to the discord developer webpage, select the Application (if it's not already selected) and you should see this.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/9c4913c6-a4d6-4394-837f-689ab2735d97)

From here, you will need to copy the Application ID.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/cfcbf028-4718-47d5-8e5a-e2d83f95796c)

You will need to paste it into the script of the game object added in the previous step.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/80962c17-b54e-4291-a01e-d8088b4d665c)

5A - Static RichPresence.

From the two options that appeared, tick the checkbox next to "Static RichPresence" and then it should look like this

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/9828a8ce-c02d-4fa1-8b32-4663a4baef29)

6B - Input the details that you want displayed. 

Example:
![image](https://github.com/andrasdaradici/ezrp/assets/90605554/f08df04a-8a95-403b-9ed4-f6ec68152547)

When you enter play mode, it should change from "Not connected" to "Connected" and it should look like this in Discord. If there are any errors they will appear.
![image](https://github.com/andrasdaradici/ezrp/assets/90605554/a01e6f7b-a07c-4a4e-b2a7-b3b1dcc4faa5)

7B - Adding images.

Back to the Discord Developer Portal webpage. Here, on the left sidebar, you will have to click "Rich Presence".

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/52ad28ef-2ac8-4311-bb5c-3542abc76749)

Once you click on it you should see this

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/344baab7-9b90-454e-9d9d-9413ddbb30c7)

Here, you will click "Add Image(s)" and you will upload the image that you want to display. For this example, I am going to upload the logo of the asset.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/bef94856-79a3-4d1c-843a-ff1d3c7e698b)

After uploading the image you will have to give it a key, basically the name of the image, and then press "Save Changes".

Back to Unity, on the RichPresence, you will have to input the key (name) of the image you just uploaded.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/af3a44d5-6b11-4f72-a78c-5ae2be3af967)

If you want to have some text while you hover over it just type the text you want into the "Large Image Text" field.  

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/4e0e2f21-40ea-4e66-8ba1-fd4a939fe081)

Press play, and check your Discord profile, and the image is there!

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/2c2f4caa-58eb-4638-b57f-af0cf4729522)
