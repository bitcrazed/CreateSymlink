using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CreateSymlink
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        enum SYMBOLIC_LINK_FLAG : int { File = 0x00, Directory = 0x01 };

        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, SYMBOLIC_LINK_FLAG dwFlags);

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void CreateSymlinkButton_Click(object sender, RoutedEventArgs e)
        {
            const string linkFile = @"C:\Temp\hosts.txt";

            // Delete the symlink if it already exists.
            File.Delete(linkFile);

            bool result = CreateSymbolicLink(
                linkFile,
                @"C:\Windows\System32\Drivers\Etc\Hosts",
                SYMBOLIC_LINK_FLAG.File);

            if (true == result)
            {
                CreateSymlinksResultMessageBox.Text = "Symlink Created";
            }
            else
            {
                CreateSymlinksResultMessageBox.Text = "Symlink Creation Failed";

            }

        }
    }
}
