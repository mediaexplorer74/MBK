// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Element
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;
using System;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public abstract class Element
  {
    private PageRect rectangle;

    public Element()
    {
      this.ElementId = (short) -1;
      this.HorizontalAlignment = HorizontalAlignment.Left;
      this.VerticalAlignment = VerticalAlignment.Top;
      this.Margins = Margins.Empty;
      this.Rect = PageRect.Empty;
    }

    public short ElementId { get; set; }

    public HorizontalAlignment HorizontalAlignment { get; set; }

    public VerticalAlignment VerticalAlignment { get; set; }

    public Margins Margins { get; set; }

    public PageRect Rect
    {
      get => this.rectangle;
      set => this.rectangle = value;
    }

    public PagePoint Location
    {
      get => this.rectangle.Location;
      set => this.rectangle.Location = value;
    }

    public PageSize Size
    {
      get => this.rectangle.Size;
      set => this.rectangle.Size = value;
    }

    internal Element(PageElement native)
    {
      this.ElementId = native.ElementId.Value;
      this.Rect = native.Rect.FromNative();
      this.HorizontalAlignment = native.HorizontalAlignment.FromNative();
      this.Margins = native.Margins.FromNative();
      this.VerticalAlignment = native.VerticalAlignment.FromNative();
    }

    internal PageElement ToNative() => this.ToNative((PageElement) null);

    internal virtual PageElement ToNative(PageElement element)
    {
      PageElement native = this.EnsureDerived<PageElement>(element, false);
      if (this.ElementId > (short) 0)
        native.ElementId = new short?(this.ElementId);
      if (this.Rect != PageRect.Empty)
        native.Rect = this.Rect.ToNative();
      native.HorizontalAlignment = this.HorizontalAlignment.ToNative();
      if (this.Margins != Margins.Empty)
        native.Margins = this.Margins.ToNative();
      native.VerticalAlignment = this.VerticalAlignment.ToNative();
      return native;
    }

    protected T EnsureDerived<T>(PageElement element) where T : PageElement => this.EnsureDerived<T>(element, true);

    protected T EnsureDerived<T>(PageElement element, bool allowNull) where T : PageElement
    {
      if (element == null)
      {
        if (allowNull)
          return default (T);
        throw new ArgumentNullException(nameof (element));
      }
      return element is T obj ? obj : throw new ArgumentException(nameof (element), string.Format("element must be of type {0} or a derived type.", (object) typeof (T).FullName));
    }
  }
}
