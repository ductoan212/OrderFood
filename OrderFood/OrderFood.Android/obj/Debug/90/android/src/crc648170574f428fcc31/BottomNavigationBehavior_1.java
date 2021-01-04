package crc648170574f428fcc31;


public class BottomNavigationBehavior_1
	extends crc648170574f428fcc31.VerticalScrollingBehavior_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_layoutDependsOn:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z:GetLayoutDependsOn_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler\n" +
			"n_onDependentViewRemoved:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V:GetOnDependentViewRemoved_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler\n" +
			"n_onDependentViewChanged:(Landroid/support/design/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z:GetOnDependentViewChanged_Landroid_support_design_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler\n" +
			"";
		mono.android.Runtime.register ("BottomNavigationBar.Scrollswetness.BottomNavigationBehavior`1, BottomNavigationBar", BottomNavigationBehavior_1.class, __md_methods);
	}


	public BottomNavigationBehavior_1 ()
	{
		super ();
		if (getClass () == BottomNavigationBehavior_1.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Scrollswetness.BottomNavigationBehavior`1, BottomNavigationBar", "", this, new java.lang.Object[] {  });
	}


	public BottomNavigationBehavior_1 (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BottomNavigationBehavior_1.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Scrollswetness.BottomNavigationBehavior`1, BottomNavigationBar", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean layoutDependsOn (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2)
	{
		return n_layoutDependsOn (p0, p1, p2);
	}

	private native boolean n_layoutDependsOn (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2);


	public void onDependentViewRemoved (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2)
	{
		n_onDependentViewRemoved (p0, p1, p2);
	}

	private native void n_onDependentViewRemoved (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2);


	public boolean onDependentViewChanged (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2)
	{
		return n_onDependentViewChanged (p0, p1, p2);
	}

	private native boolean n_onDependentViewChanged (android.support.design.widget.CoordinatorLayout p0, android.view.View p1, android.view.View p2);

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
