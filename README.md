# DDS-Image-Wrapper
A simple C# class that wraps a byte[] from a ".dds" image file and provides helper properties for easy access to header data.


# Sample Usage

```
DDSImage image = new DDSImage(System.IO.File.ReadAllBytes("Grasslands.dds"));
Console.WriteLine(string.Format("Loaded Image: {0}x{1}  Format:{2}",image.Width,image.Height,image.pixelFormat.ToString()));
```

## Unity3D Extensions
Add the PVRUnityExtensions.cs class to your Unity Project to enable the following convenience methods.  

- LoadIntoTexture() : Returns Texture2D
- GetTextureFormat() : Returns UnityEngine.TextureFormat
- IsValidTextureFormat() : Returns TRUE if the PixelFormat can be mapped to a UnityEngine.TextureFormat

> When, where, or why would I use this in Unity?

If your project is loading images at runtime for use as textures, using a preformatted image allows you to skip the slow ImageConversion step. For my use case, 30 jpg images took ~30s to load total.   30 DDS images (precompressed to DXT5) took ~1s to load.  Obviously, your mileage may vary.

Alternatively, check out the PVR Image format.  I wrote a wrapper for it here: [PVR-Image-Wrapper](https://github.com/jmschrack/PVR-Image-Wrapper)
