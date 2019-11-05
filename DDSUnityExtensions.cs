using UnityEngine;
public static class DDSUnityExtensions{
    public static TextureFormat GetTextureFormat(this DDSImage image){
        if(image.HasFourCC){
            FourCC fourCC=image.GetPixelFormatFourCC();
            if(fourCC==("DXT1")) return TextureFormat.DXT1;
            if(fourCC==("DXT5")) return TextureFormat.DXT5;
            throw new UnityException("Unsupported PixelFormat! "+fourCC.ToString());
        }
        throw new UnityException("Unsupported Format!");
    }
    //From what I can discern, there isn't a way to determine if the image is linear or not.
    public static Texture2D LoadIntoTexture(this DDSImage image,bool linear=false){
        Texture2D tex = new Texture2D(image.Width,image.Height,image.GetTextureFormat(),image.MipMapCount,linear);
        image.LoadIntoTexture(tex);
        tex.Apply();
        return tex;
    }
    public static void LoadIntoTexture(this DDSImage image, Texture2D texture){
        texture.LoadRawTextureData(image.GetTextureData());
    }
}