package crc64c24f44e46c13f9f8;


public class CustomViewPropertyAnimatorListenerAdapter
	extends android.support.v4.view.ViewPropertyAnimatorListenerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationEnd:(Landroid/view/View;)V:GetOnAnimationEnd_Landroid_view_View_Handler\n" +
			"n_onAnimationCancel:(Landroid/view/View;)V:GetOnAnimationCancel_Landroid_view_View_Handler\n" +
			"";
		mono.android.Runtime.register ("BottomNavigationBar.Adapters.CustomViewPropertyAnimatorListenerAdapter, BottomNavigationBar", CustomViewPropertyAnimatorListenerAdapter.class, __md_methods);
	}


	public CustomViewPropertyAnimatorListenerAdapter ()
	{
		super ();
		if (getClass () == CustomViewPropertyAnimatorListenerAdapter.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Adapters.CustomViewPropertyAnimatorListenerAdapter, BottomNavigationBar", "", this, new java.lang.Object[] {  });
	}

	public CustomViewPropertyAnimatorListenerAdapter (android.view.View p0, int p1, android.view.View p2)
	{
		super ();
		if (getClass () == CustomViewPropertyAnimatorListenerAdapter.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Adapters.CustomViewPropertyAnimatorListenerAdapter, BottomNavigationBar", "Android.Views.View, Mono.Android:System.Int32, mscorlib:Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void onAnimationEnd (android.view.View p0)
	{
		n_onAnimationEnd (p0);
	}

	private native void n_onAnimationEnd (android.view.View p0);


	public void onAnimationCancel (android.view.View p0)
	{
		n_onAnimationCancel (p0);
	}

	private native void n_onAnimationCancel (android.view.View p0);

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
