package crc648170574f428fcc31;


public abstract class VerticalScrollingBehavior_1
	extends android.support.design.widget.CoordinatorLayout.Behavior
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStartNestedScroll:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)Z:GetOnStartNestedScroll_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler\n" +
			"n_onNestedScrollAccepted:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)V:GetOnNestedScrollAccepted_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler\n" +
			"n_onStopNestedScroll:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V:GetOnStopNestedScroll_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler\n" +
			"n_onNestedScroll:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIII)V:GetOnNestedScroll_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIHandler\n" +
			"n_onNestedPreScroll:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[I)V:GetOnNestedPreScroll_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIHandler\n" +
			"n_onNestedFling:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FFZ)Z:GetOnNestedFling_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZHandler\n" +
			"n_onNestedPreFling:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FF)Z:GetOnNestedPreFling_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFHandler\n" +
			"n_onApplyWindowInsets:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/support/v4/view/WindowInsetsCompat;)Landroid/support/v4/view/WindowInsetsCompat;:GetOnApplyWindowInsets_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_support_v4_view_WindowInsetsCompat_Handler\n" +
			"n_onSaveInstanceState:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;)Landroid/os/Parcelable;:GetOnSaveInstanceState_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Handler\n" +
			"";
		mono.android.Runtime.register ("BottomNavigationBar.Scrollswetness.VerticalScrollingBehavior`1, BottomNavigationBar", VerticalScrollingBehavior_1.class, __md_methods);
	}


	public VerticalScrollingBehavior_1 ()
	{
		super ();
		if (getClass () == VerticalScrollingBehavior_1.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Scrollswetness.VerticalScrollingBehavior`1, BottomNavigationBar", "", this, new java.lang.Object[] {  });
	}


	public VerticalScrollingBehavior_1 (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == VerticalScrollingBehavior_1.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Scrollswetness.VerticalScrollingBehavior`1, BottomNavigationBar", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean onStartNestedScroll (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, android.view.View p3, int p4)
	{
		return n_onStartNestedScroll (p0, p1, p2, p3, p4);
	}

	private native boolean n_onStartNestedScroll (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, android.view.View p3, int p4);


	public void onNestedScrollAccepted (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, android.view.View p3, int p4)
	{
		n_onNestedScrollAccepted (p0, p1, p2, p3, p4);
	}

	private native void n_onNestedScrollAccepted (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, android.view.View p3, int p4);


	public void onStopNestedScroll (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2)
	{
		n_onStopNestedScroll (p0, p1, p2);
	}

	private native void n_onStopNestedScroll (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2);


	public void onNestedScroll (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, int p3, int p4, int p5, int p6)
	{
		n_onNestedScroll (p0, p1, p2, p3, p4, p5, p6);
	}

	private native void n_onNestedScroll (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, int p3, int p4, int p5, int p6);


	public void onNestedPreScroll (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, int p3, int p4, int[] p5)
	{
		n_onNestedPreScroll (p0, p1, p2, p3, p4, p5);
	}

	private native void n_onNestedPreScroll (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, int p3, int p4, int[] p5);


	public boolean onNestedFling (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, float p3, float p4, boolean p5)
	{
		return n_onNestedFling (p0, p1, p2, p3, p4, p5);
	}

	private native boolean n_onNestedFling (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, float p3, float p4, boolean p5);


	public boolean onNestedPreFling (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, float p3, float p4)
	{
		return n_onNestedPreFling (p0, p1, p2, p3, p4);
	}

	private native boolean n_onNestedPreFling (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2, float p3, float p4);


	public android.support.v4.view.WindowInsetsCompat onApplyWindowInsets (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.support.v4.view.WindowInsetsCompat p2)
	{
		return n_onApplyWindowInsets (p0, p1, p2);
	}

	private native android.support.v4.view.WindowInsetsCompat n_onApplyWindowInsets (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.support.v4.view.WindowInsetsCompat p2);


	public android.os.Parcelable onSaveInstanceState (android.support.design.widget.CoordinatorLayout p0, android.view.View p1)
	{
		return n_onSaveInstanceState (p0, p1);
	}

	private native android.os.Parcelable n_onSaveInstanceState (android.support.design.widget.CoordinatorLayout p0, android.view.View p1);

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
