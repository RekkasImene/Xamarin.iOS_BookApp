using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using test3.DataSource;
using test3.Interface;
using test3.Models;
using test3.Views;
using UIKit;

namespace test3
{
	public partial class ViewController : UIViewController
	{

		private IList<UserModel> users;
		IUsers myUsers;
		public ViewController(IntPtr handle) : base(handle)
        {
			myUsers = new UserLocalDatabase();
			users = myUsers.GetListUsers();
			if (users.Count == 0)
			{
                //initialization of user table
                DoSomeDataAccess();
			}
		}

        public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			loginButton.Enabled = false;

			usernameText.ShouldReturn = (textField) =>
			{
				textField.ResignFirstResponder();
				return true;
			};

			pwdText.ShouldReturn = (textField) =>
			{
				textField.ResignFirstResponder();
				return true;
			};

			pwdText.EditingDidEnd += (sender, args) =>
			{
				bool pval = ValidatePassword.PasswordIsValid(pwdText.Text);
				if (pval)
                {
					loginButton.Enabled = true;
                }
                else
                {
                    Alert("Error", "Password Invalid please try again");
					loginButton.Enabled = false;
                }
			};

			//To move up text feilds once the keyboard is opened

			/****
			NSNotificationCenter.DefaultCenter.AddObserver(
				UIKeyboard.WillShowNotification, KeyboardWillChange);
			NSNotificationCenter.DefaultCenter.AddObserver(
				UIKeyboard.WillHideNotification, KeyboardWillChange);
			****/

			//action to do when clicking on loginButton
			loginButton.TouchUpInside += LoginButton_TouchUpInside;

		}

		//to hide keyboard when clic on view
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
			this.View.EndEditing(true);
        }

		//in order to not hide text feilds when keyboard is opened
		void KeyboardWillChange(NSNotification notification)
        {
			if(notification.Name == UIKeyboard.WillShowNotification)
            {
				var keyboard = UIKeyboard.FrameBeginFromNotification(notification);
				CGRect frame = View.Frame;
				frame.Y = -keyboard.Height;
				View.Frame = frame;
            }

			if(notification.Name == UIKeyboard.WillHideNotification)
            {
				CGRect frame = View.Frame;
				frame.Y = 0;
				View.Frame = frame;
            }
        }

        public void DoSomeDataAccess()
		{
			//only insert the data if doesn't already exist
			myUsers.AddUser(new UserModel()
			{
				Username="irekkas",
				Pwd="irekkas"
			});
			myUsers.AddUser(new UserModel()
			{
				Username = "mmoro",
				Pwd = "mmoro"
			});
				
		}

		private void LoginButton_TouchUpInside(object sender, EventArgs e)
		{
			Console.WriteLine("Reading Users Data");
			foreach(var user in users)
            {
				Console.WriteLine(user.Id + " " + user.Username + " " + user.Pwd);
            }

			bool valid = myUsers.ValidUser(usernameText.Text, pwdText.Text);
			if (valid)
			{
				Console.WriteLine("The user " + usernameText.Text + " exist");

				//To send us to a new view controller ( new page)
				MainNavigationController mainNavigationController =
				   this.Storyboard.InstantiateViewController("MainNavigationController") as MainNavigationController;
				mainNavigationController.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
				PresentViewController(mainNavigationController, true, null);


			}
			else
			{
				Alert("Error", "Username or Password invalid please try again !");
				Console.WriteLine("The user " + usernameText.Text + " doesn't exist");

			}
			
		}


		private void Alert(string title, string msg)
		{
			var okAlertController = UIAlertController.Create(title, msg, UIAlertControllerStyle.Alert);
			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

			PresentViewController(okAlertController, true, null);
		}

	}

}