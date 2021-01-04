package crc64f8f085afb9a48114;


public class NavBarMagicOnGlobalLayoutListener
	extends java.lang.Object
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
		mono.android.Runtime.register ("BottomNavigationBar.Listeners.NavBarMagicOnGlobalLayoutListener, BottomNavigationBar", NavBarMagicOnGlobalLayoutListener.class, __md_methods);
	}


	public NavBarMagicOnGlobalLayoutListener ()
	{
		super ();
		if (getClass () == NavBarMagicOnGlobalLayoutListener.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Listeners.NavBarMagicOnGlobalLayoutListener, BottomNavigationBar", "", this, new java.lang.Object[] {  });
	}

	public NavBarMagicOnGlobalLayoutListener (crc64949d522a3c2cb8a0.BottomBar p0, android.view.View p1, int p2, boolean p3, boolean p4)
	{
		super ();
		if (getClass () == NavBarMagicOnGlobalLayoutListener.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Listeners.NavBarMagicOnGlobalLayoutListener, BottomNavigationBar", "BottomNavigationBar.BottomBar, BottomNavigationBar:Android.Views.View, Mono.Android:System.Int32, mscorlib:System.Boolean, mscorlib:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
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
