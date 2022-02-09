using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Media;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DrumPad {
  /// <summary>
  /// An empty window that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainWindow : Window {

    public MainWindow() {
      this.InitializeComponent();
    }

    private void findAndPlayWavAsset(string wavName) {
      // get the full path to your app's folder where it is installed
      var installedPath = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
      // join path above with the sub-paths in your Assets folder and the specific sound file
      var soundFile = Path.Join(installedPath, "Assets", $"{wavName}.wav");

      SoundPlayer player = new System.Media.SoundPlayer(soundFile);
      player.Play();
    }

    private void pad_Click(object sender, RoutedEventArgs e) {
      var button = (Button) sender;
      var soundName = button.Tag.ToString();
      findAndPlayWavAsset(soundName);
    }
  }
}
