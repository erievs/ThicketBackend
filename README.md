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

(https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#create-the-database)

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

