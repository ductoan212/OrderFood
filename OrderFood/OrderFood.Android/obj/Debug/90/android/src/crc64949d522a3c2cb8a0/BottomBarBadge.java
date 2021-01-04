package crc64949d522a3c2cb8a0;


public class BottomBarBadge
	extends android.widget.TextView
	implements
		mono.android.IGCUserPeer,
		android.view.ViewTreeObserver.OnGlobalLayoutListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGlobalLayout:()V:GetOnGlobalLayoutHandler:Android.Views.ViewTreeObserver/IOnGlobalLayoutListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("BottomNavigationBar.BottomBarBadge, BottomNavigationBar", BottomBarBadge.class, __md_methods);
	}


	public BottomBarBadge (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BottomBarBadge.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.BottomBarBadge, BottomNavigationBar", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public BottomBarBadge (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BottomBarBadge.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.BottomBarBadge, BottomNavigationBar", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public BottomBarBadge (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BottomBarBadge.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.BottomBarBadge, BottomNavigationBar", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BottomBarBadge (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == BottomBarBadge.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.BottomBarBadge, BottomNavigationBar", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onGlobalLayout ()
	{
		n_onGlobalLayout ();
	}

	private native void n_onGlobalLayout ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
