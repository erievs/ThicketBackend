# ShittyVineReimplementation

**NOTE THIS IS VERY INSECURE AT THE MOMMENT AND IS NOT INTENDED TO BE USE FOR A PUBLIC SERVER**

Hello World, this is my Vine server reimplementation. The story behind this is I am learning C# ASP
and I thought a good to learn backend devolpment in C# would be to reimplement Vine's server. Also
part of the reason for this is I think it'd be nice for people to be able to host their Vine instances,
**as Ivy is closed source**, Bush is written in PHP, and XVine is python and doesn't have uploads

Some Questions To Answer

Q: Why does this exsit, Ivy already exists waste of time.

A: Ivy is closed source, and well the promise of trust me bro I will open source it when I shut it down
does not fifil me with confidence.

Q: Why are you using an minimal api api, I hate those?

A: I like them over controllers, and yes I have have get requsts in different
controllers, but there's 100% more work involved than just sticking some methods
in a static class and calling it in program and passing web app to it lol. And
it doesn't matter at all lol.

Q: Should I host this publicly? 

A: No, not right now. Currently authentication is lacking and doesn't error properly and doesn't check for passwords right now. And
some endpoints aren't working just yet.


# Status/Progress/Features

[DEV READY - PURDUCTION NOT READY]

- A script that is able to take vines from [https://grapper.gabis.online/] and puts it into your instance [STARTED BUT NOT IN FOLDER RN].

- Windows Phone support [NOT STARTED]

- Custom Vine compatible client for newer arm64 based devices (one's that cannot support older apps).

- Interactions [only uploading on iPhone works right now, android is iffy].

- Notifications [NOT STARTED]

- Timelines [USER GRAPHS WORK]

- Search [NOT SUPPORT]

- PFP [Android Only(ish)]

- Auth Stuff [Passwords and such aren't being checked and more.]

- Other [There's stuff I 100% forgot to include here lol]

# Credits

- Twitter (for creating Vine)

- Microsoft (for ASP.Net Core and their great docs)

- C# (Discord server for help)

- Google (for help)

- Bush [https://github.com/retrofoxxo/bush] (for JSON to look at)

- XVine [https://github.com/bag-xml/VineX] (for JSON to look at)

- SQLite [https://sqlite.org/] (database)

# Supported Devices And Clients

Android: clients 5.xx will work (tested), anything bellow 1.4.xx won't work (timelines do not work), versions in between haven't been tested.

IOS: 1.xx+

Windows Phone: Not testes yet.

# Android Setup 

ApkTool [https://apktool.org/] 

APK signer [https://github.com/patrickfav/uber-apk-signer]

## Very Simiailr to [https://github.com/ftde0/yt2009/blob/main/apk_setup.md#decompiling-the-apk] ##

- open a terminal/cmd in the directory you downloaded apktool (and apk signer) to.

- place the downloaded vine apk into the same dir as apktool.

- run:

jar -jar apktool.jar d (yourapk).apk 

this will create a folder nambed afer your apk, containing all the things you need.

- Find (YourAPKFolder)/res/strings.xml

And modify AT LEAST

vine_media_api (this is where videos/thumbnails/avtars where on the old CDN)

vine_api (the api itself)

with your instace's adress like (refer to setup and hostname -i) 

http://192.168.1.150:8090 (do not add any slashes! INCLUDE YOUR PORT)

<string name="vine_api">http://192.168.1.150:8090</string>
<string name="vine_media_api">http://192.168.1.150:8090</string>

- run:

java -jar apktool.jar b (yourapk).apk


- then run (to sign the apk) (you may have to change ) (yourdecompiledapkfolder is the one that was made when you ran apktool.jar d)

java -jar uber-apk-signer-1.3.0.jar -a /yourdecompiledapkfolder/

- it should be good

# Windows Phone Setup 

- Soon:tm:

# IOS Setup 

- install the tweak "Vine Redirect" from [https://cydia.bag-xml.com/]

- put in your instace's adress, like http://192.168.1.150:8090

- close out of the app, and it should work

# Setup

It's fairly easy, so just follow the steps.

1 - run ```dotnet restore```

2 - in /Properties/", replace "192.168.1.(whatever it is rn) with the IP address you want. You can use ```hostname -i```, and it'll reveal your IPv4 address of the left. You also make wanna change the port
it'll use (I use 8090). 

So your base API URL will probably be like http://192.168.1.150/

3 - We need to create the database (it is SQLite)!

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef database update
```

It'll be made into /home/(user)/.config/ShittyVineRI/

(Windows it AppData IDR MacOS)

[https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#create-the-database]

# API Endpoints And Similar Info

- Our Vine's CDN Implementation 

So vine, used a CDN for video files and thumbnails and such like most sites, so we need some way to get files.

File are stored in (on Linux)

/home/(user)/.config/ShittyVineRI/

(Windows it AppData IDR MacOS)

It isn't a proper CDN, but it works.

http://{your_address}/cdn/{type}/{path}

For example

http://192.168.1.150/cdn/video/vine_fakfkaefhie.mp4 (h264)

http://192.168.1.150/cdn/thumb/vine_fakfkaefhie.jpg (JPEG)


# Miscellaneous

How To Log Out On IOS (Requires a Jailbreak!)

(BE SUPER CAREFUL HERE)
(THIS SHOULD BE SAFE IF YOU ONLY DELETE THIS CHAIN)
(IF IT HAS APPLE IN IT MAY REQUIRE YOU TO REINSTALL IOS)

1 - ssh into your device

2 - cd ..

3 - cd Keychains

4 - sqlite3 ./keychain-2.db

5 - DELETE FROM genp WHERE agrp = '43NRXF6T6B.com.vine.iphone';

