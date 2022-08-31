using Foundation;
using test3.DataSource;
using test3.Interface;
using test3.Views;
using UIKit;

namespace test3
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        IUsers myUsers;
        IBooks myBooks;
        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            myUsers = new UserLocalDatabase();
            myUsers.CreateDb();
            myBooks = new BookLocalDatabase();
            myBooks.CreateDb();

            //Decide First Screen
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            var storyBoard = UIStoryboard.FromName("Main", null);
            /*
            var currentUser = "irekkas";
            if( currentUser != null)
            {
                var mainNavigationController = storyBoard.InstantiateViewController("MainNavigationController") as MainNavigationController;
                this.SetWindow(Window);
                Window.RootViewController = mainNavigationController;
            }
            else
            {
                var loginViewController = storyBoard.InstantiateViewController("LoginViewController") as ViewController;
                this.SetWindow(Window);
                Window.RootViewController = loginViewController;
            }*/

            return true;
        }

        // UISceneSession Lifecycle

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }
    }
}

