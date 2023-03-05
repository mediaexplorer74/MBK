// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.BandImage
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using System.IO;
//using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
//using Windows.Graphics.Imaging;
//using Windows.Storage.Streams;
//using Windows.UI.Xaml.Media.Imaging;

namespace Microsoft.Band.Portable
{
  public sealed class BandImage
  {
    private WriteableBitmap nativeBitmap;

    private BandImage()
    {
    }

    internal BandImage(WriteableBitmap bitmap, int width, int height)
    {
      this.nativeBitmap = bitmap;
      this.Width = width;
      this.Height = height;
    }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public static BandImage FromWriteableBitmap(WriteableBitmap writeableBitmap)
    {
        return default;//new BandImage(writeableBitmap,
                //     ((BitmapSource)writeableBitmap).PixelWidth,
                //     ((BitmapSource)writeableBitmap).PixelHeight);
    }

    public WriteableBitmap ToWriteableBitmap() => this.nativeBitmap;

    public static async Task<BandImage> FromStreamAsync(Stream stream)
    {
      BandImage bandImage = default;
      //using (IRandomAccessStream fileStream = WindowsRuntimeStreamExtensions.AsRandomAccessStream(stream))
      //{
      //  WriteableBitmap bitmap = new WriteableBitmap(1, 1);
      //  await ((BitmapSource) bitmap).SetSourceAsync(fileStream);
      //  bandImage = BandImage.FromWriteableBitmap(bitmap);
      //}
      return bandImage;
    }

    public async Task<Stream> ToStreamAsync()
    {
      WriteableBitmap native = this.ToWriteableBitmap();
      /*
      InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
      BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, (IRandomAccessStream) stream);
      using (Stream pixelStream = WindowsRuntimeBufferExtensions.AsStream(native.PixelBuffer))
      {
        byte[] pixels = new byte[pixelStream.Length];
        int num = await pixelStream.ReadAsync(pixels, 0, pixels.Length);
        encoder.SetPixelData((BitmapPixelFormat) 87, (BitmapAlphaMode) 1, (uint) ((BitmapSource) native).PixelWidth, (uint) ((BitmapSource) native).PixelHeight, 96.0, 96.0, pixels);
        await encoder.FlushAsync();
        pixels = (byte[]) null;
      }
      */
      return default;//WindowsRuntimeStreamExtensions.AsStream((IRandomAccessStream) stream);
    }
  }
}
