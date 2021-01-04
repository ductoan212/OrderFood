package crc64c24f44e46c13f9f8;


public class CustomAnimatorListenerAdapter
	extends android.animation.AnimatorListenerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationEnd:(Landroid/animation/Animator;)V:GetOnAnimationEnd_Landroid_animation_Animator_Handler\n" +
			"n_onAnimationCancel:(Landroid/animation/Animator;)V:GetOnAnimationCancel_Landroid_animation_Animator_Handler\n" +
			"";
		mono.android.Runtime.register ("BottomNavigationBar.Adapters.CustomAnimatorListenerAdapter, BottomNavigationBar", CustomAnimatorListenerAdapter.class, __md_methods);
	}


	public CustomAnimatorListenerAdapter ()
	{
		super ();
		if (getClass () == CustomAnimatorListenerAdapter.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Adapters.CustomAnimatorListenerAdapter, BottomNavigationBar", "", this, new java.lang.Object[] {  });
	}

	public CustomAnimatorListenerAdapter (android.view.View p0, int p1, android.view.View p2)
	{
		super ();
		if (getClass () == CustomAnimatorListenerAdapter.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Adapters.CustomAnimatorListenerAdapter, BottomNavigationBar", "Android.Views.View, Mono.Android:System.Int32, mscorlib:Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void onAnimationEnd (android.animation.Animator p0)
	{
		n_onAnimationEnd (p0);
	}

	private native void n_onAnimationEnd (android.animation.Animator p0);


	public void onAnimationCancel (android.animation.Animator p0)
	{
		n_onAnimationCancel (p0);
	}

	private native void n_onAnimationCancel (android.animation.Animator p0);

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
