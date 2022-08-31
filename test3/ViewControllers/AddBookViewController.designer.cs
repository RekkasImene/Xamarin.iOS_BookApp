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
	[Register ("AddBookViewController")]
	partial class AddBookViewController
	{
		[Outlet]
		UIKit.UITextField AuthorText { get; set; }

		[Outlet]
		UIKit.UIImageView BookImage { get; set; }

		[Outlet]
		UIKit.UITextField NameText { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem SaveButton { get; set; }
		
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

			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}

			if (BookImage != null) {
				BookImage.Dispose ();
				BookImage = null;
			}
		}
	}
}
