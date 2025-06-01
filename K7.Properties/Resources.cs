using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace K7.Properties;

[CompilerGenerated]
[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceMan, null))
			{
				ResourceManager resourceManager = new ResourceManager("K7.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Icon icon
	{
		get
		{
			object @object = ResourceManager.GetObject("icon", resourceCulture);
			return (Icon)@object;
		}
	}

	internal static Bitmap icon_32X32
	{
		get
		{
			object @object = ResourceManager.GetObject("icon_32X32", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap read
	{
		get
		{
			object @object = ResourceManager.GetObject("read", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap write
	{
		get
		{
			object @object = ResourceManager.GetObject("write", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Icon 标题
	{
		get
		{
			object @object = ResourceManager.GetObject("标题", resourceCulture);
			return (Icon)@object;
		}
	}

	internal Resources()
	{
	}
}
