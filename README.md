# EZRP - A Simple Discord RichPresence integration for Unity.

# Features
**Available**
- Simple static RichPresence
- Scene-Based RichPresence (Data changes based on the scene that you are currently on)
- Update notice, it connects to a webserver to check if the version number there matches the current version you have installed, and if they don't, you get a notice inside the editor in the script itself.

**Planned**
- Party invites (See image below)

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/086c0e91-583f-4001-af39-b9230ac34228)

- A nicer, simpler interface

# Faq
Q: Does this collect my data?

A: No, it does not collect your data. You can check the code itself, it is attached above. Most of the code in this project either way is from the custom-editor script that I have created and from the [Discord Game SDK](https://discord.com/developers/docs/game-sdk/sdk-starter-guide)

Q: Will there be updates to this?

A: Yes, there will be updates to make the code look nicer and to have more functions. (See planned features section.)

# Support development
If you like this asset and want to help me out consider donating on [Ko-Fi](https://ko-fi.com/andrasdaradics)

# Getting started
## Step 1 - Creating an application on the Discord Developer Website.
1 - Search for the [Discord Developer Portal](https://discord.com/developers/applications)

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/12d7126c-36f5-40d4-b3d0-88bdd16febcb)


2 - Log in to your Discord account.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/20d3aef6-b3a6-40b3-a971-5edd200571ec)

3 - Create an application.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/5b11df13-b861-40e6-88cb-ac6dc5147473)

## Step 2 - Importing the asset

**Method A:**

1 - Go to the releases tab of the GitHub repository.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/73396e78-5fa6-4882-a9c6-1aafcd8fe6c7)

2 - Select the version that you'd like (The newest version is always recommended) and download the `.unitypackage` file.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/2bd796f9-fa08-4c2a-b3a8-6fb4fa2e489a)

3A - Once the file is downloaded, open your project in Unity and double-click the file in File Explorer to import it and you should see this.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/c60803cc-a363-4062-b9f1-2ba44572315f)

**Method B:**

1 - Download the source code, and then drag and drop the "EZRP" and the "Plugin" folder into your project's "Assets" folder.

## Step 3 - Setting up the asset

1 - Go to the first scene (Scene with a build index of 0) of your game and right-click in the scene hierarchy.

2 - After right-clicking, if you imported the asset correctly, you should see a "Discord Rich Presence" menu.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/09a9198b-c41c-4280-9831-ff2b5f0a5132)

3 - Hover your mouse over it and click "Add RichPresence" and a game object with the RichPresence tag and script attached to it should appear.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/77805da6-4381-4039-97b6-76d8da30cae3)

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/d4d6230e-b2b8-4cd2-b5fc-23c651524120)

4 - Enter the Application ID. 

Remember the Application we created back in Step 1? Go back to the discord developer webpage, select the Application (if it's not already selected) and you should see this.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/9ab17cf1-db82-4ef5-88d0-4b45a37ee90c)

From here, you will need to copy the Application ID.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/6e463198-b839-44fd-80e1-5f15726268e3)

You will need to paste it into the script of the game object added in the previous step.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/d68fbebf-7c2f-4d1c-9956-823a4ea7a433)

5A - Static RichPresence.

From the two options that appeared, tick the checkbox next to "Static RichPresence" and then it should look like this

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/aa967ebf-6977-41bf-869c-2717c4a7c5b1)

6A - Input the details that you want displayed. 

Example:

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/e41d4132-f74b-487a-96db-4c16f9ee51bd)

When you enter play mode, it should change from "Not connected" to "Connected" and it should look like this in Discord. If there are any errors they will appear.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/00ff2e64-49eb-4ec8-81fa-fbaeb9c978d2)

7A - Adding images.

Back to the Discord Developer Portal webpage. Here, on the left sidebar, you will have to click "Rich Presence".

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/53af1b0e-7319-4376-a55f-0c6521fc1c90)

Once you click on it you should see this

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/92887eb0-bedb-4c19-b7f1-ee8768478017)

Here, you will click "Add Image(s)" and you will upload the image that you want to display. For this example, I am going to upload the logo of the asset.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/adeb4e37-98ca-4df9-a650-5b9a5222edcb)

After uploading the image you will have to give it a key, basically the name of the image, and then press "Save Changes".

Back to Unity, on the RichPresence, you will have to input the key (name) of the image you just uploaded.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/7c9e587a-da45-46c2-8aa5-c49dd3cfbd1d)

If you want to have some text while you hover over it just type the text you want into the "Large Image Text" field.  

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/0ef3fbd5-a8fe-4fe2-98ce-198c8ec33db1)

Press play, and check your Discord profile, and the image is there!

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/193abdd3-09b9-4c67-aea0-139e6f43d418)

5B - Scene-Based RichPresence.

Now this is where things get funky. In the script, click the empty tick the check box next to "Scene Based RichPresence". After ticking it you should see this.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/8930cae7-ea6c-429b-8dc3-2f67b32d7289)

Create a folder, wherever you want to, preferably in the "Assets" folder so you can find it with ease and name it "Rich Presence Items"

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/a246490d-c695-4538-b73d-38405d1572e6)

Go inside this folder, right-click, and in the "Create" context menu there should be "Discord Rich Presence" at the top.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/9b1a93f8-5162-48d2-b521-078a32972387)

Hover over it and then click "Rich Presence Item".

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/bea96ba8-d1d2-4650-b64d-b522b02acc46)

This will create a scriptable object, name it whatever you want it to.

When you select the object you just created you should see this in the "Inspector" tab.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/c98cd0d8-f4ce-4da4-85ae-33fffaef1d84)

Here, you will input the details, state, etc of the RichPresence.

In the example case, I made one for the "Main Menu" and one for "Level 1" and they look like this.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/44c6276e-50a4-47bb-8fe3-2adfa97e8cbe)
![image](https://github.com/andrasdaradici/ezrp/assets/90605554/640cff1f-00f8-4f3e-af07-91c4d0fa6fe3)

Back in the scene hierarchy, select your RichPresence and attach the RichPresence Items you just created to the script.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/26021382-b52c-47ec-8159-5a3cfbf1a893)

How does this work?

You see, the lists have an index number in front of every single object.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/f98231d9-4c33-432a-ac59-288a60184ec6)

And when you add the scenes of your game into the build settings, they have an index too.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/4a9bb6f4-d59e-42fd-b01c-158fada2378b)

Thus an object with the index 0 in the list will display on the scene with the index 0 in the build settings.

So in my case, when I'm in the main menu it will display the data from the main menu file, and when I'm in level 1 it will display the data from the level 1 file.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/0ff0775a-968c-464e-9905-76f043b3f40b)
![image](https://github.com/andrasdaradici/ezrp/assets/90605554/521685bd-b44f-4797-9d74-db72840a80b6)

9 - Other functions.
There's also this this toggle at the bottom of the script, you can enable it to show how much time a player spent in the game since they opened it.

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/1644d28c-399a-4571-8fcf-c1482a0c9ff0)

![image](https://github.com/andrasdaradici/ezrp/assets/90605554/ee646ec1-c1f1-463c-8f29-c6f1f5b5e0f9)

## Further help

For further help check out the documentation (COMING SOON).
