// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace test3
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton loginButton { get; set; }

		[Outlet]
		UIKit.UITextField pwdText { get; set; }

		[Outlet]
		UIKit.UITextField usernameText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (usernameText != null) {
				usernameText.Dispose ();
				usernameText = null;
			}

			if (pwdText != null) {
				pwdText.Dispose ();
				pwdText = null;
			}

			if (loginButton != null) {
				loginButton.Dispose ();
				loginButton = null;
			}
		}
	}
}
