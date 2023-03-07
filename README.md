# ListView BindingContext bug when using ItemsSource and ItemTemplate

The included sample illustrates 2 issues, both related to the Cell's BindingContext first being set to 
the ListView's BindingContext.

The result is the bindings in the contained ViewCell are first updated with the wrong value.
At best, this causes numerous BindingDiagnostic warnings, at worse, 
an InvalidCastException for each Cell.

There are three outcomes to this: 

1: Each Binding in the nest view fails due to missing properties.
2: A binding occurs due to coincidental property name matches.
3: An InvalidCastException(s) occur for each Cell.

The worst case is the Cell contains a type that also has an ItemsSource (e.g., it expects an IEnumerable), 
such as well the ViewCell contains a View that supports BindableLayout, such as StackLayout.

If the ListView's BindingContext implements IEnumerable, the first pass binds the StackLayout with the 
wrong values.  If the ListView's BindingContext does not implement IEnumerable, an InvalidCastException
is thrown for each item in the ItemsSource since it cannot convert the invalid object to an IEnumerable.

In practice, I see two complete sets of InvalidCastException for each ItemsSource value, resulting in 
significant, and user observable delays before the page is populated.

The sample illustrates two scenarios:

1: A nested StackLayout
Running the same in the debugger and observing debug output will show numerous InvalidCastException messages.
Enabling System.InvalidCastException will break into the debugger at the first Convert call that throws the exception.

2: Numerous BindingDiagnostic Warning messages
MainPage.xaml has two sets of Label/ListView; one commented out and the second active.  Uncomment the first
set and comment out the second will illustrate the case where multiple bindings fail for each ItemsSource value.

Note that in both cases, the application eventually starts up and displays as expected but performance 
affected. The InvalidCastException performance impact is easy for the user to observe since it delays
displaying the page. In my actual application, the delay is measured in seconds.