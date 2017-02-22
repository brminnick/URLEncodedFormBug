# URLEncodedFormBug
A Xamarin.Forms solution to reproduce an HttpClient problem experienced in Cycle 9

This code uses `HttpClient.PostAsync` to submit `HttpContent` containing `FormUrlEncodedContent` to a website. If `HttpClient.PostAsync` is successful, the html response `Content` should contain the string `Correct!`.

## When Does The Error Occur?
 - Xamarin.iOS on Cycle 9, using `NSUrlSession` for the HttpClient Implementation
   - Cycle 9 Beta Release as of 22 Febrary 2017
 
## When Does the Error **Not** Occur?
 - Xamarin.iOS on Cycle 8
   - Cycle 8 Stable Release as of 22 Febrary 2017
 - Xamarin.iOS on Cycle 9, using `Managed (default)` for the HttpClient Implementation
    - Cycle 9 Beta Release as of 22 Febrary 2017
 - Xamarin.Android on Cycle 9 using `AndroidClientHandler` for the HttpClient Implementation
    - Cycle 9 Beta Release as of 22 Febrary 2017
 - Xamarin.Android on Cycle 9 using `Managed (HttpClientHandler)` for the HttpClient Implementation
    - Cycle 9 Beta Release as of 22 Febrary 2017
 - Creating the `Post` request using [PostMan](https://www.getpostman.com), [link to postman collection](https://github.com/brminnick/URLEncodedFormBug/blob/master/MondayPunday.postman_collection)
 

## Steps to reproduce bug:
 1. Download and open URLEncodedFormBug.sln in Xamarin Studio using the Environment Configuration below
 2. Set the URLEncodedFormBug.iOS as the Startup Project
 3. Build, Deploy and run URLEncodedFormBug.iOS on a Device or iOS10 Simulator
 4. Click the Submit Button
 5. `DisplayAlert` shows `Failed` because the HTML Response doesn't contain `Correct!`
 

##Environment
=== Xamarin Studio Enterprise ===

Version 6.2 (build 1812)
Installation UUID: 3ac98a61-67a7-411f-b124-19833ec9a519
Runtime:
 - Mono 4.8.0 (mono-4.8.0-branch/9ac5bf2) (64-bit)
 - GTK+ 2.24.23 (Raleigh theme)
 - Package version: 408000489

=== NuGet ===

Version: 3.5.0.0

=== Xamarin.Profiler ===

Version: 1.1.99
Location: /Applications/Xamarin Profiler.app/Contents/MacOS/Xamarin Profiler

=== Xamarin.Android ===

Version: 7.1.0.35 (Xamarin Enterprise)
Android SDK: /Users/brandonm/Library/Developer/Xamarin/android-sdk-macosx
	Supported Android versions:
		4.1 (API level 16)
		7.0 (API level 24)
		7.1 (API level 25)

SDK Tools Version: 25.2.5
SDK Platform Tools Version: 25.0.3
SDK Build Tools Version: 25.0.2

Java SDK: /usr
java version "1.8.0_102"
Java(TM) SE Runtime Environment (build 1.8.0_102-b14)
Java HotSpot(TM) 64-Bit Server VM (build 25.102-b14, mixed mode)

Android Designer EPL code available here:
https://github.com/xamarin/AndroidDesigner.EPL

=== Xamarin Android Player ===

Version: 0.6.5
Location: /Applications/Xamarin Android Player.app

=== Xamarin Inspector ===

Version: 1.1.1.0
Hash: 607f1ba
Branch: 1.1-release
Build date: Thu, 16 Feb 2017 18:57:39 GMT

=== Apple Developer Tools ===

Xcode 8.2.1 (11766.1)
Build 8C1002

=== Xamarin.Mac ===

Version: 3.0.0.391 (Xamarin Enterprise)

=== Xamarin.iOS ===

Version: 10.4.0.121 (Xamarin Enterprise)
Hash: 9d6e1ab
Branch: cycle9
Build date: 2017-02-10 12:10:51-0500

=== Build Information ===

Release ID: 602001812
Git revision: 33e69e5df3c62c2c4084cf1b8de26fda93c5e843
Build date: 2017-02-09 12:18:09-05
Xamarin addins: 984f6bd4e491490d1cdf37352594300dab2b1597
Build lane: monodevelop-lion-cycle9

=== Operating System ===

Mac OS X 10.12.3
Darwin brandonm-mac.local 16.4.0 Darwin Kernel Version 16.4.0
    Thu Dec 22 22:53:21 PST 2016
    root:xnu-3789.41.3~3/RELEASE_X86_64 x86_64

