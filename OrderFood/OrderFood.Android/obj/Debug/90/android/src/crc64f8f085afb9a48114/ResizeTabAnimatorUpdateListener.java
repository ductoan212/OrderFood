package crc64f8f085afb9a48114;


public class ResizeTabAnimatorUpdateListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.animation.ValueAnimator.AnimatorUpdateListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationUpdate:(Landroid/animation/ValueAnimator;)V:GetOnAnimationUpdate_Landroid_animation_ValueAnimator_Handler:Android.Animation.ValueAnimator/IAnimatorUpdateListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("BottomNavigationBar.Listeners.ResizeTabAnimatorUpdateListener, BottomNavigationBar", ResizeTabAnimatorUpdateListener.class, __md_methods);
	}


	public ResizeTabAnimatorUpdateListener ()
	{
		super ();
		if (getClass () == ResizeTabAnimatorUpdateListener.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Listeners.ResizeTabAnimatorUpdateListener, BottomNavigationBar", "", this, new java.lang.Object[] {  });
	}

	public ResizeTabAnimatorUpdateListener (android.view.View p0, android.animation.ValueAnimator p1)
	{
		super ();
		if (getClass () == ResizeTabAnimatorUpdateListener.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Listeners.ResizeTabAnimatorUpdateListener, BottomNavigationBar", "Android.Views.View, Mono.Android:Android.Animation.ValueAnimator, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public void onAnimationUpdate (android.animation.ValueAnimator p0)
	{
		n_onAnimationUpdate (p0);
	}

	private native void n_onAnimationUpdate (android.animation.ValueAnimator p0);

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
