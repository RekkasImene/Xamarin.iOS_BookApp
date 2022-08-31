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
	[Register ("EditBookViewController")]
	partial class EditBookViewController
	{
		[Outlet]
		UIKit.UITextField AuthorText { get; set; }

		[Outlet]
		UIKit.UIButton deleteButton { get; set; }

		[Outlet]
		UIKit.UIButton editButton { get; set; }

		[Outlet]
		UIKit.UITextField NameText { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem saveButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AuthorText != null) {
				AuthorText.Dispose ();
				AuthorText = null;
			}

			if (NameText != null) {
				NameText.Dispose ();
				NameText = null;
			}

			if (saveButton != null) {
				saveButton.Dispose ();
				saveButton = null;
			}

			if (deleteButton != null) {
				deleteButton.Dispose ();
				deleteButton = null;
			}

			if (editButton != null) {
				editButton.Dispose ();
				editButton = null;
			}
		}
	}
}
