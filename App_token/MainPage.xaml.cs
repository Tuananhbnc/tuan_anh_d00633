using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using App_token.Entity;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Diagnostics;
using Windows.Storage.Pickers;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App_token
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Member currentMember;

        public MainPage()
        {
            this.InitializeComponent();
            this.currentMember = new Member();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            // validate data.
            this.currentMember.name = this.Name.Text;
            this.currentMember.email = this.Email.Text;
            this.currentMember.phone = this.Phone.Text;

            string jsonMember = JsonConvert.SerializeObject(this.currentMember);
            Debug.WriteLine(jsonMember);

            string NameFile = FileName.Text;

            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = NameFile;
            StorageFile file = await savePicker.PickSaveFileAsync();

            await Windows.Storage.FileIO.WriteTextAsync(file, jsonMember);

        }
    }
}
