<p><h1> Dani's PSX Lens Flares for HPS1RP <h1>
 
<img src="https://i.ibb.co/9TgYW40/Lens-Flare.jpg" alt="Dani's PSX Lens Flares">
<h2>About</h2>
This is little free asset I've made specifically to work with the Haunted PS1 render pipeline for use in Unity. As of writing this the standard implementation of lens flares which Unity provides doesn't work with HPS1RP, so I knocked this together in order to provide that functionality for anyone who desires it.  The default implementation of lens flares in Unity seems very unfinished so I also aimed to add some useful features to ensure you can get a result you'll be happy with. </p>

<h2><b> Quick Setup </b></h2>

```diff
- MAKE SURE YOU ALREADY HAVE HPS1RP INSTALLED!
```
<ol> <li> Copy the folder into your project's assets folder. </li> 
<li> Add two <b><i>PSXLensFlare</i></b> components to any <b><i>GameObject</i></b> (usually it would be the same as a light source).</li>
<li> Plug in <b><i>'TorchSourceConfig'</i></b> into the first component's field in the inspector. (this is an example of a source flare) </li>
<li> Plug in <b><i>'TorchFlareConfig'</i></b> into the second component's field in the inspector. (this is an example of a standard flare) </li>
<li> Position your camera to face the lens flare source.</li>
<li> Press the play button. </li>
<li> Try messing around with the settings for <b><i>'TorchSourceConfig'</i></b> and <b><i>'TorchFlareConfig'</i></b> to try and acheive different and interesting results. </li></ol>

<h2>Tips</h2>
<ul> <li> The code is fairly well commented so if you're unsure about something have a little peek. </li>
<li> You can adjust all of the settings in the lens flare assets in realtime while in playmode. </li>
 <li> You can attach a <b>GameObject</b> with a small <b>BoxCollider</b> to the lens flare <b>GameObject</b>, then set it in the lens flare inspector field. This will mean that the lens flare won't show unless it makes line of sight with this collider (useful if you don't want the effect to work through walls etc.)  </li>
<li> You don't <b><i>need</b></i> to assign a value to the <b> active camera </b> field in the inspector if you don't want to, it will be assigned to <b>Camera.Main</b> if you leave it blank. </li>
<li> Create custom lens flare assets by Right-Clicking in the project panel and selecting <b><i>Create > Effects > Flare Config</b></i></li>
<li> You can add multiple <b><i>LensFlare</i></b> components to the same GameObject in order to
 achieve different viewing angles or any other custom behavior that is relevant.</ul>

<h2>Cautions</h2>
<ul><li> This is <b><i>ONLY<i/></b> intented for use with the <b><i>Haunted PS1 Render Pipeline (HPS1RP)</b></i> maybe it would work with other pipelines or the default ones but I haven't tested it.</li>
<li> There may be bugs, as this was thrown together pretty quickly so contact me if you have any issues </li>
<li> Right now there isn't any previewing of the effect in the scene view, I will implement this only if there is enough interest as it's not that important for our project. </li></ul>

<h2>Contact</h2>
<p>Email: devbeforebed@gmail.com<br>
IG: <a href="https://www.instagram.com/lord_arkadia/">@Lord_Arkadia</a> <br>
YT: <a href="https://www.youtube.com/daniarkadia">Dani Arkadia - Survival Revival Games</a>
 
 <h2><a href=https://store.steampowered.com/app/1696960/Lake_Haven__Chrysalis/?l=czech&curator_clanid=4777282&utm_source=SteamDB">Wishlist our game on Steam!</a></h2>
<a href= "https://store.steampowered.com/app/1696960/Lake_Haven__Chrysalis/?l=czech&curator_clanid=4777282&utm_source=SteamDB"><img src=https://cdn.akamai.steamstatic.com/steam/apps/1696960/header.jpg?t=1636488372> <br>
<a href="https://www.instagram.com/lake_haven_ps1/">@Lake_Haven_PS1</a>
